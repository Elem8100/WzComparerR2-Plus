
namespace WzComparerR2
{
    partial class IconsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
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
            "地圖",
            "怪物",
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
            "傷害字形",
            "其他",
            "Reactor"});
            this.listBox1.Location = new System.Drawing.Point(9, 9);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(62, 472);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // IconsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 498);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(732, 544);
            this.Name = "IconsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "圖示預覽";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Click += new System.EventHandler(this.Form2_Click);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
    }
}