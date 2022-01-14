using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WzComparerR2.WzLib;
using WzComparerR2.Common;
using WzComparerR2.PluginBase;
using System.Threading;
using WzComparerR2.MapRender;
using System.Reflection;

namespace WzComparerR2
{
    public partial class IconsForm:Form
    {
        public IconsForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public static IconsForm Instance;
        Wz_Node GetNode(string Path)
        {
            return MainForm.GetNode(Path);
        }
        List<(Bitmap, string)> ImageList;
        bool[] HasLoaded = new bool[34];
        DataGridView[] ImageGrids = new DataGridView[34];
        DataGridView ShowImageGrid;

        void LoadItem(string ItemDir)
        {
            foreach(var img in GetNode("Item/" + ItemDir).Nodes)
            {
                if(ItemDir == "Pet")
                {
                    var ID = img.ImgID();
                    if(GetNode("Item/Pet/" + img.Text + "/info/iconD") != null)
                        ImageList.Add((GetNode("Item/Pet/" + img.Text + "/info/iconD").ExtractPng(), ID));
                }
                else
                {
                    foreach(var Iter in GetNode("Item/" + ItemDir + "/" + img.Text).Nodes)
                    {
                        var ID = Iter.Text;
                        if(Iter.GetNode("info/icon") != null)
                            ImageList.Add((Iter.GetNode("info/icon").ExtractPng(), ID));
                    }
                }
            }
        }
        string LeftStr(string s,int count)
        {
            if(count > s.Length)
                count = s.Length;
            return s.Substring(0,count);
        }
        void LoadCharacter(string Dir)
        {
            foreach(var img in GetNode("Character/" + Dir).Nodes)
            {
                if(LeftStr(img.Text,1) != "0")
                    continue;
                var ID = img.ImgID();
                switch(Dir)
                {
                case "Hair":
                    if(img.GetNode("default/hairOverHead") != null)
                        ImageList.Add((img.GetNode("default/hairOverHead").ExtractPng(), ID));
                    break;
                case "Face":
                    if(img.GetNode("default/face") != null)
                        ImageList.Add((img.GetNode("default/face").ExtractPng(), ID));
                    break;
                default:
                    if(img.GetNode("info/icon") != null)
                        ImageList.Add((img.GetNode("info/icon").ExtractPng(), ID));
                    break;
                }
            }
        }
        void LoadMap()
        {
            var Links = new List<(string, string)>();
            foreach(var Dir in GetNode("Map/Map").Nodes)
            {
                if(LeftStr(Dir.Text,3) != "Map")
                    continue;
                foreach(var img in Dir.Nodes)
                {
                    var ID = img.ImgID();
                    if(img.GetNode("miniMap/canvas") != null)
                        ImageList.Add((img.GetNode("miniMap/canvas").ExtractPng(), ID));
                    var Link = img.GetNode("info/link");
                    if(Link != null)
                        Links.Add(("Map" + LeftStr(Link.Value.ToString(),1) + "/" + Link.Value.ToString() + ".img", ID));
                }
            }
            for(int i = 0;i < Links.Count;i++)
            {
                var Child = GetNode("Map/Map/" + Links[i].Item1 + "/miniMap/canvas");
                if(Child != null)
                    ImageList.Add((Child.ExtractPng(), Links[i].Item2));

            }
            ImageList.Sort((x,y) => x.Item2.CompareTo(y.Item2));
        }
        string RightStr(string s,int count)
        {
            if(count > s.Length)
                count = s.Length;
            return s.Substring(s.Length - count,count);
        }
        void LoadMob()
        {
            var Links = new List<(string, string)>();
            Wz_Node Child = null;
            foreach(var Iter in GetNode("String/Mob.img").Nodes)
            {
                var ID = Iter.Text.PadLeft(7,'0');
                if(GetNode("Mob/" + ID + ".img") == null)
                    continue;

                if(GetNode("Mob/" + ID + ".img/info/link") != null)
                {
                    Links.Add((GetNode("Mob/" + ID + ".img/info/link").Value.ToString(), ID));
                    continue;
                }

                if(GetNode("Mob/" + ID + ".img/stand/0") != null)
                    Child = GetNode("Mob/" + ID + ".img/stand/0");
                else if(GetNode("Mob/" + ID + ".img/fly/0") != null)
                    Child = GetNode("Mob/" + ID + ".img/fly/0");
                if(Child != null)
                    ImageList.Add((Child.ExtractPng(), ID));
            }

            for(int i = 0;i < Links.Count;i++)
            {
                if(GetNode("Mob/" + Links[i].Item1 + ".img/stand/0") != null)
                    Child = GetNode("Mob/" + Links[i].Item1 + ".img/stand/0");
                else if(GetNode("Mob/" + Links[i].Item1 + ".img/fly/0") != null)
                    Child = GetNode("Mob/" + Links[i].Item1 + ".img/fly/0");
                ImageList.Add((Child.ExtractPng(), Links[i].Item2));
            }
            ImageList.Sort((x,y) => x.Item2.CompareTo(y.Item2));
        }
        string GetIDPath(string ID)
        {
            var Left1 = LeftStr(ID,1);
            switch(Left1)
            {
            case "0":
                return "Skill/000.img/skill/" + ID;
                break;
            case "8":
                return "Skill/" + (int.Parse(ID) / 100).ToString() + ".img/skill/" + ID;
                break;
            default:
                return "Skill/" + (int.Parse(ID) / 10000).ToString() + ".img/skill/" + ID;
                break;
            }
        }
        void LoadSkill()
        {
            Wz_Node Child;
            if(MainForm.HasSkill001)
            {
                foreach(var Iter in GetNode("String/Skill.img").Nodes)
                {
                    var ID = Iter.Text;
                    //  if(GetNode(GetIDPath(ID)) == null)
                    //   continue;
                    if(GetNode("Skill/" + ID + ".img/info/icon") != null)
                        ImageList.Add((GetNode("Skill/" + ID + ".img/info/icon").ExtractPng(), ID));
                    Child = GetNode(GetIDPath(ID) + "/icon");
                    if(Child != null)
                        ImageList.Add((Child.ExtractPng(), ID));
                }
            }
            else
            {
                foreach(var img in GetNode("Skill").Nodes)
                {
                    if(Char.IsNumber(img.Text,0))
                    {
                        var BookID = img.ImgID();
                        if(GetNode("Skill/" + img.Text + "/info/icon") != null)
                            ImageList.Add((GetNode("Skill/" + img.Text + "/info/icon").ExtractPng(), BookID));
                        foreach(var Iter in GetNode("Skill/" + img.Text).Nodes)
                        {
                            foreach(var Iter2 in Iter.Nodes)
                            {
                                if(Iter.Text == "skill")
                                {
                                    var SkillID = Iter2.Text;
                                    if(Iter2.GetNode("icon") != null)
                                        ImageList.Add((Iter2.GetNode("icon").ExtractPng(), SkillID));
                                }
                            }
                        }
                    }

                }

            }
            ImageList.Sort((x,y) => x.Item2.CompareTo(y.Item2));
        }
        void LoadNpc()
        {
            var Links = new List<(string, string)>();
            Bitmap Icon = null;
            foreach(var Img in GetNode("Npc").Nodes)
            {
                var ID = Img.ImgID();
                var Link = GetNode("Npc/" + Img.Text + "/info/link");
                if(Link != null)
                {
                    Links.Add((Link.Value.ToString() + ".img", ID));
                    continue;
                }
                var Entry = GetNode("Npc/" + Img.Text);
                if(Entry.GetNode("stand/0") != null)
                    Icon = Entry.GetNode("stand/0").ExtractPng();
                if(Entry.GetNode("default/0") != null)
                    Icon = Entry.GetNode("default/0").ExtractPng();
                ImageList.Add((Icon, ID));
            }
            Wz_Node Child = null;

            for(int i = 0;i < Links.Count;i++)
            {
                if(GetNode("Npc/" + Links[i].Item1 + "/stand/0") != null)
                    Child = GetNode("Npc/" + Links[i].Item1 + "/stand/0");
                else if(GetNode("Npc/" + Links[i].Item1 + "/default/0") != null)
                    Child = GetNode("Npc/" + Links[i].Item1 + "/default/0");
                ImageList.Add((Child.ExtractPng(), Links[i].Item2));
            }
            ImageList.Sort((x,y) => x.Item2.CompareTo(y.Item2));
        }

