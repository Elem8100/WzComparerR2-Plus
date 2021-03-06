using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WzComparerR2.Patcher.Builder
{
    public class StreamUtils
    {
        public static void CopyStream(Stream src, Stream dest)
        {
            CopyStream(src, dest, Int32.MaxValue);
        }

        public static void CopyStream(Stream src, Stream dest, int length)
        {
            byte[] buffer = new byte[0x8000];
            while (length > 0)
            {
                int count = src.Read(buffer, 0, Math.Min(buffer.Length, length));
                if (count == 0)
                    break;
                dest.Write(buffer, 0, count);
                length -= count;
            }
        }

        public static void FillStream(Stream stream, int length, byte data)
        {
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = data;
            }
            stream.Write(buffer, 0, length);
        }

        public static uint MoveStreamWithCrc32(Stream src, Stream dest, int length, uint crc, EventHandler<PatchingEventArgs> PatchingStateChanged = null)
        {
            byte[] buffer = new byte[0x8000];
            PatchPartContext part = new PatchPartContext("", 0, 0);
            part.NewFileLength = length;

            double patchProc = 0;
            const double patchProcReportInverval = 0.005;
            int patchLength = 0;
            const int patchLengthReportInterval = 1 * 1024 * 1024;

            while (length > 0)
            {
                if (PatchingStateChanged != null && part.NewFileLength > 0)
                {
                    int curLength = part.NewFileLength - length;
                    double curProc = 1.0 * curLength / part.NewFileLength;
                    if (curProc - patchProc >= patchProcReportInverval && curLength - patchLength >= patchLengthReportInterval)// || curProc >= 1 - patchProcReportInverval)
                    {
                        PatchingStateChanged(null, new PatchingEventArgs(part, PatchingState.TempFileBuildProcessChanged, curLength));//更新进度改变
                        patchProc = curProc;
                        patchLength = curLength;
                    }
                }
                int count = src.Read(buffer, 0, Math.Min(buffer.Length, length));
                if (count == 0)
                    break;
                crc = CheckSum.ComputeHash2(buffer, 0, count, crc);
                dest.Write(buffer, 0, count);
                length -= count;
            }
            return crc;
        }

        public static uint FillStreamWithCrc32(Stream stream, int length, byte data, uint crc)
        {
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = data;
            }
            crc = CheckSum.ComputeHash2(buffer, 0, length, crc);
            stream.Write(buffer, 0, length);
            return crc;
        }
    }
}
