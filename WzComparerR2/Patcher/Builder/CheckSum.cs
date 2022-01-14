using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace WzComparerR2.Patcher.Builder
{
    public class CheckSum
    {
        static CheckSum()
        {
            if (sbox == null)
            {
                sbox = new uint[SizeSBox * 8];
                Generatesbox(sbox);
            }
        }

        private CheckSum()
        {

        }

        private const int PolyNomial = 0x04C11DB7;
        private const uint TopBit = 0x80000000;
        private const int SizeSBox = 256;
        private const int TableNum = 8;
        private static uint[] sbox;

        private static void Generatesbox(uint[] sbox)
        {
            uint remain;
            uint i;
            int bit;

            for (i = 0; i < SizeSBox; i++)
            {
                remain = i << 0x18;
                for (bit = 0; bit < 8; bit++)
                {
                    if ((remain & TopBit) != 0)
                    {
                        remain = (remain << 1) ^ PolyNomial;
                    }
                    else
                    {
                        remain = (remain << 1);
                    }
                }
                sbox[i] = remain;
            }

            for (; i < sbox.Length; i++)
            {
                uint r = sbox[i - 256];
                sbox[i] = sbox[r >> 24] ^ (r << 8);
            }
        }

        public static uint ComputeHash2(Stream stream, int length)
        {
            return ComputeHash2(stream, length, 0);
        }

        private static uint ComputeHash2_(Stream stream, int length, uint rollingChecksum)
        {
            byte[] buffer = new byte[0x8000];

            while (length > 0)
            {
                int count = stream.Read(buffer, 0, Math.Min(buffer.Length, length));
                if (count == 0)
                    break;

                for (int i = 0; i < count; i++)
                {
                    uint IndexLookup = ((rollingChecksum >> 0x18) ^ buffer[i]);
                    rollingChecksum = (uint)((rollingChecksum << 0x08) ^ sbox[IndexLookup]);
                }

                length -= count;
            }
            return rollingChecksum;
        }

        public static unsafe uint ComputeHash2(Stream stream, int length, uint crc)
        {
            byte[] buffer = new byte[0x8000];
            uint[] table = sbox;

            fixed (byte* pBuffer = buffer)
            {
                while (length > 0)
                {
                    int count = stream.Read(buffer, 0, Math.Min(buffer.Length, length));
                    if (count == 0)
                    {
                        break;
                    }
                    crc = ComputeHash(pBuffer, 0, count, crc);
                    length -= count;
                }
            }
            return crc;
        }

        public static uint ComputeHash2(byte[] data, int startIndex, int count, uint crc)
        {
            for (int i = startIndex, i0 = startIndex + count; i < i0; i++)
            {
                uint IndexLookup = ((crc >> 0x18) ^ data[i]);
                crc = (uint)((crc << 0x08) ^ sbox[IndexLookup]);
            }
            return crc;
        }

        public static uint ComputeHash(Stream stream, long length, EventHandler<PatchingEventArgs> PatchingStateChanged = null)
        {
            FileStream fs = stream as FileStream;
            if (fs != null && fs.IsAsync)
            {
                return ComputeHashAsync(fs, length, 0, PatchingStateChanged);
            }
            else
            {
                return ComputeHash(stream, length, 0, PatchingStateChanged);
            }
        }

        public static uint ComputeHashAsync(FileStream stream, long length, uint crc, EventHandler<PatchingEventArgs> PatchingStateChanged = null)
        {
            var hash = new AsyncFileHash(stream, length, PatchingStateChanged);
            crc = hash.Compute(crc);
            return crc;
        }

        public static unsafe uint ComputeHash(Stream stream, long length, uint crc, EventHandler<PatchingEventArgs> PatchingStateChanged = null)
        {
            byte[] buffer = new byte[0x8000];
            PatchPartContext part = new PatchPartContext("", 0, 0);
            part.NewFileLength = (int)length;

            double patchProc = 0;
            const double patchProcReportInverval = 0.005;
            long patchLength = 0;
            const long patchLengthReportInterval = 1 * 1024 * 1024;

            while (length > 0)
            {
                int count = stream.Read(buffer, 0, (int)Math.Min(buffer.Length, length));
                if (count == 0)
                {
                    break;
                }
                crc = ComputeHash(buffer, 0, count, crc);
                length -= count;
                if (PatchingStateChanged != null && part.NewFileLength > 0)
                {
                    long curLength = part.NewFileLength - length;
                    double curProc = 1.0 * curLength / part.NewFileLength;
                    if (curProc - patchProc >= patchProcReportInverval && curLength - patchLength >= patchLengthReportInterval)// || curProc >= 1 - patchProcReportInverval)
                    {
                        PatchingStateChanged(null, new PatchingEventArgs(part, PatchingState.TempFileBuildProcessChanged, curLength));//更新进度改变
                        patchProc = curProc;
                        patchLength = curLength;
                    }
                }
            }
            return crc;
        }

        public static unsafe uint ComputeHash(byte[] data, int startIndex, int count, uint crc)
        {
            fixed (byte* pdata = data)
            {
                return ComputeHash(pdata, startIndex, count, crc);
            }
        }

        private static unsafe uint ComputeHash(byte* data, int startIndex, int count, uint crc)
        {
            fixed (uint* table = sbox)
            {
                byte* pcrc = (byte*)&crc;
                int endIndex = startIndex + count;
                while (endIndex - startIndex >= 8)
                {
                    byte* p2 = data + startIndex;
                    crc ^= (uint)((p2[0] << 24) + (p2[1] << 16) + (p2[2] << 8) + p2[3]);
                    crc = table[pcrc[3] + 0x700]
                            ^ table[pcrc[2] + 0x600]
                            ^ table[pcrc[1] + 0x500]
                            ^ table[pcrc[0] + 0x400]
                            ^ table[p2[4] + 0x300]
                            ^ table[p2[5] + 0x200]
                            ^ table[p2[6] + 0x100]
                            ^ table[p2[7] + 0x000];
                    startIndex += 8;
                }

                for (; startIndex < endIndex; startIndex++)
                {
                    crc = (crc << 8) ^ (table[(crc >> 24) ^ data[startIndex]]);
                }
            }
            return crc;
        }


        private class AsyncFileHash
        {
            public AsyncFileHash(FileStream fs, long length, EventHandler<PatchingEventArgs> PatchingStateChanged = null)
            {
                this.fs = fs;
                this.length = length;
                this.crc = 0;
                this.evCheckSum = new AutoResetEvent(false);
                this.evCallBack = new AutoResetEvent(true);
                this.PatchingStateChanged = PatchingStateChanged;
                this.part = new PatchPartContext("", 0, 0);
                this.part.NewFileLength = (int)length;
            }

            FileStream fs;
            long length;
            AutoResetEvent evCheckSum;
            AutoResetEvent evCallBack;
            uint crc;
            EventHandler<PatchingEventArgs> PatchingStateChanged;
            PatchPartContext part;
            byte[] buffer1 = new byte[0x20000];
            byte[] buffer2 = new byte[0x20000];

            double patchProc = 0;
            const double patchProcReportInverval = 0.005;
            long patchLength = 0;
            const long patchLengthReportInterval = 1 * 1024 * 1024;

            public uint Compute(uint crc)
            {
                this.crc = crc;
                this.Begin(buffer1);
                this.evCheckSum.WaitOne();
                return this.crc;
            }

            private void Begin(byte[] buffer)
            {
                IAsyncResult ir = fs.BeginRead(buffer, 0, (int)Math.Min(length, buffer.Length), CallBack, buffer);
            }

            private void CallBack(IAsyncResult ir)
            {
                byte[] buffer = (byte[])ir.AsyncState;
                int count = fs.EndRead(ir);
                this.length -= count;
                bool doEnd = this.length <= 0;

                this.evCallBack.WaitOne();
                if (!doEnd)
                {
                    byte[] nextBuffer = buffer == buffer1 ? buffer2 : buffer1;
                    Begin(nextBuffer);
                }
                this.crc = CheckSum.ComputeHash(buffer, 0, count, this.crc);
                if (this.PatchingStateChanged != null && this.part.NewFileLength > 0)
                {
                    long curLength = this.part.NewFileLength - length;
                    double curProc = 1.0 * curLength / this.part.NewFileLength;
                    if (curProc - this.patchProc >= patchProcReportInverval && curLength - this.patchLength >= patchLengthReportInterval)// || curProc >= 1 - patchProcReportInverval)
                    {
                        this.PatchingStateChanged(null, new PatchingEventArgs(part, PatchingState.TempFileBuildProcessChanged, curLength));//更新进度改变
                        this.patchProc = curProc;
                        this.patchLength = curLength;
                    }
                }
                this.evCallBack.Set();

                if (doEnd)
                {
                    this.End();
                }
            }

            private void End()
            {
                this.evCheckSum.Set();
            }
        }
    }
}