        void LoadMorph()
        {
            foreach(var Img in GetNode("Morph").Nodes)
            {
                var ID = Img.ImgID();
                Bitmap MorphPic = null;
                if(GetNode("Morph/" + ID + ".img/walk/0") != null)
                    MorphPic = GetNode("Morph/" + ID + ".img/walk/0").ExtractPng();
                if(MorphPic != null)
                    ImageList.Add((MorphPic, ID));
            }

        }

        void LoadFamiliar()
        {
            if(GetNode("Character/Familiar") == null)
            {
                MessageBox.Show("Familiar  not found");
                return;
            }
            Wz_Node CardEntry;
            Bitmap Icon = null;
            string CardID = "";
            foreach(var img in GetNode("Character/Familiar").Nodes)
            {
                var ID = img.ImgID();
                var Entry = GetNode("Character/Familiar/" + img.Text);

                if(GetNode("Etc/FamiliarInfo.img") != null)
                {
                    if(GetNode("Etc/FamiliarInfo.img/" + ID) != null)
                        CardID = GetNode("Etc/FamiliarInfo.img/" + ID).GetValue2("consume","");
                }
                else
                {
                    if(Entry.GetNode("info/monsterCardID") != null)
                        CardID = Entry.GetNode("info/monsterCardID").Value.ToString();
                    else
                        CardID = "";
                }

                if(GetNode("Item/Consume/0287.img/0" + CardID) != null)
                {
                    CardEntry = GetNode("Item/Consume/0287.img/0" + CardID);
                    if(CardEntry.GetNode("info/icon") != null)
                        Icon = CardEntry.GetNode("info/icon").ExtractPng();
                }
                else if(GetNode("Item/Consume/0238.img/0" + CardID) != null)
                {
                    CardEntry = GetNode("Item/Consume/0238.img/0" + CardID);
                    if(CardEntry.GetNode("info/iconRaw") != null)
                        Icon = CardEntry.GetNode("info/iconRaw").ExtractPng();
                }
                else
                    Icon = null;

                var CardName = GetNode("String/Consume.img/" + CardID).GetValue2("name","");
                ImageList.Add((Icon, "0" + CardID));
            }
        }

