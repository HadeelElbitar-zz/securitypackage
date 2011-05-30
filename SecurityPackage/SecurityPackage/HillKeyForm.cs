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
    public partial class HillKeyForm : Form
    {
        #region Variables
        int height, width;
        string PlainText;
        DataTable KeyValues;
        RichTextBox ModifiedTextBox;
        #endregion

        #region Constructors
        public HillKeyForm()
        {
            InitializeComponent();
        }
        public HillKeyForm(int size, string _PlainText, RichTextBox _ModifiedTextBox)
        {
            InitializeComponent();
            height = size;
            width = size;
            PlainText = _PlainText;
            ModifiedTextBox = _ModifiedTextBox;
        }
        #endregion

        private void HillKeyForm_Load(object sender, EventArgs e)
        {
            Height = KeyMatrixDataGrid.Height = (height + 2) * 23;
            Width = KeyMatrixDataGrid.Width = (width + 1) * 40;
            Height += 30;
            Width += 20;
            KeyValues = new DataTable();
            for (int i = 0; i < width; i++)
            {
                KeyValues.Columns.Add((i + 1).ToString());
                KeyValues.Columns[i].DefaultValue = 0;
            }
            for (int i = 0; i < height; i++)
                KeyValues.Rows.Add();
            KeyMatrixDataGrid.DataSource = KeyValues;
        }
        private void EncryptButton_Click(object sender, EventArgs e)
        {
            int[,] KeyMatrix = new int[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    KeyMatrix[i, j] = int.Parse(KeyMatrixDataGrid[j, i].Value.ToString());
            HillCipher hillCipher = new HillCipher();
            ModifiedTextBox.Text = hillCipher.Encrypt(PlainText, KeyMatrix);
        }
        private void DecryptButton_Click(object sender, EventArgs e)
        {
            int[,] KeyMatrix = new int[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    KeyMatrix[i, j] = int.Parse(KeyMatrixDataGrid[i, j].Value.ToString());
            HillCipher hillCipher = new HillCipher();
            ModifiedTextBox.Text = hillCipher.Decrypt(PlainText, KeyMatrix);
        }
    }
}