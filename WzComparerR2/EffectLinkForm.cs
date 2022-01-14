using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WzComparerR2
{
    public partial class EffectLinkForm:Form
    {
        public EffectLinkForm()
        {
            InitializeComponent();
            Instance = this;
            
        }
        public static EffectLinkForm Instance;

        private void EffectLinkForm_Load(object sender,EventArgs e)
        {
            this.FormClosing += (s,e1) =>
            {
                this.Hide();
                e1.Cancel = true;
            };

         
        }

        private void button1_Click(object sender,EventArgs e)
        {
             MainForm.ExpandTreeNode(MainForm.GetNode(button1.Text));
            this.Visible=true;
            this.BringToFront();
        }
    }
}