        void LoadDamageSkin()
        {
            Bitmap Icon = null;
            foreach(var Iter in GetNode("String/Consume.img").Nodes)
            {
                var Name = Iter.GetValue2("name","");
                if((Name.Contains("字型")) || (Name.Contains("ジスキン")) || (Name.Contains("스킨")) || (Name.Contains
                  ("Damage Skin")) || (Name.Contains("字型")) || (Name.Contains("伤害皮肤")))
                {
                    var ID = "0" + Iter.Text;
                    string[] imgs = new string[] { "0243.img","0263.img" };

                    for(int i = 0;i <= 1;i++)
                    {
                        var Entry = GetNode("Item/Consume/" + imgs[i] + "/0" + Iter.Text + "/info/icon");
                        if(Entry != null)
                            Icon = Entry.ExtractPng();
                    }
                    ImageList.Add((Icon, ID));
                }
            }
        }

        void LoadReactor()
        {
            var Links = new List<(string, string)>();
            Bitmap Icon = null;
            foreach(var img in GetNode("Reactor").Nodes)
            {
                var ID = img.ImgID();
                var Link = GetNode("Reactor/" + ID + "/info/link");
                if(Link != null)
                {
                    Links.Add((Link.Value.ToString() + ".img", ID));
                    continue;
                }
                var Entry = GetNode("Reactor/" + img.Text + "/0/0");
                if(Entry != null)
                    Icon = Entry.ExtractPng();
                ImageList.Add((Icon, ID));
            }

            Wz_Node Child = null;
            for(int i = 0;i < Links.Count;i++)
            {
                if(GetNode("Reactor/" + Links[i].Item1 + ".img/0/0") != null)
                    Child = GetNode("Reactor/" + Links[i].Item1 + ".img/0/0");
                ImageList.Add((Child.ExtractPng(), Links[i].Item2));
            }

            ImageList.Sort((x,y) => x.Item2.CompareTo(y.Item2));
        }


