
namespace WinFormsApp1
{
    partial class DB2Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DB2Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Cash = new System.Windows.Forms.TabPage();
            this.Consume = new System.Windows.Forms.TabPage();
            this.Weapon = new System.Windows.Forms.TabPage();
            this.Cap = new System.Windows.Forms.TabPage();
            this.Coat = new System.Windows.Forms.TabPage();
            this.Longcoat = new System.Windows.Forms.TabPage();
            this.Pants = new System.Windows.Forms.TabPage();
            this.Shoes = new System.Windows.Forms.TabPage();
            this.Glove = new System.Windows.Forms.TabPage();
            this.Ring = new System.Windows.Forms.TabPage();
            this.Cape = new System.Windows.Forms.TabPage();
            this.Accessory = new System.Windows.Forms.TabPage();
            this.Shield = new System.Windows.Forms.TabPage();
            this.TamingMob = new System.Windows.Forms.TabPage();
            this.Hair = new System.Windows.Forms.TabPage();
            this.Face = new System.Windows.Forms.TabPage();
            this.Map1 = new System.Windows.Forms.TabPage();
            this.Map2 = new System.Windows.Forms.TabPage();
            this.Map3 = new System.Windows.Forms.TabPage();
            this.Mob = new System.Windows.Forms.TabPage();
            this.Mob001 = new System.Windows.Forms.TabPage();
            this.Mob2 = new System.Windows.Forms.TabPage();
            this.Skill = new System.Windows.Forms.TabPage();
            this.Npc = new System.Windows.Forms.TabPage();
            this.Pet = new System.Windows.Forms.TabPage();
            this.Install = new System.Windows.Forms.TabPage();
            this.Android = new System.Windows.Forms.TabPage();
            this.Mechanic = new System.Windows.Forms.TabPage();
            this.PetEquip = new System.Windows.Forms.TabPage();
            this.Bits = new System.Windows.Forms.TabPage();
            this.MonsterBattle = new System.Windows.Forms.TabPage();
            this.Totem = new System.Windows.Forms.TabPage();
            this.Morph = new System.Windows.Forms.TabPage();
            this.Familiar = new System.Windows.Forms.TabPage();
            this.DamageSkin = new System.Windows.Forms.TabPage();
            this.Etc = new System.Windows.Forms.TabPage();
            this.Reactor = new System.Windows.Forms.TabPage();
            this.Music = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.SearchBox);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.LoadButton);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 35);
            this.panel1.TabIndex = 3;
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.SearchBox.Location = new System.Drawing.Point(308, 4);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(160, 27);
            this.SearchBox.TabIndex = 7;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBox2.Location = new System.Drawing.Point(819, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(50, 25);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.Text = "11";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownHeight = 500;
            this.comboBox4.DropDownWidth = 40;
            this.comboBox4.Font = new System.Drawing.Font("微軟正黑體", 7.8F);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.IntegralHeight = false;
            this.comboBox4.ItemHeight = 17;
            this.comboBox4.Items.AddRange(new object[] {
            "點商",
            "消耗",
            "武器",
            "帽子",
            "上衣",
            "套服",
            "褲子",
            "鞋子",
            "手套",
            "戒指",
            "披風",
            "臉飾",
            "盾牌",
            "騎寵",
            "髮型",
            "臉型",
            "地圖(1)",
            "地圖(2)",
            "地圖(3)",
            "怪物(1)",
            "怪物(2)",
            "怪物(3)",
            "技能",
            "Npc",
            "寵物",
            "椅子",
            "機器人",
            "機械",
            "寵物裝備",
            "拼圖",
            "魔獸裝備",
            "圖騰",
            "變身",
            "萌獸",
            "傷害字型",
            "其他",
            "Reactor",
            "音樂"});
            this.comboBox4.Location = new System.Drawing.Point(43, 4);
            this.comboBox4.MaxDropDownItems = 15;
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 25);
            this.comboBox4.TabIndex = 15;
            this.comboBox4.Text = "點商";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 22);
            this.label6.TabIndex = 14;
            this.label6.Text = "項目";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100",
            "105",
            "110",
            "120",
            "125",
            "130"});
            this.comboBox3.Location = new System.Drawing.Point(925, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(60, 25);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.label3.Location = new System.Drawing.Point(769, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "字體";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.SaveButton.Location = new System.Drawing.Point(636, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 27);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "儲存BIN";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.LoadButton.Location = new System.Drawing.Point(149, 4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(90, 27);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "載入WZ";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 19;
            this.comboBox1.Items.AddRange(new object[] {
            "Load From WZ",
            "Load From BIN"});
            this.comboBox1.Location = new System.Drawing.Point(490, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 27);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Load From WZ";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.label2.Location = new System.Drawing.Point(258, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "搜尋";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.label4.Location = new System.Drawing.Point(875, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "列高";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 115);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Cash);
            this.tabControl1.Controls.Add(this.Consume);
            this.tabControl1.Controls.Add(this.Weapon);
            this.tabControl1.Controls.Add(this.Cap);
            this.tabControl1.Controls.Add(this.Coat);
            this.tabControl1.Controls.Add(this.Longcoat);
            this.tabControl1.Controls.Add(this.Pants);
            this.tabControl1.Controls.Add(this.Shoes);
            this.tabControl1.Controls.Add(this.Glove);
            this.tabControl1.Controls.Add(this.Ring);
            this.tabControl1.Controls.Add(this.Cape);
            this.tabControl1.Controls.Add(this.Accessory);
            this.tabControl1.Controls.Add(this.Shield);
            this.tabControl1.Controls.Add(this.TamingMob);
            this.tabControl1.Controls.Add(this.Hair);
            this.tabControl1.Controls.Add(this.Face);
            this.tabControl1.Controls.Add(this.Map1);
            this.tabControl1.Controls.Add(this.Map2);
            this.tabControl1.Controls.Add(this.Map3);
            this.tabControl1.Controls.Add(this.Mob);
            this.tabControl1.Controls.Add(this.Mob001);
            this.tabControl1.Controls.Add(this.Mob2);
            this.tabControl1.Controls.Add(this.Skill);
            this.tabControl1.Controls.Add(this.Npc);
            this.tabControl1.Controls.Add(this.Pet);
            this.tabControl1.Controls.Add(this.Install);
            this.tabControl1.Controls.Add(this.Android);
            this.tabControl1.Controls.Add(this.Mechanic);
            this.tabControl1.Controls.Add(this.PetEquip);
            this.tabControl1.Controls.Add(this.Bits);
            this.tabControl1.Controls.Add(this.MonsterBattle);
            this.tabControl1.Controls.Add(this.Totem);
            this.tabControl1.Controls.Add(this.Morph);
            this.tabControl1.Controls.Add(this.Familiar);
            this.tabControl1.Controls.Add(this.DamageSkin);
            this.tabControl1.Controls.Add(this.Etc);
            this.tabControl1.Controls.Add(this.Reactor);
            this.tabControl1.Controls.Add(this.Music);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 506);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // Cash
            // 
            this.Cash.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.Cash.ImageIndex = 0;
            this.Cash.Location = new System.Drawing.Point(4, 35);
            this.Cash.Name = "Cash";
            this.Cash.Padding = new System.Windows.Forms.Padding(3);
            this.Cash.Size = new System.Drawing.Size(629, 467);
            this.Cash.TabIndex = 0;
            this.Cash.Text = "點商";
            this.Cash.UseVisualStyleBackColor = true;
            // 
            // Consume
            // 
            this.Consume.ImageIndex = 1;
            this.Consume.Location = new System.Drawing.Point(4, 35);
            this.Consume.Name = "Consume";
            this.Consume.Padding = new System.Windows.Forms.Padding(3);
            this.Consume.Size = new System.Drawing.Size(629, 467);
            this.Consume.TabIndex = 1;
            this.Consume.Text = "消耗";
            this.Consume.UseVisualStyleBackColor = true;
            // 
            // Weapon
            // 
            this.Weapon.ImageIndex = 2;
            this.Weapon.Location = new System.Drawing.Point(4, 35);
            this.Weapon.Name = "Weapon";
            this.Weapon.Padding = new System.Windows.Forms.Padding(3);
            this.Weapon.Size = new System.Drawing.Size(629, 467);
            this.Weapon.TabIndex = 2;
            this.Weapon.Text = "武器";
            this.Weapon.UseVisualStyleBackColor = true;
            // 
            // Cap
            // 
            this.Cap.ImageIndex = 3;
            this.Cap.Location = new System.Drawing.Point(4, 35);
            this.Cap.Name = "Cap";
            this.Cap.Padding = new System.Windows.Forms.Padding(3);
            this.Cap.Size = new System.Drawing.Size(629, 467);
            this.Cap.TabIndex = 3;
            this.Cap.Text = "帽子";
            this.Cap.UseVisualStyleBackColor = true;
            // 
            // Coat
            // 
            this.Coat.ImageIndex = 4;
            this.Coat.Location = new System.Drawing.Point(4, 35);
            this.Coat.Name = "Coat";
            this.Coat.Padding = new System.Windows.Forms.Padding(3);
            this.Coat.Size = new System.Drawing.Size(629, 467);
            this.Coat.TabIndex = 4;
            this.Coat.Text = "上衣";
            this.Coat.UseVisualStyleBackColor = true;
            // 
            // Longcoat
            // 
            this.Longcoat.ImageIndex = 5;
            this.Longcoat.Location = new System.Drawing.Point(4, 35);
            this.Longcoat.Name = "Longcoat";
            this.Longcoat.Padding = new System.Windows.Forms.Padding(3);
            this.Longcoat.Size = new System.Drawing.Size(629, 467);
            this.Longcoat.TabIndex = 5;
            this.Longcoat.Text = "套服";
            this.Longcoat.UseVisualStyleBackColor = true;
            // 
            // Pants
            // 
            this.Pants.ImageIndex = 6;
            this.Pants.Location = new System.Drawing.Point(4, 35);
            this.Pants.Name = "Pants";
            this.Pants.Padding = new System.Windows.Forms.Padding(3);
            this.Pants.Size = new System.Drawing.Size(629, 467);
            this.Pants.TabIndex = 6;
            this.Pants.Text = "褲子";
            this.Pants.UseVisualStyleBackColor = true;
            // 
            // Shoes
            // 
            this.Shoes.ImageIndex = 7;
            this.Shoes.Location = new System.Drawing.Point(4, 35);
            this.Shoes.Name = "Shoes";
            this.Shoes.Padding = new System.Windows.Forms.Padding(3);
            this.Shoes.Size = new System.Drawing.Size(629, 467);
            this.Shoes.TabIndex = 7;
            this.Shoes.Text = "鞋子";
            this.Shoes.UseVisualStyleBackColor = true;
            // 
            // Glove
            // 
            this.Glove.ImageIndex = 8;
            this.Glove.Location = new System.Drawing.Point(4, 35);
            this.Glove.Name = "Glove";
            this.Glove.Padding = new System.Windows.Forms.Padding(3);
            this.Glove.Size = new System.Drawing.Size(629, 467);
            this.Glove.TabIndex = 8;
            this.Glove.Text = "手套";
            this.Glove.UseVisualStyleBackColor = true;
            // 
            // Ring
            // 
            this.Ring.ImageIndex = 9;
            this.Ring.Location = new System.Drawing.Point(4, 35);
            this.Ring.Name = "Ring";
            this.Ring.Padding = new System.Windows.Forms.Padding(3);
            this.Ring.Size = new System.Drawing.Size(629, 467);
            this.Ring.TabIndex = 9;
            this.Ring.Text = "戒指";
            this.Ring.UseVisualStyleBackColor = true;
            // 
            // Cape
            // 
            this.Cape.ImageIndex = 10;
            this.Cape.Location = new System.Drawing.Point(4, 35);
            this.Cape.Name = "Cape";
            this.Cape.Padding = new System.Windows.Forms.Padding(3);
            this.Cape.Size = new System.Drawing.Size(629, 467);
            this.Cape.TabIndex = 10;
            this.Cape.Text = "披風";
            this.Cape.UseVisualStyleBackColor = true;
            // 
            // Accessory
            // 
            this.Accessory.ImageIndex = 11;
            this.Accessory.Location = new System.Drawing.Point(4, 35);
            this.Accessory.Name = "Accessory";
            this.Accessory.Padding = new System.Windows.Forms.Padding(3);
            this.Accessory.Size = new System.Drawing.Size(629, 467);
            this.Accessory.TabIndex = 11;
            this.Accessory.Text = "臉飾";
            this.Accessory.UseVisualStyleBackColor = true;
            // 
            // Shield
            // 
            this.Shield.ImageIndex = 12;
            this.Shield.Location = new System.Drawing.Point(4, 35);
            this.Shield.Name = "Shield";
            this.Shield.Padding = new System.Windows.Forms.Padding(3);
            this.Shield.Size = new System.Drawing.Size(629, 467);
            this.Shield.TabIndex = 12;
            this.Shield.Text = "盾牌";
            this.Shield.UseVisualStyleBackColor = true;
            // 
            // TamingMob
            // 
            this.TamingMob.ImageIndex = 13;
            this.TamingMob.Location = new System.Drawing.Point(4, 35);
            this.TamingMob.Name = "TamingMob";
            this.TamingMob.Padding = new System.Windows.Forms.Padding(3);
            this.TamingMob.Size = new System.Drawing.Size(629, 467);
            this.TamingMob.TabIndex = 13;
            this.TamingMob.Text = "騎寵";
            this.TamingMob.UseVisualStyleBackColor = true;
            // 
            // Hair
            // 
            this.Hair.ImageIndex = 14;
            this.Hair.Location = new System.Drawing.Point(4, 35);
            this.Hair.Name = "Hair";
            this.Hair.Padding = new System.Windows.Forms.Padding(3);
            this.Hair.Size = new System.Drawing.Size(629, 467);
            this.Hair.TabIndex = 14;
            this.Hair.Text = "髮型";
            this.Hair.UseVisualStyleBackColor = true;
            // 
            // Face
            // 
            this.Face.ImageIndex = 15;
            this.Face.Location = new System.Drawing.Point(4, 35);
            this.Face.Name = "Face";
            this.Face.Padding = new System.Windows.Forms.Padding(3);
            this.Face.Size = new System.Drawing.Size(629, 467);
            this.Face.TabIndex = 15;
            this.Face.Text = "臉型";
            this.Face.UseVisualStyleBackColor = true;
            // 
            // Map1
            // 
            this.Map1.ImageIndex = 16;
            this.Map1.Location = new System.Drawing.Point(4, 35);
            this.Map1.Name = "Map1";
            this.Map1.Padding = new System.Windows.Forms.Padding(3);
            this.Map1.Size = new System.Drawing.Size(629, 467);
            this.Map1.TabIndex = 16;
            this.Map1.Text = "地圖(1)";
            this.Map1.UseVisualStyleBackColor = true;
            // 
            // Map2
            // 
            this.Map2.ImageIndex = 16;
            this.Map2.Location = new System.Drawing.Point(4, 35);
            this.Map2.Name = "Map2";
            this.Map2.Padding = new System.Windows.Forms.Padding(3);
            this.Map2.Size = new System.Drawing.Size(629, 467);
            this.Map2.TabIndex = 17;
            this.Map2.Text = "地圖(2)";
            this.Map2.UseVisualStyleBackColor = true;
            // 
            // Map3
            // 
            this.Map3.ImageIndex = 16;
            this.Map3.Location = new System.Drawing.Point(4, 35);
            this.Map3.Name = "Map3";
            this.Map3.Padding = new System.Windows.Forms.Padding(3);
            this.Map3.Size = new System.Drawing.Size(629, 467);
            this.Map3.TabIndex = 18;
            this.Map3.Text = "地圖(3)";
            this.Map3.UseVisualStyleBackColor = true;
            // 
            // Mob
            // 
            this.Mob.ImageIndex = 17;
            this.Mob.Location = new System.Drawing.Point(4, 35);
            this.Mob.Name = "Mob";
            this.Mob.Padding = new System.Windows.Forms.Padding(3);
            this.Mob.Size = new System.Drawing.Size(629, 467);
            this.Mob.TabIndex = 19;
            this.Mob.Text = "怪物(1)";
            this.Mob.UseVisualStyleBackColor = true;
            // 
            // Mob001
            // 
            this.Mob001.ImageIndex = 17;
            this.Mob001.Location = new System.Drawing.Point(4, 35);
            this.Mob001.Name = "Mob001";
            this.Mob001.Padding = new System.Windows.Forms.Padding(3);
            this.Mob001.Size = new System.Drawing.Size(629, 467);
            this.Mob001.TabIndex = 20;
            this.Mob001.Text = "怪物(2)";
            this.Mob001.UseVisualStyleBackColor = true;
            // 
            // Mob2
            // 
            this.Mob2.ImageIndex = 17;
            this.Mob2.Location = new System.Drawing.Point(4, 35);
            this.Mob2.Name = "Mob2";
            this.Mob2.Padding = new System.Windows.Forms.Padding(3);
            this.Mob2.Size = new System.Drawing.Size(629, 467);
            this.Mob2.TabIndex = 21;
            this.Mob2.Text = "怪物(3)";
            this.Mob2.UseVisualStyleBackColor = true;
            // 
            // Skill
            // 
            this.Skill.ImageIndex = 18;
            this.Skill.Location = new System.Drawing.Point(4, 35);
            this.Skill.Name = "Skill";
            this.Skill.Padding = new System.Windows.Forms.Padding(3);
            this.Skill.Size = new System.Drawing.Size(629, 467);
            this.Skill.TabIndex = 22;
            this.Skill.Text = "技能";
            this.Skill.UseVisualStyleBackColor = true;
            // 
            // Npc
            // 
            this.Npc.ImageIndex = 19;
            this.Npc.Location = new System.Drawing.Point(4, 35);
            this.Npc.Name = "Npc";
            this.Npc.Padding = new System.Windows.Forms.Padding(3);
            this.Npc.Size = new System.Drawing.Size(629, 467);
            this.Npc.TabIndex = 25;
            this.Npc.Text = "Npc";
            this.Npc.UseVisualStyleBackColor = true;
            // 
            // Pet
            // 
            this.Pet.ImageIndex = 20;
            this.Pet.Location = new System.Drawing.Point(4, 35);
            this.Pet.Name = "Pet";
            this.Pet.Padding = new System.Windows.Forms.Padding(3);
            this.Pet.Size = new System.Drawing.Size(629, 467);
            this.Pet.TabIndex = 26;
            this.Pet.Text = "寵物";
            this.Pet.UseVisualStyleBackColor = true;
            // 
            // Install
            // 
            this.Install.ImageIndex = 21;
            this.Install.Location = new System.Drawing.Point(4, 35);
            this.Install.Name = "Install";
            this.Install.Padding = new System.Windows.Forms.Padding(3);
            this.Install.Size = new System.Drawing.Size(629, 467);
            this.Install.TabIndex = 27;
            this.Install.Text = "椅子";
            this.Install.UseVisualStyleBackColor = true;
            // 
            // Android
            // 
            this.Android.ImageIndex = 22;
            this.Android.Location = new System.Drawing.Point(4, 35);
            this.Android.Name = "Android";
            this.Android.Padding = new System.Windows.Forms.Padding(3);
            this.Android.Size = new System.Drawing.Size(629, 467);
            this.Android.TabIndex = 28;
            this.Android.Text = "機器人";
            this.Android.UseVisualStyleBackColor = true;
            // 
            // Mechanic
            // 
            this.Mechanic.ImageIndex = 23;
            this.Mechanic.Location = new System.Drawing.Point(4, 35);
            this.Mechanic.Name = "Mechanic";
            this.Mechanic.Padding = new System.Windows.Forms.Padding(3);
            this.Mechanic.Size = new System.Drawing.Size(629, 467);
            this.Mechanic.TabIndex = 29;
            this.Mechanic.Text = "機械";
            this.Mechanic.UseVisualStyleBackColor = true;
            // 
            // PetEquip
            // 
            this.PetEquip.ImageIndex = 24;
            this.PetEquip.Location = new System.Drawing.Point(4, 35);
            this.PetEquip.Name = "PetEquip";
            this.PetEquip.Padding = new System.Windows.Forms.Padding(3);
            this.PetEquip.Size = new System.Drawing.Size(629, 467);
            this.PetEquip.TabIndex = 30;
            this.PetEquip.Text = "寵物裝備";
            this.PetEquip.UseVisualStyleBackColor = true;
            // 
            // Bits
            // 
            this.Bits.ImageIndex = 25;
            this.Bits.Location = new System.Drawing.Point(4, 35);
            this.Bits.Name = "Bits";
            this.Bits.Padding = new System.Windows.Forms.Padding(3);
            this.Bits.Size = new System.Drawing.Size(629, 467);
            this.Bits.TabIndex = 31;
            this.Bits.Text = "拼圖";
            this.Bits.UseVisualStyleBackColor = true;
            // 
            // MonsterBattle
            // 
            this.MonsterBattle.ImageIndex = 26;
            this.MonsterBattle.Location = new System.Drawing.Point(4, 35);
            this.MonsterBattle.Name = "MonsterBattle";
            this.MonsterBattle.Padding = new System.Windows.Forms.Padding(3);
            this.MonsterBattle.Size = new System.Drawing.Size(629, 467);
            this.MonsterBattle.TabIndex = 32;
            this.MonsterBattle.Text = "魔獸裝備";
            this.MonsterBattle.UseVisualStyleBackColor = true;
            // 
            // Totem
            // 
            this.Totem.ImageIndex = 27;
            this.Totem.Location = new System.Drawing.Point(4, 35);
            this.Totem.Name = "Totem";
            this.Totem.Padding = new System.Windows.Forms.Padding(3);
            this.Totem.Size = new System.Drawing.Size(629, 467);
            this.Totem.TabIndex = 33;
            this.Totem.Text = "圖騰";
            this.Totem.UseVisualStyleBackColor = true;
            // 
            // Morph
            // 
            this.Morph.ImageIndex = 28;
            this.Morph.Location = new System.Drawing.Point(4, 35);
            this.Morph.Name = "Morph";
            this.Morph.Padding = new System.Windows.Forms.Padding(3);
            this.Morph.Size = new System.Drawing.Size(629, 467);
            this.Morph.TabIndex = 34;
            this.Morph.Text = "變身";
            this.Morph.UseVisualStyleBackColor = true;
            // 
            // Familiar
            // 
            this.Familiar.ImageIndex = 29;
            this.Familiar.Location = new System.Drawing.Point(4, 35);
            this.Familiar.Name = "Familiar";
            this.Familiar.Padding = new System.Windows.Forms.Padding(3);
            this.Familiar.Size = new System.Drawing.Size(629, 467);
            this.Familiar.TabIndex = 35;
            this.Familiar.Text = "萌獸";
            this.Familiar.UseVisualStyleBackColor = true;
            // 
            // DamageSkin
            // 
            this.DamageSkin.ImageIndex = 30;
            this.DamageSkin.Location = new System.Drawing.Point(4, 35);
            this.DamageSkin.Name = "DamageSkin";
            this.DamageSkin.Padding = new System.Windows.Forms.Padding(3);
            this.DamageSkin.Size = new System.Drawing.Size(629, 467);
            this.DamageSkin.TabIndex = 36;
            this.DamageSkin.Text = "傷害字形";
            this.DamageSkin.UseVisualStyleBackColor = true;
            // 
            // Etc
            // 
            this.Etc.ImageIndex = 31;
            this.Etc.Location = new System.Drawing.Point(4, 35);
            this.Etc.Name = "Etc";
            this.Etc.Padding = new System.Windows.Forms.Padding(3);
            this.Etc.Size = new System.Drawing.Size(629, 467);
            this.Etc.TabIndex = 37;
            this.Etc.Text = "其他";
            this.Etc.UseVisualStyleBackColor = true;
            // 
            // Reactor
            // 
            this.Reactor.ImageIndex = 32;
            this.Reactor.Location = new System.Drawing.Point(4, 35);
            this.Reactor.Name = "Reactor";
            this.Reactor.Padding = new System.Windows.Forms.Padding(3);
            this.Reactor.Size = new System.Drawing.Size(629, 467);
            this.Reactor.TabIndex = 38;
            this.Reactor.Text = "Reactor";
            this.Reactor.UseVisualStyleBackColor = true;
            // 
            // Music
            // 
            this.Music.ImageIndex = 33;
            this.Music.Location = new System.Drawing.Point(4, 35);
            this.Music.Name = "Music";
            this.Music.Size = new System.Drawing.Size(629, 467);
            this.Music.TabIndex = 39;
            this.Music.Text = "音樂";
            this.Music.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.png");
            this.imageList1.Images.SetKeyName(1, "1.png");
            this.imageList1.Images.SetKeyName(2, "2.png");
            this.imageList1.Images.SetKeyName(3, "3.png");
            this.imageList1.Images.SetKeyName(4, "4.png");
            this.imageList1.Images.SetKeyName(5, "5.png");
            this.imageList1.Images.SetKeyName(6, "6.png");
            this.imageList1.Images.SetKeyName(7, "7.png");
            this.imageList1.Images.SetKeyName(8, "8.png");
            this.imageList1.Images.SetKeyName(9, "9.png");
            this.imageList1.Images.SetKeyName(10, "10.png");
            this.imageList1.Images.SetKeyName(11, "11.png");
            this.imageList1.Images.SetKeyName(12, "12.png");
            this.imageList1.Images.SetKeyName(13, "13.png");
            this.imageList1.Images.SetKeyName(14, "14.png");
            this.imageList1.Images.SetKeyName(15, "15.png");
            this.imageList1.Images.SetKeyName(16, "16.png");
            this.imageList1.Images.SetKeyName(17, "17.png");
            this.imageList1.Images.SetKeyName(18, "18.png");
            this.imageList1.Images.SetKeyName(19, "19.png");
            this.imageList1.Images.SetKeyName(20, "20.png");
            this.imageList1.Images.SetKeyName(21, "21.png");
            this.imageList1.Images.SetKeyName(22, "22.png");
            this.imageList1.Images.SetKeyName(23, "23.png");
            this.imageList1.Images.SetKeyName(24, "24.png");
            this.imageList1.Images.SetKeyName(25, "25.png");
            this.imageList1.Images.SetKeyName(26, "26.png");
            this.imageList1.Images.SetKeyName(27, "27.png");
            this.imageList1.Images.SetKeyName(28, "28.png");
            this.imageList1.Images.SetKeyName(29, "29.png");
            this.imageList1.Images.SetKeyName(30, "30.png");
            this.imageList1.Images.SetKeyName(31, "31.png");
            this.imageList1.Images.SetKeyName(32, "32.png");
            this.imageList1.Images.SetKeyName(33, "image33.png");
            // 
            // DB2Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(637, 541);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DB2Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapleStoryDB2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Cash;
        private System.Windows.Forms.TabPage Consume;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage Weapon;
        private System.Windows.Forms.TabPage Cap;
        private System.Windows.Forms.TabPage Coat;
        private System.Windows.Forms.TabPage Longcoat;
        private System.Windows.Forms.TabPage Pants;
        private System.Windows.Forms.TabPage Shoes;
        private System.Windows.Forms.TabPage Glove;
        private System.Windows.Forms.TabPage Ring;
        private System.Windows.Forms.TabPage Cape;
        private System.Windows.Forms.TabPage Accessory;
        private System.Windows.Forms.TabPage Shield;
        private System.Windows.Forms.TabPage TamingMob;
        private System.Windows.Forms.TabPage Hair;
        private System.Windows.Forms.TabPage Face;
        private System.Windows.Forms.TabPage Map1;
        private System.Windows.Forms.TabPage Map2;
        private System.Windows.Forms.TabPage Map3;
        private System.Windows.Forms.TabPage Mob;
        private System.Windows.Forms.TabPage Mob001;
        private System.Windows.Forms.TabPage Mob2;
        private System.Windows.Forms.TabPage Skill;
        private System.Windows.Forms.TabPage Npc;
        private System.Windows.Forms.TabPage Pet;
        private System.Windows.Forms.TabPage Install;
        private System.Windows.Forms.TabPage Android;
        private System.Windows.Forms.TabPage Mechanic;
        private System.Windows.Forms.TabPage PetEquip;
        private System.Windows.Forms.TabPage Bits;
        private System.Windows.Forms.TabPage MonsterBattle;
        private System.Windows.Forms.TabPage Totem;
        private System.Windows.Forms.TabPage Morph;
        private System.Windows.Forms.TabPage Familiar;
        private System.Windows.Forms.TabPage DamageSkin;
        private System.Windows.Forms.TabPage Etc;
        private System.Windows.Forms.TabPage Reactor;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage Music;
    }
}

