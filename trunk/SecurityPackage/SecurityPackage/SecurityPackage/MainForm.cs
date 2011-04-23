using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            int[,] K = { { 17, 17, 5 }, { 21, 18, 21 }, { 2, 2, 19 } };
            //int[,] K = { { 7, 4, 2, 0 }, { 6, 3, -1, 2 }, { 4, 6, 2, 5 }, { 8, 2, -7, 1 } };
            //int[,] K = { { 7, 4, 2, 0, 6 }, { 6, 3, -1, 2, -1 }, { 4, 6, 2, 5, 4 }, { 8, 2, -7, 1, 2 }, { 9, 3, 7, 0, 5 } };
            //HillCipher p = new HillCipher("paybac", K);
            //p.Encrypt();
            //p.Decrypt();
            //RailFenceCipher p = new RailFenceCipher("advance attack two hours from nw", 3);
            //p.Encrypt();
            //p.Decrypt();
            //ColumnarCipher p = new ColumnarCipher("advance attack two hours from now", 52314);
            //p.Encrypt();
            //p.Decrypt();
            //PolyalphabeticCipher p = new PolyalphabeticCipher("advance attack two hours from now plz", "AVS", 0);
            //p.Encrypt();
            //p.Decrypt();
            //PlayFairCipher p = new PlayFairCipher("advance attack two hours from now plz", "islam");
            //p.Encrypt();
            //p.Decrypt();
            //MonoalphabeticCipher p = new MonoalphabeticCipher("hadeel hisham sadek mohamed albetar", "qwertyuiopasdfghjklzxcvbnm");
            //p.Encrypt();
            //p.Decrypt();
            CeaserCipher p = new CeaserCipher("advance attack two hours from now plz", 2);
            p.Encrypt();
            p.Decrypt();
        }

        #region Menu Items
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = "";
                OpenFileDialog File = new OpenFileDialog();
                File.Filter = "Text Files (*.txt)|*.txt";
                if (File.ShowDialog() == DialogResult.OK)
                    FilePath = File.FileName;
                FileStream FS = new FileStream(FilePath, FileMode.Open);
                StreamReader SR = new StreamReader(FS);
                OriginalTextBox.Text = SR.ReadToEnd();
            }
            catch { }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream FS = new FileStream(saveFileDialog.FileName, FileMode.CreateNew);
                StreamWriter SW = new StreamWriter(FS);
                SW.Write(ModifiedTextBox.Text);
                SW.Close();
                FS.Close();
            }
        }
        #endregion

        #region Ciphers Encryption/Decryption

        #region Ceaser Encryption/Decryption
        private void CeaserEncryptButton_Click(object sender, EventArgs e)
        {
            int Key = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if (!int.TryParse(CeaserKeyTextBox.Text, out Key))
                MessageBox.Show("Invalid key!");
            else
            {
                CeaserCipher ceaserCipher = new CeaserCipher(OriginalTextBox.Text, Key);
                ModifiedTextBox.Text = ceaserCipher.Encrypt();
            }
        }
        private void CeaserDecryptButton_Click(object sender, EventArgs e)
        {
            int Key = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to decrypt!");
            else if (!int.TryParse(CeaserKeyTextBox.Text, out Key))
                MessageBox.Show("Invalid key!");
            else
            {
                CeaserCipher ceaserCipher = new CeaserCipher();
                ceaserCipher._CipherText = OriginalTextBox.Text;
                ceaserCipher._Key = Key;
                ModifiedTextBox.Text = ceaserCipher.Decrypt();
            }
        }
        #endregion

        #region Rail Fence Encryption/Decryption
        private void RailFenceEncryptButton_Click(object sender, EventArgs e)
        {
            int depthLevel = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if (!int.TryParse(RailFenceDepthTextBox.Text, out depthLevel))
                MessageBox.Show("Invalid depth level!");
            else
            {
                RailFenceCipher railFenceCipher = new RailFenceCipher(OriginalTextBox.Text, depthLevel);
                ModifiedTextBox.Text = railFenceCipher.Encrypt();
            }
        }
        private void RailFenceDecryptButton_Click(object sender, EventArgs e)
        {
            int depthLevel = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to decrypt!");
            else if (!int.TryParse(RailFenceDepthTextBox.Text, out depthLevel))
                MessageBox.Show("Invalid depth level!");
            else
            {
                RailFenceCipher railFenceCipher = new RailFenceCipher();
                railFenceCipher._CipherText = OriginalTextBox.Text;
                railFenceCipher._DepthLevel = depthLevel;
                ModifiedTextBox.Text = railFenceCipher.Decrypt();
            }
        }
        #endregion

        #region Polyalphabetic Encryption/Decryption
        private void PolyalphabeticEncryptButton_Click(object sender, EventArgs e)
        {
            int Mode = 0;
            string Key = "";
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if ((Key = PolyalphabeticKeyTextBox.Text) == null)
                MessageBox.Show("Invalid key!");
            else
            {
                if (PolyRepeatKeyRadioButton.Checked) Mode = 1;
                PolyalphabeticCipher polyalphabeticCipher = new PolyalphabeticCipher(OriginalTextBox.Text, Key, Mode);
                ModifiedTextBox.Text = polyalphabeticCipher.Encrypt();
            }
        }
        private void PolyalphabeticDecryptButton_Click(object sender, EventArgs e)
        {
            int Mode = 0;
            string Key = "";
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if ((Key = PolyalphabeticKeyTextBox.Text) == null)
                MessageBox.Show("Invalid key!");
            else
            {
                if (PolyRepeatKeyRadioButton.Checked) Mode = 1;
                PolyalphabeticCipher polyalphabeticCipher = new PolyalphabeticCipher();
                polyalphabeticCipher._CipherText = OriginalTextBox.Text;
                polyalphabeticCipher._Key = Key;
                polyalphabeticCipher._Mode = Mode;
                ModifiedTextBox.Text = polyalphabeticCipher.Decrypt();
            }
        }
        #endregion

        #region Play Fair Encryption/Decryption
        private void PlayFairEncryptButton_Click(object sender, EventArgs e)
        {
            string Key = "";
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if ((Key = PlayFairKeyTextBox.Text) == null)
                MessageBox.Show("Invalid key!");
            else
            {
                PlayFairCipher playFairCipher = new PlayFairCipher(OriginalTextBox.Text, PlayFairKeyTextBox.Text);
                ModifiedTextBox.Text = playFairCipher.Encrypt();
            }
        }
        private void PlayFairDecryptButton_Click(object sender, EventArgs e)
        {
            string Key = "";
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to decrypt!");
            else if ((Key = PlayFairKeyTextBox.Text) == null)
                MessageBox.Show("Invalid key!");
            else
            {
                PlayFairCipher playFairCipher = new PlayFairCipher();
                playFairCipher._CipherText = OriginalTextBox.Text;
                playFairCipher._Key = PlayFairKeyTextBox.Text;
                ModifiedTextBox.Text = playFairCipher.Decrypt();
            }
        }
        #endregion

        #region Monoalphabetic Encryption/Decryption
        private void MonoalphabeticEncryptButton_Click(object sender, EventArgs e)
        {
            string Key = "";
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if ((Key = MonoalphabeticKeyTextBox.Text) == null)
                MessageBox.Show("Invalid key!");
            else
            {
                MonoalphabeticCipher monoalphabeticCipher = new MonoalphabeticCipher(OriginalTextBox.Text, Key);
                ModifiedTextBox.Text = monoalphabeticCipher.Encrypt();
            }
        }
        private void MonoalphabeticDecryptButton_Click(object sender, EventArgs e)
        {
            string Key = "";
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to decrypt!");
            else if ((Key = MonoalphabeticKeyTextBox.Text) == null)
                MessageBox.Show("Invalid key!");
            else
            {
                MonoalphabeticCipher monoalphabeticCipher = new MonoalphabeticCipher();
                monoalphabeticCipher._CipherText = OriginalTextBox.Text;
                monoalphabeticCipher._Key = Key;
                ModifiedTextBox.Text = monoalphabeticCipher.Decrypt();
            }
        }
        #endregion

        #region Hill Encryption/Decryption
        private void HillOKButton_Click(object sender, EventArgs e)
        {
            int HillSize = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt/decrypt!");
            else if (!int.TryParse(HillSizeTextBox.Text, out HillSize))
                MessageBox.Show("Invalid size!");
            else
            {
                HillKeyForm HillKeyMatrix = new HillKeyForm(HillSize, HillSize, OriginalTextBox.Text, ModifiedTextBox);
                HillKeyMatrix.Show();
            }
        }
        #endregion

        #region Columnar Encryption/Decryption
        private void ColumnarEncryptButton_Click(object sender, EventArgs e)
        {
            int Key = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to encrypt!");
            else if (!int.TryParse(ColumnarKeyTextBox.Text, out Key))
                MessageBox.Show("Invalid key!");
            else
            {
                ColumnarCipher columnarCipher = new ColumnarCipher(OriginalTextBox.Text, Key);
                ModifiedTextBox.Text = columnarCipher.Encrypt();
            }
        }
        private void ColumnarDecryptButton_Click(object sender, EventArgs e)
        {
            int Key = 0;
            if (OriginalTextBox.Text == null)
                MessageBox.Show("There is no text to decrypt!");
            else if (!int.TryParse(ColumnarKeyTextBox.Text, out Key))
                MessageBox.Show("Invalid key!");
            else
            {
                ColumnarCipher columnarCipher = new ColumnarCipher();
                columnarCipher._CipherText = OriginalTextBox.Text;
                columnarCipher._Key = Key;
                ModifiedTextBox.Text = columnarCipher.Decrypt();
            }
        }
        #endregion

        #endregion

    }
}