         void LoadImages(DataGridView dataViewImages,int GridSize,bool Resize = false)
        {
            // dataViewImages.Rows.Clear();
            // dataViewImages.Columns.Clear();
            // dataViewImages.Refresh();
            int numColumnsForWidth = (dataViewImages.Width - 10) / (GridSize + 20);
            int numRows = 0;
            int numImages = ImageList.Count;
            numRows = numImages / numColumnsForWidth;
            // Do we have a an overfill for a row
            if(numImages % numColumnsForWidth > 0)
            {
                numRows += 1;
            }
            // Catch when we have less images than the maximum number of columns for the DataGridView width
            if(numImages < numColumnsForWidth)
            {
                numColumnsForWidth = numImages;
            }
            int numGeneratedCells = numRows * numColumnsForWidth;
            // Dynamically create the columns
            for(int index = 0;index < numColumnsForWidth;index++)
            {
                DataGridViewImageColumn dataGridViewColumn = new DataGridViewImageColumn();
                dataViewImages.Columns.Add(dataGridViewColumn);
                dataViewImages.Columns[index].Width = GridSize + 20;
            }
            // Create the rows
            for(int index = 0;index < numRows;index++)
            {
                dataViewImages.Rows.Add();
                dataViewImages.Rows[index].Height = GridSize + 20;
            }

            int columnIndex = 0;
            int rowIndex = 0;
            Image image;
            for(int index = 0;index < ImageList.Count;index++)
            {
                image = ImageList[index].Item1;
                if(Resize)
                {
                    if(image.Width > 90 || image.Height > 90)
                        image = ResizeImage2(image,70,70);
                }
                dataViewImages.Rows[rowIndex].Cells[columnIndex].Value = image;
                dataViewImages.Rows[rowIndex].Cells[columnIndex].ToolTipText = ImageList[index].Item2;

                // Have we reached the end column? if so then start on the next row
                if(columnIndex == numColumnsForWidth - 1)
                {
                    rowIndex++;
                    columnIndex = 0;
                }
                else
                {
                    columnIndex++;
                }
            }
        }
        FrmMapRender2 mapRenderGame2;
        void ShowMap(Wz_Node MapImg)
        {
            Wz_Node node = MapImg;
            if(node != null)
            {
                Wz_Image img = node.Value as Wz_Image;
                Wz_File wzFile = node.GetNodeWzFile();
                if(img != null && img.TryExtract())
                {
                    StringLinker sl;
                    sl = new StringLinker();
                    // StringLinker sl = this.Context.DefaultStringLinker;
                    if(!sl.HasValues) //生成默认stringLinker
                    {
                        sl = new StringLinker();
                        sl.Load(PluginManager.FindWz(Wz_Type.String).GetValueEx<Wz_File>(null));
                    }
                    //开始绘制
                    Thread thread = new Thread(() =>
                    {
#if !DEBUG
                        try
                        {
#endif
                            {
                                if(this.mapRenderGame2 != null)
                                {
                                    // return;
                                    this.mapRenderGame2.Dispose();
                                    this.mapRenderGame2 = null;
                                }
                                this.mapRenderGame2 = new FrmMapRender2(img) { StringLinker = sl };
                                this.mapRenderGame2.Window.Title = "MapRender ";
                                try
                                {
                                    using(this.mapRenderGame2)
                                    {
                                        this.mapRenderGame2.Run();
                                    }
                                }
                                finally
                                {
                                    this.mapRenderGame2 = null;
                                }
                            }
#if !DEBUG
                        }
                        catch(Exception ex)
                        {
                            PluginManager.LogError("MapRender",ex,"MapRender error:");
                            //  MessageBoxEx.Show(ex.ToString(), "MapRender");
                        }
#endif
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.IsBackground = true;
                    thread.Start();
                    // goto exit;
                }
            }
        }

        private void Form2_Load(object sender,EventArgs e)
        {
            this.FormClosing += (s,e1) =>
            {
                this.Hide();
                e1.Cancel = true;
            };
            ImageList = new List<(Bitmap, string)>();
            for(int i = 0;i < 34;i++)
            {
                ImageGrids[i] = new DataGridView();
                ImageGrids[i].Width = 620;
                ImageGrids[i].Height = 470;
                ImageGrids[i].ColumnHeadersVisible = false;
                ImageGrids[i].RowHeadersVisible = false;
                ImageGrids[i].GridColor = Color.LightGray;

                ImageGrids[i].CellClick += (s,e2) =>
                {
                    var Path = ShowImageGrid.Rows[e2.RowIndex].Cells[e2.ColumnIndex].ToolTipText;
                    if(listBox1.SelectedIndex == 16)
                    {
                        var imgNode = GetNode("Map/Map/Map" + LeftStr(Path,1)).FindNodeByPath(Path + ".img");
                        ShowMap(imgNode);
                        if(imgNode != null)
                            MainForm.ExpandTreeNode(imgNode);
                    }
                    else
                    {
                        MainForm.tooltipRef.Visible = true;
                        MainForm.tooltipRef.BringToFront();
                        Path = GetIDPath2(Path);
                        var Node = PluginManager.FindWz(Path);
                        if(Node != null)
                            MainForm.ExpandTreeNode(Node);
                        else
                            MainForm.tooltipRef.Visible = false;
                    }
                };
                ImageGrids[i].Scroll += (s,e1) =>
                {
                    MainForm.tooltipRef.Visible = false;
                };
            }
            ShowImageGrid = ImageGrids[0];
              
             if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                var dgvType = ShowImageGrid.GetType();
                var pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(ShowImageGrid, true, null);
            }   
            
         
         
        }
        void Click2(object sender,EventArgs e)
        {

           
        }
        void CellClick(DataGridView DataGrid,DataGridViewCellEventArgs e)
        {


        }

      

        Image ResizeImage(int index,int Width,int Height)
        {
            using(Image image = ImageList[index].Item1)
            {
                Image NewImage = image.GetThumbnailImage(Width,Height,null,IntPtr.Zero);

                return NewImage;
            }
        }

        public static Bitmap ResizeImage2(Image image,int width,int height)
        {
            var destRect = new Rectangle(0,0,width,height);
            var destImage = new Bitmap(width,height);
            destImage.SetResolution(image.HorizontalResolution,image.VerticalResolution);
            using(var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using(var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image,destRect,0,0,image.Width,image.Height,GraphicsUnit.Pixel,wrapMode);
                }
            }
            return destImage;
        }
     

