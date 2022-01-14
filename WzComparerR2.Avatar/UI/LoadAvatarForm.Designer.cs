
namespace WzComparerR2.Avatar.UI
{
    partial class LoadAvatarForm
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
            this.RemoveAvatarButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // RemoveAvatarButton
            // 
            this.RemoveAvatarButton.Location = new System.Drawing.Point(34, 7);
            this.RemoveAvatarButton.Name = "RemoveAvatarButton";
            this.RemoveAvatarButton.Size = new System.Drawing.Size(89, 25);
            this.RemoveAvatarButton.TabIndex = 0;
            this.RemoveAvatarButton.Text = "刪除角色";
            this.RemoveAvatarButton.UseVisualStyleBackColor = true;
            this.RemoveAvatarButton.Visible = false;
            this.RemoveAvatarButton.Click += new System.EventHandler(this.RemoveAvatarButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(739, 560);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // LoadAvatarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 609);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RemoveAvatarButton);
            this.MaximumSize = new System.Drawing.Size(784, 656);
            this.Name = "LoadAvatarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "載入角色";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadAvatarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

       
        private System.Windows.Forms.Button RemoveAvatarButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}