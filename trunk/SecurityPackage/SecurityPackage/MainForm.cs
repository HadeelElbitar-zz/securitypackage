using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecurityPackage
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //int[,] K = { { 1, 2, 3 }, { 2, 3, 4 }, { 1, 1, 2 } };
            //int[,] K = { { 7, 4, 2, 0 }, { 6, 3, -1, 2 }, { 4, 6, 2, 5 }, { 8, 2, -7, 1 } };
            //HillCipher p = new HillCipher("hadeel", K);
            //p.Encrypt();
            //p.Decrypt();
            //RailFenceCipher p = new RailFenceCipher("advance attack two hours from nw", 3);
            //p.Encrypt();
            //p.Decrypt();
            ColumnarCipher p = new ColumnarCipher("advance attack two hours from now", 52314);
            p.Encrypt();
            p.Decrypt();
        }
    }
}