        string GetIDPath2(string ID)
        {
            switch(listBox1.SelectedIndex)
            {
            case 0:
                return "Item/Cash/" + LeftStr(ID,4) + ".img/" + ID;
                break;
            case 1:
                return "Item/Consume/" + LeftStr(ID,4) + ".img/" + ID;
                break;
            case 2:
                return "Character/Weapon/" + ID + ".img";
                break;
            case 3:
                return "Character/Cap/" + ID + ".img";
                break;
            case 4:
                return "Character/Coat/" + ID + ".img";
                break;
            case 5:
                return "Character/Longcoat/" + ID + ".img";
                break;
            case 6:
                return "Character/Pants/" + ID + ".img";
                break;
            case 7:
                return "Character/Shoes/" + ID + ".img";
                break;
            case 8:
                return "Character/Glove/" + ID + ".img";
                break;
            case 9:
                return "Character/Ring/" + ID + ".img";
                break;
            case 10:
                return "Character/Cape/" + ID + ".img";
                break;
            case 11:
                return "Character/Accessory/" + ID + ".img";
                break;
            case 12:
                return "Character/Shield/" + ID + ".img";
                break;
            case 13:
                return "Character/TamingMob/" + ID + ".img";
                break;
            case 14:
                return "Character/Hair/" + ID + ".img";
                break;
            case 15:
                return "Character/Face/" + ID + ".img";
                break;
            case 17:
                return "Mob/" + ID + ".img";
                break;
            case 18:
                string Left1 = LeftStr(ID,1);
                if(Left1 != "")
                {
                    switch(Left1)
                    {
                    case "0":
                        return "Skill/000.img/skill/" + ID;
                    case "8":
                        return "Skill/" + (int.Parse(ID) / 100).ToString() + ".img/skill/" + ID;
                    default:
                        return "Skill/" + (int.Parse(ID) / 10000).ToString() + ".img/skill/" + ID;
                    }
                }
                break;
            case 19:
                return "Npc/" + ID + ".img";
                break;

            case 20:
                return "Item/Pet/" + ID + ".img";
                break;
            case 21:
                if(GetNode("Item/Install/03010.img") != null)
                {
                    switch(LeftStr(ID,5))
                    {
                    case "03015":
                        return "Item/Install/" + LeftStr(ID,6) + ".img/" + ID;
                        break;
                    case "03010":
                    case "03011":
                    case "03012":
                    case "03013":
                    case "03014":
                    case "03016":
                    case "03017":
                    case "03018":
                        return "Item/Install/" + LeftStr(ID,5) + ".img/" + ID;
                        break;
                    default:
                        return "Item/Install/" + LeftStr(ID,4) + ".img/" + ID;
                        break;
                    }
                }
                else
                {
                    return "Item/Install/" + LeftStr(ID,4) + ".img/" + ID;
                }
                break;

            case 22:
                return "Character/Android/" + ID + ".img";
                break;
            case 23:
                return "Character/Mechanic/" + ID + ".img";
                break;

            case 24:
                return "Character/PetEquip/" + ID + ".img";
                break;

            case 25:
                return "Character/Bits/" + ID + ".img";
                break;

            case 26:
                return "Character/MonsterBattle/" + ID + ".img";
                break;

            case 27:
                return "Character/Totem/" + ID + ".img";
                break;
            case 29:
            case 30:
                return "Item/Consume/" + LeftStr(ID,4) + ".img/" + ID;
                break;

            case 31:
                return "Item/Etc/" + LeftStr(ID,4) + ".img/" + ID;
                break;

            }

            return null;
        }

