using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace DataGrid
{
    class DataViewer : DataGridView
    {
        public GridType DefaultGridType;
        public DataViewer(GridType gridType)
        {
            Dock = System.Windows.Forms.DockStyle.Fill;
            RowTemplate.Height = 80;
            DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ColumnHeadersHeight = 28;
            this.MultiSelect = false;    
            DefaultCellStyle.Font = new System.Drawing.Font("微軟正黑體", 11);
            var ID = new DataGridViewTextBoxColumn();
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.Name = "propID";
            ID.ReadOnly = true;
            ID.Width = 120;
            ID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var Icon = new DataGridViewImageColumn();
            Icon.DataPropertyName = "Icon";
            Icon.HeaderText = "圖示";
            Icon.Name = "propBitmap";
            Icon.ReadOnly = true;
            Icon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Icon.Width = 100;

            var MorphIcon = new DataGridViewImageColumn();
            MorphIcon.DataPropertyName = "MorphIcon";
            MorphIcon.HeaderText = "變身";
            MorphIcon.Name = "propBitmap";
            MorphIcon.ReadOnly = true;
            MorphIcon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MorphIcon.Width = 100;

            var Name = new DataGridViewTextBoxColumn();
            Name.DataPropertyName = "NameProperty";
            Name.HeaderText = "名稱";
            Name.Name = "propName";
            Name.ReadOnly = true;
            Name.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Name.Width = 200;

            var Info = new DataGridViewTextBoxColumn();
            Info.DataPropertyName = "PropertiesProperty";
            Info.HeaderText = "原始資料";
            Info.Name = "propProperties";
            Info.ReadOnly = true;
            Info.Width = 350;
            Info.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Info.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var ChnData = new DataGridViewTextBoxColumn();
            ChnData.DataPropertyName = "SpeakNameProperty";
            ChnData.HeaderText = "資料";
            ChnData.Name = "Speak";
            ChnData.ReadOnly = true;
            ChnData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ChnData.Width = 800;

            var Desc = new DataGridViewTextBoxColumn();
            Desc.DataPropertyName = "DescProperty";
            Desc.HeaderText = "描述";
            Desc.Name = "Desc";
            Desc.ReadOnly = true;
            Desc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Desc.Width = 100;

            var Level = new DataGridViewTextBoxColumn();
            Level.DataPropertyName = "LevelProperty";
            Level.HeaderText = "Level";
            Level.Name = "Level";
            Level.ReadOnly = true;
            Level.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Level.Width = 100;

            var MapName = new DataGridViewTextBoxColumn();
            MapName.DataPropertyName = "MapNameProperty";
            MapName.HeaderText = "MapName";
            MapName.Name = "MapName";
            MapName.ReadOnly = true;
            MapName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MapName.Width = 100;

            var StreetName = new DataGridViewTextBoxColumn();
            StreetName.DataPropertyName = "StreetNameProperty";
            StreetName.HeaderText = "StreetName";
            StreetName.Name = "StreetName";
            StreetName.ReadOnly = true;
            StreetName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StreetName.Width = 100;

            var Speak = new DataGridViewTextBoxColumn();
            Speak.DataPropertyName = "SpeakNameProperty";
            Speak.HeaderText = "Speak";
            Speak.Name = "Speak";
            Speak.ReadOnly = true;
            Speak.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Speak.Width = 800;

            var MorphID = new DataGridViewTextBoxColumn();
            MorphID.DataPropertyName = "MorphID";
            MorphID.HeaderText = "MorphID";
            MorphID.Name = "propID";
            MorphID.ReadOnly = true;
            MorphID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MorphID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MorphID.Width = 90;

            var FamiliarSkillName = new DataGridViewTextBoxColumn();
            FamiliarSkillName.DataPropertyName = "NameProperty";
            FamiliarSkillName.HeaderText = "技能";
            FamiliarSkillName.Name = "propName";
            FamiliarSkillName.ReadOnly = true;
            FamiliarSkillName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FamiliarSkillName.Width = 100;

            var FamiliarSkillDesc = new DataGridViewTextBoxColumn();
            FamiliarSkillDesc.DataPropertyName = "NameProperty";
            FamiliarSkillDesc.HeaderText = "技能描述";
            FamiliarSkillDesc.Name = "propName";
            FamiliarSkillDesc.ReadOnly = true;
            FamiliarSkillDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FamiliarSkillDesc.Width = 100;

            var FamiliarCardID = new DataGridViewTextBoxColumn();
            FamiliarCardID.DataPropertyName = "NameProperty";
            FamiliarCardID.HeaderText = "萌獸卡ID";
            FamiliarCardID.Name = "propName";
            FamiliarCardID.ReadOnly = true;
            FamiliarCardID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FamiliarCardID.Width = 100;

            var FamiliarIcon = new DataGridViewImageColumn();
            FamiliarIcon.DataPropertyName = "FamiliarIcon";
            FamiliarIcon.HeaderText = "萌獸";
            FamiliarIcon.Name = "propBitmap";
            FamiliarIcon.ReadOnly = true;
            FamiliarIcon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FamiliarIcon.Width = 100;

            var Sample = new DataGridViewImageColumn();
            Sample.DataPropertyName = "Sample";
            Sample.HeaderText = "Sample";
            Sample.Name = "propBitmap";
            Sample.ReadOnly = true;
            Sample.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Sample.Width = 280;
            switch (gridType)
            {
                case GridType.Normal:
                    RowTemplate.Height = 40;
                    Desc.Width = 600;
                    Info.Width = 200;
                    Columns.AddRange(ID, Icon, Name, ChnData, Info);
                    break;

                case GridType.Item:
                    RowTemplate.Height = 40;
                    Desc.Width = 600;
                    Info.Width = 200;
                    Columns.AddRange(ID, Icon, Name, Desc, Info);
                    break;

                case GridType.Map:
                    RowTemplate.Height = 60;
                    Desc.Width = 600;
                    Info.Width = 200;
                    StreetName.Width = 200;
                    MapName.Width = 200;
                    Icon.Width = 250;
                    Columns.AddRange(ID, Icon, StreetName, MapName, Info);
                    break;

                case GridType.Mob:
                    RowTemplate.Height = 80;
                    Icon.Width = 150;
                    Desc.Width = 600;
                    Info.Width = 200;
                    Columns.AddRange(ID, Icon, Name, ChnData, Info);
                    break;

                case GridType.Skill:
                    RowTemplate.Height = 60;
                    Icon.Width = 80;
                    Desc.Width = 400;
                    Info.Width = 200;
                    Level.Width = 450;
                    Columns.AddRange(ID, Icon, Name, Desc, Level, Info);
                    break;

                case GridType.Npc:
                    RowTemplate.Height = 70;
                    Desc.Width = 600;
                    Info.Width = 200;
                    Columns.AddRange(ID, Icon, Name, Speak, Info);
                    break;

                case GridType.Morph:
                    RowTemplate.Height = 70;
                    Desc.Width = 600;
                    Columns.AddRange(ID, Icon, MorphID, MorphIcon, Name, Desc, Info);
                    break;

                case GridType.Familiar:
                    RowTemplate.Height = 70;
                    ColumnHeadersHeight = 28;
                    Desc.Width = 300;
                    FamiliarSkillName.Width = 150;
                    FamiliarSkillDesc.Width = 350;
                    Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
                    Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                    Info.Width = 300;
                    Columns.AddRange(ID, FamiliarIcon, Info, FamiliarSkillName, FamiliarSkillDesc, FamiliarCardID, Icon, Name);
                    break;

                case GridType.DamageSkin:
                    RowTemplate.Height = 50;
                    ColumnHeadersHeight = 28;
                    Name.Width = 250;
                    Desc.Width = 600;
                    Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                    Columns.AddRange(ID, Icon, Name, Sample, Desc);
                    break;

                case GridType.Reactor:
                    RowTemplate.Height = 80;
                    Info.Width = 300;
                    Columns.AddRange(ID, Icon, Info);
                    break;

                case GridType.Music:
                    RowTemplate.Height = 40;
                    Name.Width = 800;
                    Columns.AddRange(Name);
                    break;

            }

            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                var dgvType = this.GetType();
                var pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(this, true, null);
            }
            DefaultGridType = gridType;

        }


    }

    public enum GridType
    {
        Normal,
        Item,
        Map,
        Mob,
        Skill,
        Npc,
        Morph,
        Familiar,
        DamageSkin,
        Reactor,
        Music 
    }

    public static class DataGridViewExtension
    {
        public static void SaveBin(this DataGridView dataGridView, string Path)
        {
            var BinWriter = new BinaryWriter(System.IO.File.Open(Path, FileMode.Create));
            BinWriter.Write(dataGridView.Columns.Count);
            BinWriter.Write(dataGridView.Rows.Count);
            foreach (DataGridViewRow Row in dataGridView.Rows)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    object val = (Row as DataGridViewRow).Cells[j].Value;
                    if (val is string)
                    {
                        BinWriter.Write("str");
                        BinWriter.Write(val.ToString());
                    }
                    else if (val is Bitmap)
                    {
                        BinWriter.Write("Bitmap");
                        var MemStream = new MemoryStream();
                        (val as Bitmap).Save(MemStream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] Buffer = MemStream.GetBuffer();
                        BinWriter.Write(Buffer.Length);
                        BinWriter.Write(Buffer);
                    }
                }

            }

            BinWriter.Close();
        }


        public static void LoadBin(this DataGridView dataGridView, string Path)
        {
            var BinReader = new BinaryReader(System.IO.File.Open(Path, FileMode.Open));
            var n = BinReader.ReadInt32();
            var m = BinReader.ReadInt32();
            for (int i = 0; i <= m - 2; i++)
            {
                dataGridView.Rows.Add();
                for (int j = 0; j <= n - 1; j++)
                {
                    if (BinReader.ReadString() == "str")
                        dataGridView.Rows[i].Cells[j].Value = BinReader.ReadString();
                    else
                    {
                        var BufferLength = BinReader.ReadInt32();
                        byte[] Buffer = BinReader.ReadBytes(BufferLength);
                        var MemStream = new MemoryStream(Buffer);
                        var LImage = Image.FromStream(MemStream);
                        var Bmp = new Bitmap(LImage.Width, LImage.Height, PixelFormat.Format16bppRgb555);
                        Bmp.MakeTransparent();
                        var g = Graphics.FromImage(Bmp);
                        g.DrawImage(LImage, new Rectangle(0, 0, LImage.Width, LImage.Height));
                        dataGridView.Rows[i].Cells[j].Value = Bmp;
                    }

                }
            }

            BinReader.Close();

        }


    }
}
