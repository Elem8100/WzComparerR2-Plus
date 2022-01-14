using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WzComparerR2.WzLib;
using WzComparerR2.Common;
using WzComparerR2.PluginBase;
namespace WzComparerR2
{
    public partial class ImageViewerForm:Form
    {
        public ImageViewerForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public static ImageViewerForm Instance;
        List<(Bitmap, string)> ImageList;
        Wz_Node GetNode(string Path)
        {
            return MainForm.GetNode(Path);
        }

        string LeftStr(string s,int count)
        {
            if(count > s.Length)
                count = s.Length;
            return s.Substring(0,count);
        }
        void LoadImages(DataGridView dataViewImages,int GridSize,bool Resize = false)
        {
            //dataViewImages.Rows.Clear();
            //dataViewImages.Columns.Clear();
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
                        image = IconsForm.ResizeImage2(image,80,80);
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
        private void ImageViewerForm_Load(object sender,EventArgs e)
        {

            this.FormClosing += (s,e1) =>
           {
               this.Hide();
               e1.Cancel = true;
           };


            ImageList = new List<(Bitmap, string)>();

            foreach(var Iter in MainForm.TreeNode.Nodes)
            {
                var Text1 = LeftStr(Iter.Text,2);
                switch(Text1)
                {
                case "Ma":
                    foreach(var Iter2 in Iter.Nodes)
                    {
                        if(Iter2.Text == "Obj" || Iter2.Text == "Tile" || Iter2.Text == "Back")
                        {
                            foreach(var Iter3 in Iter2.Nodes)
                            {
                                var L1 = Iter3.FullPathToFile;
                                L1 = L1.Replace(Iter.Text,"Map");
                                listBox1.Items.Add(L1);

                            }
                        }
                    }

                    break;
                case "Sk":
                    foreach(var Iter2 in Iter.Nodes)
                    {
                        var L1 = Iter2.FullPathToFile;
                        L1 = L1.Replace(Iter.Text,"Skill");
                        listBox1.Items.Add(L1);
                    }

                    break;
                case "Ef":
                case "UI":
                    foreach(var Iter2 in Iter.Nodes)
                    {
                        listBox1.Items.Add(Iter2.FullPathToFile);
                    }
                    break;
                }

            }
        }

        void DumpPngs(Wz_Node Entry)
        {
            if(Entry != null)
            {
                if(Entry.Value is Wz_Png || Entry.Value is Wz_Uol)
                    if(Entry.Text != "\\")
                        if(GetNode(Entry.FullPathToFile2()).Value is Wz_Png)
                            ImageList.Add((GetNode(Entry.FullPathToFile2()).ExtractPng(), Entry.FullPathToFile2()));
                foreach(var E in Entry.Nodes)
                    if(!(E.Value is Wz_Image))
                        DumpPngs(E);
            }
        }
         string LPath;
        private void listBox1_SelectedIndexChanged(object sender,EventArgs e)
        {
            label1.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            var Graphic = dataGridView1.CreateGraphics();
            var Font = new System.Drawing.Font(FontFamily.GenericSansSerif,20,FontStyle.Bold);
            Graphic.DrawString("Loading...",Font,Brushes.Black,100,100);
            ImageList.Clear();
            DumpPngs(GetNode(listBox1.SelectedItem.ToString()));
            LoadImages(dataGridView1,80,true);
            if(ImageList.Count == 0)
                dataGridView1.Refresh();
            MainForm.ExpandTreeNode(GetNode(listBox1.SelectedItem.ToString()));
            LPath=listBox1.SelectedItem.ToString();
            LPath=LPath.Replace("\\",".");

        }

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            var Path = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText;
            if(GetNode(Path) != null)
            {
                label1.Text = Path;
                MainForm.ExpandTreeNode(GetNode(Path));
            }
        }

        private void button1_Click(object sender,EventArgs e)
        {
            if(label1.Text == "")
                return;
            var dlg = new FolderBrowserDialog();
            dlg.SelectedPath = System.Environment.CurrentDirectory;
            dlg.Description = "選擇儲存路徑";
            if((dlg.ShowDialog(new Form() { TopMost = true }) != DialogResult.OK))
                return;
            var Path1 = label1.Text;
            var Path2 = Path1;
            Path2 = Path2.Replace("/",".");
            if(GetNode(label1.Text).Value is Wz_Png)
                GetNode(label1.Text).ExtractPng().Save(dlg.SelectedPath + "\\" + Path2 + ".png");
        }
       
        void DumpPngs(string FolderName,Wz_Node Entry)
        {
            if(Entry != null)
            {
                if(Entry.Value is Wz_Png || Entry.Value is Wz_Uol)
                    GetNode(Entry.FullPathToFile2()).ExtractPng().Save(FolderName + "\\" + Entry.FullPathToFile2D() + ".png");
                foreach(var E in Entry.Nodes)
                    if(!(E.Value is Wz_Image))
                        DumpPngs(FolderName,E);
            }
        }
        private void button2_Click(object sender,EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            dlg.SelectedPath = System.Environment.CurrentDirectory;
            dlg.Description = "選擇儲存路徑";
            if((dlg.ShowDialog(new Form() { TopMost = true }) != DialogResult.OK))
                return;
            DumpPngs(dlg.SelectedPath,GetNode(listBox1.SelectedItem.ToString()));

        }
    }



}