        private void Form2_Click(object sender,EventArgs e)
        {
            ShowImageGrid.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(PluginManager.FindWz(Wz_Type.Base) == null)
            {
                MessageBox.Show("沒有開啟Base.wz");
                return;
            }
            var SelectIndex = listBox1.SelectedIndex;
            ShowImageGrid.Parent = null;
            var Graphic = this.CreateGraphics();
            var Font = new System.Drawing.Font(FontFamily.GenericSansSerif,20,FontStyle.Bold);
            Graphic.DrawString("Loading...",Font,Brushes.Black,100,100);
            // ShowImageGrid.Rows.Clear();
            // ShowImageGrid.Refresh();

            if(!HasLoaded[SelectIndex])
            {
                ImageList.Clear();
                switch(SelectIndex)
                {

                case 0:
                    LoadItem("Cash");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 1:
                    LoadItem("Consume");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 2:
                    LoadCharacter("Weapon");
                    LoadImages(ImageGrids[SelectIndex],25);
                    break;
                case 3:
                    LoadCharacter("Cap");
                    LoadImages(ImageGrids[SelectIndex],22);
                    break;
                case 4:
                    LoadCharacter("Coat");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 5:
                    LoadCharacter("Longcoat");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 6:
                    LoadCharacter("Pants");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 7:
                    LoadCharacter("Shoes");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 8:
                    LoadCharacter("Glove");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 9:
                    LoadCharacter("Ring");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 10:
                    LoadCharacter("Cape");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 11:
                    LoadCharacter("Accessory");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 12:
                    LoadCharacter("Shield");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 13:
                    LoadCharacter("TamingMob");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 14:
                    LoadCharacter("Hair");
                    LoadImages(ImageGrids[SelectIndex],28);
                    break;
                case 15:
                    LoadCharacter("Face");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 16:
                    LoadMap();
                    LoadImages(ImageGrids[SelectIndex],80);
                    break;
                case 17:
                    LoadMob();
                    LoadImages(ImageGrids[SelectIndex],60,true);
                    break;
                case 18:
                    LoadSkill();
                    LoadImages(ImageGrids[SelectIndex],22);
                    break;

                case 19:
                    LoadNpc();
                    LoadImages(ImageGrids[SelectIndex],50,true);
                    break;
                case 20:
                    LoadItem("Pet");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 21:
                    LoadItem("Install");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;

                case 22:
                    LoadCharacter("Android");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 23:
                    LoadCharacter("Mechanic");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 24:
                    LoadCharacter("PetEquip");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 25:
                    LoadCharacter("Bits");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;

                case 26:
                    LoadCharacter("MonsterBattle");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 27:
                    LoadCharacter("Totem");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 28:
                    LoadMorph();
                    LoadImages(ImageGrids[SelectIndex],50,true);
                    break;
                case 29:
                    LoadFamiliar();
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 30:
                    LoadDamageSkin();
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 31:
                    LoadItem("Etc");
                    LoadImages(ImageGrids[SelectIndex],20);
                    break;
                case 32:
                    LoadReactor();
                    LoadImages(ImageGrids[SelectIndex],60,true);
                    break;
                }
                HasLoaded[SelectIndex] = true;
                this.Focus();
            }
            //  ImageGrids[SelectIndex].ResumeLayout();
            ShowImageGrid = ImageGrids[SelectIndex];
            ShowImageGrid.Parent = this;
            ShowImageGrid.Left = 80;
            ShowImageGrid.Top = 10;
            ShowImageGrid.AllowUserToResizeColumns = false;
            ShowImageGrid.AllowUserToResizeRows = false;
            ShowImageGrid.Focus();


        }
    }


}
