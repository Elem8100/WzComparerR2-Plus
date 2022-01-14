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
using System.Text.RegularExpressions;

namespace WzComparerR2
{
    public partial class SearchWzForm:Form
    {
        public SearchWzForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public static SearchWzForm Instance;
        Wz_Node GetNode(string Path)
        {
            return MainForm.GetNode(Path);
        }

        int SearchType;
        string SearchText = "", SearchValue = "";
        void Dump2(Wz_Node Entry)
        {
            if(Entry != null)
            {
                switch(SearchType)
                {

                case 1: //only search text
                    if(Entry.Text.IndexOf(SearchText,StringComparison.OrdinalIgnoreCase) >= 0)
                        listBox1.Items.Add(Entry.FullPathToFile2() + "= " + Entry.GetValueEx<string>("-"));
                    break;
                case 2: //only search value
                    if(Entry.GetValueEx<string>("") == SearchValue)
                        listBox1.Items.Add(Entry.FullPathToFile2() + "= " + Entry.GetValueEx<string>("-"));
                    break;
                case 3://serch both
                    if(Entry.Text.IndexOf(SearchText,StringComparison.OrdinalIgnoreCase) >= 0 && Entry.GetValueEx<string>("") == SearchValue)
                        listBox1.Items.Add(Entry.FullPathToFile2() + "= " + Entry.GetValueEx<string>("-"));
                    break;
                }

                foreach(var E in Entry.Nodes)
                {
                    Dump2(E);
                }

            }
        }
        string Trim(string s)
        {
            return s.Trim(' ');
        }
        private void SearchWzForm_Load(object sender,EventArgs e)
        {
            this.FormClosing += (s,e1) =>
           {
               this.Hide();
               e1.Cancel = true;
           };
        }

        private void textBox1_TextChanged(object sender,EventArgs e)
        {
            SearchText = Trim(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender,EventArgs e)
        {
            SearchValue = Trim(textBox2.Text);
        }
        string LeftStr(string s,int count)
        {
            if(count > s.Length)
                count = s.Length;
            return s.Substring(0,count);
        }

        private void listBox1_SelectedIndexChanged(object sender,EventArgs e)
        {
            var SelectStr = listBox1.SelectedItem.ToString();
            var Split = Regex.Split(SelectStr,".img/");
            var Split2 = Regex.Split(SelectStr,"/");
            string Path = "";
            switch(comboBox1.SelectedIndex)
            {
            case 8:
            case 10:
                if(Split2.Length >= 4)
                {
                    if(Split2[0] == "Skill" || (Split2[0] == "Item" && Split2[1] != "Pet"))
                        Path = Split2[0] + "/" + Split2[1] + "/" + Split2[2] + "/" + Split2[3];
                    Path = Path.Replace("=","");
                    Path = Path.Replace(" -","");
                    if(GetNode(Path) != null)
                        MainForm.ExpandTreeNode(GetNode(Path));
                }
                break;

            default:
                if(Split.Length >= 1)
                {
                    Path = Split[0] + ".img";
                    Path = Path.Replace("=","");
                    Path = Path.Replace(" -","");
                    if(GetNode(Path) != null)
                        MainForm.ExpandTreeNode(GetNode(Path));
                }
                break;
            }

        }

        private void button1_Click(object sender,EventArgs e)
        {
            if(SearchText.Length == 1 && !SearchText.All(Char.IsNumber))
            {

                return;
            }

            if(SearchText == "" && SearchValue == "")
                return;

            listBox1.Items.Clear();
            listBox1.Refresh();
            if(SearchText != "" && SearchValue == "")
                SearchType = 1;
            if(SearchText == "" && SearchValue != "")
                SearchType = 2;
            if(SearchText != "" && SearchValue != "")
                SearchType = 3;

            var Graphic = listBox1.CreateGraphics();
            var Font = new System.Drawing.Font(FontFamily.GenericSansSerif,20,FontStyle.Bold);
            Graphic.DrawString("Loading...",Font,Brushes.Black,100,100);

         //   var t = Environment.TickCount;
            listBox1.BeginUpdate();

            switch(comboBox1.SelectedIndex)
            {
            case 0:
                 foreach(var Iter in GetNode("Character/Weapon").Nodes)
                { 
                    Dump2(GetNode("Character/Weapon/" + Iter.Text));

                }
                break;

            case 1:
                foreach(var Iter in GetNode("Character/Accessory").Nodes)
                    Dump2(GetNode("Character/Accessory/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Bits").Nodes)
                    Dump2(GetNode("Character/Bits/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Cap").Nodes)
                    Dump2(GetNode("Character/Cap/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Cape").Nodes)
                    Dump2(GetNode("Character/Cape/" + Iter.Text));
                break;

            case 2:
                foreach(var Iter in GetNode("Character/Coat").Nodes)
                    Dump2(GetNode("Character/Coat/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Dragon").Nodes)
                    Dump2(GetNode("Character/Dragon/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Face").Nodes)
                    Dump2(GetNode("Character/Face/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Glove").Nodes)
                    Dump2(GetNode("Character/Glove/" + Iter.Text));
                if(GetNode("Character/Familiar") != null)
                {
                    foreach(var Iter in GetNode("Character/Familiar").Nodes)
                        Dump2(GetNode("Character/Familiar/" + Iter.Text));
                }
                break;
            case 3:
                foreach(var Iter in GetNode("Character/Hair").Nodes)
                    Dump2(GetNode("Character/Hair/" + Iter.Text));
                break;

            case 4:
                foreach(var Iter in GetNode("Character/Longcoat").Nodes)
                    Dump2(GetNode("Character/Longcoat/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Mechanic").Nodes)
                    Dump2(GetNode("Character/Mechainc/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Pants").Nodes)
                    Dump2(GetNode("Character/Pants/" + Iter.Text));
                foreach(var Iter in GetNode("Character/PetEquip").Nodes)
                    Dump2(GetNode("Character/PetEquip/" + Iter.Text));
                break;

            case 5:
                foreach(var Iter in GetNode("Character/Ring").Nodes)
                    Dump2(GetNode("Character/Ring/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Shield").Nodes)
                    Dump2(GetNode("Character/Shield/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Shoes").Nodes)
                    Dump2(GetNode("Character/Shoes/" + Iter.Text));
                foreach(var Iter in GetNode("Character/TamingMob").Nodes)
                    Dump2(GetNode("Character/TamingMob/" + Iter.Text));
                foreach(var Iter in GetNode("Character/Totem").Nodes)
                    Dump2(GetNode("Character/Totem/" + Iter.Text));
                break;

            case 6:
                foreach(var Iter in GetNode("Etc").Nodes)
                    Dump2(GetNode("Etc/" + Iter.Text));
                break;


            case 7:
                foreach(var Iter in GetNode("String/Mob.img").Nodes)
                {
                    var ID = Iter.Text.PadLeft(7,'0');
                    Dump2(GetNode("Mob/" + ID + ".img"));
                }
                break;

            case 8:
                foreach(var Iter in GetNode("String/Skill.img").Nodes)
                    Dump2(GetNode("Skill/" + Iter.Text + ".img"));
                break;

            case 9:
                foreach(var Iter in GetNode("Npc").Nodes)
                    Dump2(GetNode("Npc/" + Iter.Text));
                break;

            case 10:
                foreach(var Iter in GetNode("Item/Cash").Nodes)
                    Dump2(GetNode("Item/Cash/" + Iter.Text));
                foreach(var Iter in GetNode("Item/Consume").Nodes)
                    Dump2(GetNode("Item/Consume/" + Iter.Text));
                foreach(var Iter in GetNode("Item/Etc").Nodes)
                    Dump2(GetNode("Item/Etc/" + Iter.Text));
                foreach(var Iter in GetNode("Item/Install").Nodes)
                    Dump2(GetNode("Item/Install/" + Iter.Text));
                foreach(var Iter in GetNode("Item/Pet").Nodes)
                    Dump2(GetNode("Item/Pet/" + Iter.Text));
                break;
            case 11:
                foreach(var Dir in GetNode("Map/Map").Nodes)
                {
                    foreach(var img in Dir.Nodes)
                    {
                        var ID = img.Text;
                        Dump2(GetNode("Map/Map/Map" + LeftStr(ID,1) + "/" + img.Text));
                    }
                }
                break;


            case 12:
                foreach(var Iter in GetNode("Map/Obj").Nodes)
                    Dump2(GetNode("Map/Obj/" + Iter.Text));
                break;
            case 13:
                foreach(var Iter in GetNode("Map/Tile").Nodes)
                    Dump2(GetNode("Map/Tile/" + Iter.Text));
                break;

            case 14:
                foreach(var Iter in GetNode("Map/Back").Nodes)
                    Dump2(GetNode("Map/Back/" + Iter.Text));
                break;
            case 15:
                foreach(var Iter in GetNode("Morph").Nodes)
                    Dump2(GetNode("Morph/" + Iter.Text));
                break;
            case 16:
                foreach(var Iter in GetNode("Reactor").Nodes)
                    Dump2(GetNode("Reactor/" + Iter.Text));
                break;
            case 17:
                foreach(var Iter in GetNode("Effect").Nodes)
                    Dump2(GetNode("Effect/" + Iter.Text));
                break;
            case 18:
                foreach(var Iter in GetNode("UI").Nodes)
                    Dump2(GetNode("UI/" + Iter.Text));
                break;
            }

            listBox1.EndUpdate();

          //  Text = (Environment.TickCount - t).ToString();


        }
    }
}
