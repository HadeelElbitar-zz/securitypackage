using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Numerics;
using System.Threading;

namespace SecurityPackage
{
    public partial class MainForm : Form
    {
        #region Constructor & Form Load

        /// <summary>
        /// Makes a new instance of MainForm and starts the splash screen
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Thread SplashScreenThread = new Thread(new ThreadStart(SplashScreen));
            SplashScreenThread.Start();
            Thread.Sleep(2000);
            SplashScreenThread.Abort();
        }

        /// <summary>
        /// Runs the splash screen form
        /// </summary>
        private void SplashScreen()
        {
            Application.Run(new SplashScreenForm());
        }

        #endregion

        #region Menu Items

        /// <summary>
        /// Reads a file from the specified path into the OriginalTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Writes a file from ModifiedTextBox to the sepcified path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Encrypts file, image, video & audio files using DES algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncryptFile();
        }

        /// <summary>
        /// Decrypts file, image, video & audio files using DES algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileDecryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecryptFile();
        }

        #endregion

        #region Controls

        /// <summary>
        /// Make a new instance of Button Class with the specified option
        /// </summary>
        /// <param name="ButtonText">The text to be written on the Button</param>
        /// <returns>The button</returns>
        Button DefineButton(string ButtonText)
        {
            Button button = new Button();
            button.Text = ButtonText;
            button.Size = new Size(270, 30);
            button.BackColor = Color.Transparent;
            button.Dock = DockStyle.Top;
            return button;
        }

        /// <summary>
        /// Make a new instance of Label Class with the specified option
        /// </summary>
        /// <param name="ButtonText">The text to be written on the Label</param>
        /// <returns>The label</returns>
        Label DefineLabel(string LabelText)
        {
            Label label = new Label();
            label.Text = LabelText;
            label.AutoSize = true;
            label.ForeColor = Color.LightSeaGreen;
            label.Dock = DockStyle.Top;
            return label;
        }

        /// <summary>
        /// Make a new instance of GroupBox Class with the specified option
        /// </summary>
        /// <param name="ButtonText">The text to be written on the GroupBox</param>
        /// <returns>The GroupBox</returns>
        GroupBox DefineGroupBox(string groupBoxText, Size size)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = groupBoxText;
            groupBox.Size = size;
            groupBox.ForeColor = Color.LightSeaGreen;
            groupBox.Dock = DockStyle.Top;
            return groupBox;
        }

        /// <summary>
        /// Make a new instance of TextBox Class with the specified option
        /// </summary>
        /// <returns>The textbox</returns>
        TextBox DefineTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Top;
            return textBox;
        }

        /// <summary>
        /// Make a new instance of RadioButton Class with the specified option
        /// </summary>
        /// <param name="ButtonText">The text to be written on the RadioButton</param>
        /// <returns>The RadioButton</returns>
        RadioButton DefineRadioButton(string RadioButtonText)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Text = RadioButtonText;
            radioButton.Dock = DockStyle.Top;
            return radioButton;
        }

        #endregion

        #region File, Image, Video, Audio Encryption/Decryption

        /// <summary>
        /// Encrypts file, image, audio, video files using DES algorithm
        /// </summary>
        void EncryptFile()
        {
            try
            {
                #region Get File Path
                Stream stream = null;
                string path = "";
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Filter = "All Files(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    stream = fileDialog.OpenFile();
                    path = fileDialog.FileName;
                }
                #endregion

                #region If file is susseccfully read
                if (stream != null)
                {
                    #region Read File
                    byte[] FileBuffer = new byte[stream.Length];
                    int i = stream.Read(FileBuffer, 0, FileBuffer.Length);
                    stream.Close();
                    #endregion

                    if (i > 0)
                    {
                        #region Initializations
                        byte[] FileBytes = new byte[8];
                        byte[] EncryptedFileBuffer = new byte[i];
                        DES des = new DES();
                        BaseConversion baseConversion = new BaseConversion();
                        int length = i / 8;
                        string Key = "123";
                        #endregion

                        #region Encryption

                        int j = 0;
                        for (; j < length; j++)
                        {
                            for (int k = 0; k < 8; k++)
                                FileBytes[k] = FileBuffer[j * 8 + k];
                            FileBytes = des.Encrypt(FileBytes, Key);
                            for (int k = 0; k < 8; k++)
                                EncryptedFileBuffer[j * 8 + k] = FileBytes[k];
                        }
                        if (i % 8 != 0)
                        {
                            int k = 0;
                            j *= 8;
                            int h = j;
                            FileBytes = new byte[i - j];
                            for (; j < i; j++)
                                FileBytes[k++] = FileBuffer[j];
                            FileBytes = des.Encrypt(FileBytes, Key);
                            k = 0;
                            for (j = h; j < i; j++)
                                EncryptedFileBuffer[j] = FileBytes[k++];
                        }
                        #endregion

                        #region Write File
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            stream = new FileStream(saveFileDialog.FileName, FileMode.CreateNew, FileAccess.Write);
                        stream.Write(EncryptedFileBuffer, 0, EncryptedFileBuffer.Length);
                        stream.Close();
                        #endregion
                    }
                }
                #endregion
            }
            catch { }
        }

        /// <summary>
        /// Decrypts file, image, audio, video files using DES algorithm
        /// </summary>
        void DecryptFile()
        {
            try
            {
                #region Get File Path
                Stream stream = null;
                string path = "";
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Filter = "All Files(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    stream = fileDialog.OpenFile();
                    path = fileDialog.FileName;
                }
                #endregion

                #region If file is susseccfully read
                if (stream != null)
                {
                    #region Read File
                    byte[] FileBuffer = new byte[stream.Length];
                    int i = stream.Read(FileBuffer, 0, FileBuffer.Length);
                    stream.Close();
                    #endregion

                    if (i > 0)
                    {
                        #region Initializations
                        byte[] FileBytes = new byte[8];
                        byte[] EncryptedFileBuffer = new byte[i];
                        DES des = new DES();
                        BaseConversion baseConversion = new BaseConversion();
                        int length = i / 8;
                        string Key = "123";
                        #endregion

                        #region Decryption

                        int j = 0;
                        for (; j < length; j++)
                        {
                            for (int k = 0; k < 8; k++)
                                FileBytes[k] = FileBuffer[j * 8 + k];
                            FileBytes = des.Decrypt(FileBytes, Key);
                            for (int k = 0; k < 8; k++)
                                EncryptedFileBuffer[j * 8 + k] = FileBytes[k];
                        }
                        if (i % 8 != 0)
                        {
                            int k = 0;
                            j *= 8;
                            int h = j;
                            FileBytes = new byte[i - j];
                            for (; j < i; j++)
                                FileBytes[k++] = FileBuffer[j];
                            FileBytes = des.Decrypt(FileBytes, Key);
                            k = 0;
                            for (j = h; j < i; j++)
                                EncryptedFileBuffer[j] = FileBytes[k++];
                        }
                        #endregion

                        #region Write File
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            stream = new FileStream(saveFileDialog.FileName, FileMode.CreateNew, FileAccess.Write);
                        stream.Write(EncryptedFileBuffer, 0, EncryptedFileBuffer.Length);
                        stream.Close();
                        #endregion
                    }
                }
                #endregion
            }
            catch { }
        }

        #endregion

        #region Encryption / Decryption

        #region Classical Encryption Techniques

        #region Substitution Techniques

        #region Ceaser Encryption/Decryption
        private void CeaserCipherNodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Ceaser Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { CeaserEncryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { CeaserDecryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };


            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void CeaserEncryptButton_Click(object sender, EventArgs e, int Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                CeaserCipher ceaserCipher = new CeaserCipher();
                ModifiedTextBox.Text = ceaserCipher.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void CeaserDecryptButton_Click(object sender, EventArgs e, int Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                CeaserCipher ceaserCipher = new CeaserCipher();
                ModifiedTextBox.Text = ceaserCipher.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #region Monoalphabetic Encryption/Decryption
        private void MonoalphabeticCipherNodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Monoalphabetic Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { MonoalphabeticEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { MonoalphabeticDecryptButton_Click(sender1, e1, KeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void MonoalphabeticEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                MonoalphabeticCipher monoalphabeticCipher = new MonoalphabeticCipher();
                ModifiedTextBox.Text = monoalphabeticCipher.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void MonoalphabeticDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                MonoalphabeticCipher monoalphabeticCipher = new MonoalphabeticCipher();
                ModifiedTextBox.Text = monoalphabeticCipher.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #region Play Fair Encryption/Decryption
        private void PlayfairCipherNodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Play Fair Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { PlayFairEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { PlayFairDecryptButton_Click(sender1, e1, KeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void PlayFairEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                PlayFairCipher playFairCipher = new PlayFairCipher();
                ModifiedTextBox.Text = playFairCipher.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void PlayFairDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                PlayFairCipher playFairCipher = new PlayFairCipher();
                ModifiedTextBox.Text = playFairCipher.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #region Hill Encryption/Decryption
        private void HillCipherNodeClicked()
        {
            TextBox KeySizeText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Hill Key Size", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeySizeText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { HillEncryptButton_Click(sender1, e1, int.Parse(KeySizeText.Text)); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { HillDecryptButton_Click(sender1, e1, int.Parse(KeySizeText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void HillEncryptButton_Click(object sender, EventArgs e, int KeySize)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                HillKeyForm HillKeyMatrix = new HillKeyForm(KeySize, OriginalTextBox.Text, ModifiedTextBox);
                HillKeyMatrix.Show();
            }
        }
        void HillDecryptButton_Click(object sender, EventArgs e, int KeySize)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                HillKeyForm HillKeyMatrix = new HillKeyForm(KeySize, OriginalTextBox.Text, ModifiedTextBox);
                HillKeyMatrix.Show();
            }
        }
        #endregion

        #region Polyalphabetic Encryption/Decryption
        private void PolyalphabeticCipherNodeClicked()
        {
            Label KeyLabel = DefineLabel("Polyalphabetic Key");
            TextBox KeyText = DefineTextBox();

            GroupBox KeyModeGroupBox = DefineGroupBox("Key Mode", new Size(260, 45));
            RadioButton AutoKeyRadioButton = DefineRadioButton("Auto Key");
            AutoKeyRadioButton.Checked = true;
            RadioButton RepeatKeyRadioButton = DefineRadioButton("Repeat Key");
            KeyModeGroupBox.Controls.Add(RepeatKeyRadioButton);
            KeyModeGroupBox.Controls.Add(AutoKeyRadioButton);
            KeyModeGroupBox.AutoSize = true;

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { PolyalphabeticEncryptButton_Click(sender1, e1, KeyText.Text, RepeatKeyRadioButton.Checked); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { PolyalphabeticDecryptButton_Click(sender1, e1, KeyText.Text, RepeatKeyRadioButton.Checked); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyModeGroupBox);
            CipherControlPanel.Controls.Add(KeyText);
            CipherControlPanel.Controls.Add(KeyLabel);
        }
        void PolyalphabeticEncryptButton_Click(object sender, EventArgs e, string Key, bool KeyMode)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                PolyalphabeticCipher polyalphabeticCipher = new PolyalphabeticCipher();
                if (KeyMode)
                    ModifiedTextBox.Text = polyalphabeticCipher.Encrypt(OriginalTextBox.Text, Key, 0);
                else
                    ModifiedTextBox.Text = polyalphabeticCipher.Encrypt(OriginalTextBox.Text, Key, 1);
            }
        }
        void PolyalphabeticDecryptButton_Click(object sender, EventArgs e, string Key, bool KeyMode)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                PolyalphabeticCipher polyalphabeticCipher = new PolyalphabeticCipher();
                if (KeyMode)
                    ModifiedTextBox.Text = polyalphabeticCipher.Decrypt(OriginalTextBox.Text, Key, 0);
                else
                    ModifiedTextBox.Text = polyalphabeticCipher.Decrypt(OriginalTextBox.Text, Key, 1);
            }
        }
        #endregion

        #endregion

        #region Transposition Techniques

        #region Rail Fence Encryption/Decryption
        private void RailFenceNodeClicked()
        {
            TextBox DepthLevelText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Rail Fence Depth Level", new Size(260, 45));
            KeyGroupBox.Controls.Add(DepthLevelText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RailFenceEncryptButton_Click(sender1, e1, (int.Parse(DepthLevelText.Text))); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RailFenceDecryptButton_Click(sender1, e1, (int.Parse(DepthLevelText.Text))); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void RailFenceEncryptButton_Click(object sender, EventArgs e, int DepthLevel)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                RailFenceCipher railFenceCipher = new RailFenceCipher();
                ModifiedTextBox.Text = railFenceCipher.Encrypt(OriginalTextBox.Text, DepthLevel);
            }
        }
        void RailFenceDecryptButton_Click(object sender, EventArgs e, int DepthLevel)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                RailFenceCipher railFenceCipher = new RailFenceCipher();
                ModifiedTextBox.Text = railFenceCipher.Decrypt(OriginalTextBox.Text, DepthLevel);
            }
        }
        #endregion

        #region Columnar Encryption/Decryption
        private void ColumnarCipherNodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Columnar Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { ColumnarEncryptButton_Click(sender1, e1, (KeyText.Text)); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { ColumnarDecryptButton_Click(sender1, e1, (KeyText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void ColumnarEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                ColumnarCipher ColumnarCipher = new ColumnarCipher();
                ModifiedTextBox.Text = ColumnarCipher.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void ColumnarDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                ColumnarCipher ColumnarCipher = new ColumnarCipher();
                ModifiedTextBox.Text = ColumnarCipher.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #endregion

        #endregion

        #region Block Cipher

        #region DES Encryption/Decryption
        private void DESNodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("DES Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { DESEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { DESDecryptButton_Click(sender1, e1, KeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void DESEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                DES des = new DES();
                ModifiedTextBox.Text = des.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void DESDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                DES des = new DES();
                ModifiedTextBox.Text = des.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #region Double DES Encryption/Decryption
        private void DoubleDESNodeClicked()
        {
            Label FirstKeyLabel = DefineLabel("First Key");
            TextBox FirstKeyText = DefineTextBox();
            Label SecondKeyLabel = DefineLabel("Second Key");
            TextBox SecondKeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("", new Size(260, 90));
            KeyGroupBox.AutoSize = true;
            KeyGroupBox.Controls.Add(SecondKeyText);
            KeyGroupBox.Controls.Add(SecondKeyLabel);
            KeyGroupBox.Controls.Add(FirstKeyText);
            KeyGroupBox.Controls.Add(FirstKeyLabel);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { DoubleDESEncryptButton_Click(sender1, e1, FirstKeyText.Text, SecondKeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { DoubleDESDecryptButton_Click(sender1, e1, FirstKeyText.Text, SecondKeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void DoubleDESEncryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                DES des = new DES();
                ModifiedTextBox.Text = des.Encrypt(des.Encrypt(OriginalTextBox.Text, FirstKeyText), SecondKeyText);
            }
        }
        void DoubleDESDecryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                DES des = new DES();
                ModifiedTextBox.Text = des.Decrypt(des.Decrypt(OriginalTextBox.Text, SecondKeyText), FirstKeyText);
            }
        }
        #endregion

        #region Triple DES Encryption/Decryption
        private void TripleDESNodeClicked()
        {
            Label FirstKeyLabel = DefineLabel("First Key");
            TextBox FirstKeyText = DefineTextBox();
            Label SecondKeyLabel = DefineLabel("Second Key");
            TextBox SecondKeyText = DefineTextBox();
            Label ThirdKeyLabel = DefineLabel("Third Key");
            TextBox ThirdKeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("", new Size(260, 90));
            KeyGroupBox.AutoSize = true;
            KeyGroupBox.Controls.Add(ThirdKeyText);
            KeyGroupBox.Controls.Add(ThirdKeyLabel);
            KeyGroupBox.Controls.Add(SecondKeyText);
            KeyGroupBox.Controls.Add(SecondKeyLabel);
            KeyGroupBox.Controls.Add(FirstKeyText);
            KeyGroupBox.Controls.Add(FirstKeyLabel);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { TripleDESEncryptButton_Click(sender1, e1, FirstKeyText.Text, SecondKeyText.Text, ThirdKeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { TripleDESDecryptButton_Click(sender1, e1, FirstKeyText.Text, SecondKeyText.Text, ThirdKeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void TripleDESEncryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText, string ThirdKeyText)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                DES des = new DES();
                ModifiedTextBox.Text = des.Encrypt(des.Encrypt(des.Encrypt(OriginalTextBox.Text, FirstKeyText), SecondKeyText), ThirdKeyText);
            }
        }
        void TripleDESDecryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText, string ThirdKeyText)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                DES des = new DES();
                ModifiedTextBox.Text = des.Decrypt(des.Decrypt(des.Decrypt(OriginalTextBox.Text, ThirdKeyText), SecondKeyText), FirstKeyText);
            }
        }
        #endregion

        #region AES Encryption/Decryption
        private void AESNodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("AES Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { AESEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { AESDecryptButton_Click(sender1, e1, KeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void AESEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                AES aes = new AES();
                ModifiedTextBox.Text = aes.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void AESDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                AES aes = new AES();
                ModifiedTextBox.Text = aes.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #endregion

        #region Stream Cipher

        #region RC4
        private void RC4NodeClicked()
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("RC4 Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RC4EncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RC4DecryptButton_Click(sender1, e1, KeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(KeyGroupBox);
        }
        void RC4EncryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                RC4 rc4 = new RC4();
                ModifiedTextBox.Text = rc4.Encrypt(OriginalTextBox.Text, Key);
            }
        }
        void RC4DecryptButton_Click(object sender, EventArgs e, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                RC4 rc4 = new RC4();
                ModifiedTextBox.Text = rc4.Decrypt(OriginalTextBox.Text, Key);
            }
        }
        #endregion

        #endregion

        #region Public-Key Cryptosystems

        #region RSA Encryption/Decryption
        private void RSANodeClicked()
        {
            Label FirstNumberLabel = DefineLabel("First Number (p)");
            TextBox FirstNumberText = DefineTextBox();
            Label SecondNumberLabel = DefineLabel("Second Number (q)");
            TextBox SecondNumberText = DefineTextBox();
            Label KeyLabel = DefineLabel("Key (e)");
            TextBox KeyText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(300, 90));
            InputGroupBox.AutoSize = true;
            InputGroupBox.Controls.Add(KeyText);
            InputGroupBox.Controls.Add(KeyLabel);
            InputGroupBox.Controls.Add(SecondNumberText);
            InputGroupBox.Controls.Add(SecondNumberLabel);
            InputGroupBox.Controls.Add(FirstNumberText);
            InputGroupBox.Controls.Add(FirstNumberLabel);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RSAEncryptButton_Click(sender1, e1, FirstNumberText.Text, SecondNumberText.Text, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RSADecryptButton_Click(sender1, e1, FirstNumberText.Text, SecondNumberText.Text, KeyText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void RSAEncryptButton_Click(object sender, EventArgs e, string p, string q, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                RSA rsa = new RSA();
                ModifiedTextBox.Text = rsa.Encrypt(OriginalTextBox.Text, p, q, Key);
            }
        }
        void RSADecryptButton_Click(object sender, EventArgs e, string p, string q, string Key)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                RSA rsa = new RSA();
                ModifiedTextBox.Text = rsa.Decrypt(OriginalTextBox.Text, p, q, Key);
            }
        }
        #endregion

        #region Elliptic Curve
        private void KeyCryptosystemEllipticCurveNodeClicked()
        {
            Label aLabel = DefineLabel("a");
            TextBox aText = DefineTextBox();
            Label BaseLabel = DefineLabel("Base (p)");
            TextBox BaseText = DefineTextBox();
            Label GLabel = DefineLabel("Point of Curve (G)");
            TextBox GText = DefineTextBox();
            Label PublicKeyBLabel = DefineLabel("Public Key (B)");
            TextBox PublicKeyBText = DefineTextBox();
            Label kLabel = DefineLabel("k");
            TextBox kText = DefineTextBox();

            GroupBox InputGroupBox = DefineGroupBox("", new Size(300, 90));
            InputGroupBox.AutoSize = true;
            InputGroupBox.Controls.Add(kText);
            InputGroupBox.Controls.Add(kLabel);
            InputGroupBox.Controls.Add(GText);
            InputGroupBox.Controls.Add(GLabel);
            InputGroupBox.Controls.Add(PublicKeyBText);
            InputGroupBox.Controls.Add(PublicKeyBLabel);
            InputGroupBox.Controls.Add(BaseText);
            InputGroupBox.Controls.Add(BaseLabel);
            InputGroupBox.Controls.Add(aText);
            InputGroupBox.Controls.Add(aLabel);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            InputOutputConversion IOConversion = new InputOutputConversion();
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { PublicKeyEllipticCurveEncryptButton_Click(sender1, e1, int.Parse(aText.Text), int.Parse(BaseText.Text), IOConversion.StringToPoint(GText.Text), PublicKeyBText.Text, int.Parse(kText.Text)); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { PublicKeyEllipticCurveDecryptButton_Click(sender1, e1, int.Parse(aText.Text), int.Parse(BaseText.Text), PublicKeyBText.Text); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(DecryptButton);
            CipherControlPanel.Controls.Add(EncryptButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void PublicKeyEllipticCurveEncryptButton_Click(object sender, EventArgs e, int a, int Base, Point G, string BPublicKey, int k)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                EllipticCurve ellipticCurve = new EllipticCurve();
                InputOutputConversion IOConversion = new InputOutputConversion();
                Point[] point = ellipticCurve.Encrypt(a, Base, G, IOConversion.StringToPoint(OriginalTextBox.Text), IOConversion.StringToPoint(BPublicKey), k);
                ModifiedTextBox.Text = IOConversion.PointToString(point[0]) + '\n' + IOConversion.PointToString(point[1]);
            }
        }
        void PublicKeyEllipticCurveDecryptButton_Click(object sender, EventArgs e, int a, int Base, string BPublicKey)
        {
            if (OriginalTextBox.Text.Replace(" ", "") != "")
            {
                string[] CTString = OriginalTextBox.Text.Split(new char[] { '\n' });
                InputOutputConversion IOConversion = new InputOutputConversion();
                Point[] CT = new Point[] { IOConversion.StringToPoint(CTString[0]), IOConversion.StringToPoint(CTString[1]) };
                EllipticCurve ellipticCurve = new EllipticCurve();
                ModifiedTextBox.Text = IOConversion.PointToString(ellipticCurve.Decrypt(a, Base, CT, int.Parse(BPublicKey)));
            }
        }
        #endregion

        #endregion

        #region Key Exchange Algorithms

        #region Diffie - Hellman
        private void DiffieHellmanNodeClicked()
        {
            #region Radio Buttons GroupBox
            RadioButton SharedKeyRadioButton = DefineRadioButton("Shared Key");
            RadioButton SharedKeyNumberRadioButton = DefineRadioButton("Shared Key with two initial keys");
            RadioButton PublicNumberRadioButton = DefineRadioButton("Public Key");

            GroupBox KeyModeGroupBox = DefineGroupBox("Key Mode", new Size(300, 90));
            KeyModeGroupBox.Controls.Add(PublicNumberRadioButton);
            KeyModeGroupBox.Controls.Add(SharedKeyNumberRadioButton);
            KeyModeGroupBox.Controls.Add(SharedKeyRadioButton);
            #endregion

            #region Input GroupBox
            Label PrimeBaseLabel = DefineLabel("Prime Base");
            TextBox PrimeBaseText = DefineTextBox();
            Label PrimitiveRootLabel = DefineLabel("Primitive Root");
            TextBox PrimitiveRootText = DefineTextBox();

            Label FirstNumberLabel = DefineLabel("First Initial Key");
            TextBox FirstNumberText = DefineTextBox();
            Label SecondNumberLabel = DefineLabel("Second Initial Key");
            TextBox SecondNumberText = DefineTextBox();

            GroupBox InputGroupBox = DefineGroupBox("Input", new Size(300, 90));
            InputGroupBox.AutoSize = true;
            InputGroupBox.Controls.Add(SecondNumberText);
            InputGroupBox.Controls.Add(SecondNumberLabel);
            InputGroupBox.Controls.Add(FirstNumberText);
            InputGroupBox.Controls.Add(FirstNumberLabel);

            InputGroupBox.Controls.Add(PrimitiveRootText);
            InputGroupBox.Controls.Add(PrimitiveRootLabel);
            InputGroupBox.Controls.Add(PrimeBaseText);
            InputGroupBox.Controls.Add(PrimeBaseLabel);

            #endregion

            #region Radio Buttons Controlling
            List<Control> SharedControls = new List<Control>();
            SharedControls.Add(FirstNumberLabel);
            SharedControls.Add(FirstNumberText);
            SharedControls.Add(SecondNumberLabel);
            SharedControls.Add(SecondNumberText);
            SharedKeyRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { DFSharedKeyRadioButton_CheckedChanged(sender1, e1, SharedKeyRadioButton.Checked, SharedControls); };
            SharedKeyRadioButton.Checked = true;
            SharedKeyNumberRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { DFSharedKeyNumberRadioButton_CheckedChanged(sender1, e1, SharedKeyNumberRadioButton.Checked, SharedControls); };
            PublicNumberRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { DFPublicNumberRadioButton_CheckedChanged(sender1, e1, PublicNumberRadioButton.Checked, SharedControls); };
            #endregion

            Button GetKeyButton = DefineButton("Get Key");
            GetKeyButton.Click += delegate(object sender1, EventArgs e1) { DiffieHellmanGetKeyButton_Click(sender1, e1, SharedKeyRadioButton.Checked, SharedKeyNumberRadioButton.Checked, PublicNumberRadioButton.Checked, int.Parse(PrimeBaseText.Text), int.Parse(PrimitiveRootText.Text), int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(GetKeyButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
            CipherControlPanel.Controls.Add(KeyModeGroupBox);
        }

        #region RadioButtons Checked Changed
        void DFSharedKeyRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
                foreach (Control item in SharedControls)
                    item.Hide();
        }
        void DFSharedKeyNumberRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
            {
                for (int i = 3; i >= 0; i--)
                    SharedControls[i].Show();
                SharedControls[0].Text = "First Initial Key";
            }
        }
        void DFPublicNumberRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
            {
                for (int i = 2; i >= 0; i--)
                    SharedControls[i].Show();
                for (int i = 2; i < 4; i++)
                    SharedControls[i].Hide();
                SharedControls[0].Text = "Public Key";
            }
        }
        #endregion

        void DiffieHellmanGetKeyButton_Click(object sender, EventArgs e, bool FirstChecked, bool SecondChecked, bool ThirdChecked, int PrimeBase, int PrimitiveRoot, int numOne, int numTwo)
        {
            DiffieHellman keyExchange = new DiffieHellman();
            if (FirstChecked)
                keyExchange.DiffieHellmanGetSharedKey(PrimeBase, PrimitiveRoot);
            else if (SecondChecked)
                keyExchange.DiffieHellmanGetSharedKey(PrimeBase, PrimitiveRoot, numOne, numTwo);
            else if (ThirdChecked)
                keyExchange.DiffieHellmanGetPublicKey(PrimeBase, PrimitiveRoot, numOne);
        }
        #endregion

        #region Elliptic Curve
        private void KeyExchangeEllipticCurveNodeClicked()
        {
            #region Radio Buttons GroupBox
            RadioButton SharedKeyRadioButton = DefineRadioButton("Shared key");
            RadioButton SharedKeyNumberRadioButton = DefineRadioButton("Shared key with two private keys");
            RadioButton PublicNumberRadioButton = DefineRadioButton("Public key");

            GroupBox KeyModeGroupBox = DefineGroupBox("Key Mode", new Size(300, 90));
            KeyModeGroupBox.Controls.Add(PublicNumberRadioButton);
            KeyModeGroupBox.Controls.Add(SharedKeyNumberRadioButton);
            KeyModeGroupBox.Controls.Add(SharedKeyRadioButton);
            #endregion

            #region Input GroupBox

            Label aLabel = DefineLabel("(a)");
            TextBox aText = DefineTextBox();
            Label BaseLabel = DefineLabel("Base (p)");
            TextBox BaseText = DefineTextBox();
            Label GLabel = DefineLabel("Point of Curve (G)");
            TextBox GText = DefineTextBox();
            Label nLabel = DefineLabel("Random Secret Number (n)");
            TextBox nText = DefineTextBox();
            Label PrivateKeyBLabel = DefineLabel("Private Key (B)");
            TextBox PrivateKeyBText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("Input", new Size(300, 90));
            InputGroupBox.AutoSize = true;
            InputGroupBox.Controls.Add(PrivateKeyBText);
            InputGroupBox.Controls.Add(PrivateKeyBLabel);
            InputGroupBox.Controls.Add(nText);
            InputGroupBox.Controls.Add(nLabel);
            InputGroupBox.Controls.Add(GText);
            InputGroupBox.Controls.Add(GLabel);
            InputGroupBox.Controls.Add(BaseText);
            InputGroupBox.Controls.Add(BaseLabel);
            InputGroupBox.Controls.Add(aText);
            InputGroupBox.Controls.Add(aLabel);

            #endregion

            #region Radio Buttons Controlling
            List<Control> SharedControls = new List<Control>();
            SharedControls.Add(nLabel);
            SharedControls.Add(nText);
            SharedControls.Add(PrivateKeyBLabel);
            SharedControls.Add(PrivateKeyBText);
            SharedKeyRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { ECSharedKeyRadioButton_CheckedChanged(sender1, e1, SharedKeyRadioButton.Checked, SharedControls); };
            SharedKeyRadioButton.Checked = true;
            SharedKeyNumberRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { ECSharedKeyNumberRadioButton_CheckedChanged(sender1, e1, SharedKeyNumberRadioButton.Checked, SharedControls); };
            PublicNumberRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { ECPublicNumberRadioButton_CheckedChanged(sender1, e1, PublicNumberRadioButton.Checked, SharedControls); };
            #endregion

            Button GetKeyButton = DefineButton("Get Key");
            InputOutputConversion IOConversion = new InputOutputConversion();
            GetKeyButton.Click += delegate(object sender1, EventArgs e1) { EllipticCurveGetKeyButton_Click(sender1, e1, SharedKeyRadioButton.Checked, SharedKeyNumberRadioButton.Checked, PublicNumberRadioButton.Checked, int.Parse(aText.Text), int.Parse(BaseText.Text), IOConversion.StringToPoint(GText.Text), int.Parse(nText.Text), int.Parse(PrivateKeyBText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(GetKeyButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
            CipherControlPanel.Controls.Add(KeyModeGroupBox);
        }

        #region RadioButtons Checked Changed
        void ECSharedKeyRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
            {
                for (int i = 2; i < 4; i++)
                    SharedControls[i].Hide();
                SharedControls[0].Text = "Random Secret Number (n)";
            }
        }
        void ECSharedKeyNumberRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
            {
                for (int i = 3; i >= 2; i--)
                    SharedControls[i].Show();
                SharedControls[0].Text = "Private Key (A)";
            }
        }
        void ECPublicNumberRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
            {
                for (int i = 2; i < 4; i++)
                    SharedControls[i].Hide();
                SharedControls[0].Text = "Public Key";
            }
        }
        #endregion

        void EllipticCurveGetKeyButton_Click(object sender, EventArgs e, bool FirstChecked, bool SecondChecked, bool ThirdChecked, int a, int Base, Point G, int n, int PrivateKeyB)
        {
            EllipticCurve ellipticCurve = new EllipticCurve();
            InputOutputConversion IOConversion = new InputOutputConversion();
            if (FirstChecked)
                ModifiedTextBox.Text = IOConversion.PointToString(ellipticCurve.EllipticCurveGetSharedKeyUsingResidueClass(a, Base, G, n));
            else if (SecondChecked)
                ModifiedTextBox.Text = IOConversion.PointToString(ellipticCurve.EllipticCurveGetSharedKeyUsingResidueClass(a, Base, G, n, PrivateKeyB));
            else if (ThirdChecked)
                ModifiedTextBox.Text = IOConversion.PointToString(ellipticCurve.EllipticCurveGetPublicKeyResidueClass(a, Base, G, n));
        }

        #endregion

        #endregion

        #region Number Theory

        #region Extended Euclid's Algorithm
        private void ExtendedEuclidAlgorithmNodeClicked()
        {
            Label NumberLabel = DefineLabel("Number");
            TextBox NumberText = DefineTextBox();
            Label BaseLabel = DefineLabel("Base Number");
            TextBox BaseText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(200, 90));
            InputGroupBox.Controls.Add(BaseText);
            InputGroupBox.Controls.Add(BaseLabel);
            InputGroupBox.Controls.Add(NumberText);
            InputGroupBox.Controls.Add(NumberLabel);

            Button MIButton = DefineButton("Multiplicative Inverse");
            MIButton.Click += delegate(object sender1, EventArgs e1) { MIButton_Click(sender1, e1, int.Parse(NumberText.Text), int.Parse(BaseText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(MIButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void MIButton_Click(object sender, EventArgs e, int Number, int Base)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.MultiplicativeInverse(Number, Base).ToString();
        }
        #endregion

        #region Polynomial Extended Euclid's Algorithm
        private void PolynomialExtendedEuclidAlgorithmNodeClicked()
        {
            Label PolynomialLabel = DefineLabel("Polynomial");
            TextBox PolynomialText = DefineTextBox();
            Label BasePolynomialLabel = DefineLabel("Base Polynomial");
            TextBox BasePolynomialText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(200, 90));
            InputGroupBox.Controls.Add(BasePolynomialText);
            InputGroupBox.Controls.Add(BasePolynomialLabel);
            InputGroupBox.Controls.Add(PolynomialText);
            InputGroupBox.Controls.Add(PolynomialLabel);

            Button PolynomialMIButton = DefineButton("Polynomial Multiplicative Inverse");
            InputOutputConversion IOConversion = new InputOutputConversion();
            PolynomialMIButton.Click += delegate(object sender1, EventArgs e1) { PolynomialMIButton_Click(sender1, e1, IOConversion.StringToPolynomial(PolynomialText.Text), IOConversion.StringToPolynomial(BasePolynomialText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(PolynomialMIButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void PolynomialMIButton_Click(object sender, EventArgs e, Polynomial Polynomial, Polynomial BasePolynomial)
        {
            NumberTheory euclidean = new NumberTheory();
            InputOutputConversion IOConversion = new InputOutputConversion();
            ModifiedTextBox.Text = IOConversion.PolynomialToString(euclidean.MultiplicativeInverse(Polynomial, BasePolynomial));
        }
        #endregion

        #region GCD
        private void GCDNodeClicked()
        {
            Label FirstNumberLabel = DefineLabel("First Number");
            TextBox FirstNumberText = DefineTextBox();
            Label SecondNumberLabel = DefineLabel("Second Number");
            TextBox SecondNumberText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(200, 90));
            InputGroupBox.Controls.Add(SecondNumberText);
            InputGroupBox.Controls.Add(SecondNumberLabel);
            InputGroupBox.Controls.Add(FirstNumberText);
            InputGroupBox.Controls.Add(FirstNumberLabel);

            Button GCDButton = DefineButton("Greatest Common Divisor");
            GCDButton.Click += delegate(object sender1, EventArgs e1) { GCDButton_Click(sender1, e1, int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(GCDButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void GCDButton_Click(object sender, EventArgs e, int FirstNumber, int SecondNumber)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.GCD(FirstNumber, SecondNumber).ToString();
        }
        #endregion

        #region Polynomial GCD
        private void PolynomialGCDNodeClicked()
        {
            Label FirstPolynomialLabel = DefineLabel("First Polynomial");
            TextBox FirstPolynomialText = DefineTextBox();
            Label SecondPolynomialLabel = DefineLabel("Second Polynomial");
            TextBox SecondPolynomialText = DefineTextBox();

            Label NoteLabel = DefineLabel("Note: Polynomials must be under GF(2), One and zero are the only valid coefficients..");
            GroupBox InputGroupBox = DefineGroupBox("", new Size(200, 100));
            InputGroupBox.Controls.Add(NoteLabel);
            InputGroupBox.Controls.Add(SecondPolynomialText);
            InputGroupBox.Controls.Add(SecondPolynomialLabel);
            InputGroupBox.Controls.Add(FirstPolynomialText);
            InputGroupBox.Controls.Add(FirstPolynomialLabel);

            Button PolynomialGCDButton = DefineButton("Polynomials Greatest Common Divisor");
            InputOutputConversion IOConversion = new InputOutputConversion();

            PolynomialGCDButton.Click += delegate(object sender1, EventArgs e1) { PolynomialGCDButton_Click(sender1, e1, IOConversion.StringToPolynomial(FirstPolynomialText.Text), IOConversion.StringToPolynomial(SecondPolynomialText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(PolynomialGCDButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void PolynomialGCDButton_Click(object sender, EventArgs e, Polynomial FirstPolynomial, Polynomial SecondPolynomial)
        {
            NumberTheory euclidean = new NumberTheory();
            InputOutputConversion IOConversion = new InputOutputConversion();
            ModifiedTextBox.Text = IOConversion.PolynomialToString(euclidean.GCD(FirstPolynomial, SecondPolynomial));
        }
        #endregion

        #region Big Power
        private void BigPowerNodeClicked()
        {
            Label BaseLabel = DefineLabel("Base");
            TextBox BaseText = DefineTextBox();
            Label PowerLabel = DefineLabel("Power");
            TextBox PowerText = DefineTextBox();
            Label ModLabel = DefineLabel("Mod");
            TextBox ModText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(200, 90));
            InputGroupBox.AutoSize = true;
            InputGroupBox.Controls.Add(ModText);
            InputGroupBox.Controls.Add(ModLabel);
            InputGroupBox.Controls.Add(PowerText);
            InputGroupBox.Controls.Add(PowerLabel);
            InputGroupBox.Controls.Add(BaseText);
            InputGroupBox.Controls.Add(BaseLabel);

            Button BigPowerButton = DefineButton("Big Power");
            BigPowerButton.Click += delegate(object sender1, EventArgs e1) { BigPowerButton_Click(sender1, e1, int.Parse(BaseText.Text), int.Parse(PowerText.Text), int.Parse(ModText.Text)); };

            CipherControlPanel.Controls.Clear();
            CipherControlPanel.Controls.Add(BigPowerButton);
            CipherControlPanel.Controls.Add(InputGroupBox);
        }
        void BigPowerButton_Click(object sender, EventArgs e, int Base, int Power, int Mod)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.BigPower(Base, Power, Mod).ToString();
        }
        #endregion

        #endregion

        #endregion

        #region Ciphers TreeView After Selection
        private void AllCiphersTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region Index 0
            if (AllCiphersTreeView.SelectedNode.Index == 0)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "CeaserCipherNode")
                    CeaserCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "RailFenceNode")
                    RailFenceNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "DESNode")
                    DESNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "RC4Node")
                    RC4NodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "RSANode")
                    RSANodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "DiffieHellmanNode")
                    DiffieHellmanNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "ExtendedEuclidAlgorithmNode")
                    ExtendedEuclidAlgorithmNodeClicked();
            }
            #endregion

            #region Index 1
            else if (AllCiphersTreeView.SelectedNode.Index == 1)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "MonoalphabeticCipherNode")
                    MonoalphabeticCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "ColumnarCipherNode")
                    ColumnarCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "DoubleDESNode")
                    DoubleDESNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "KeyCryptosystemEllipticCurveNode")
                    KeyCryptosystemEllipticCurveNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "KeyExchangeEllipticCurveNode")
                    KeyExchangeEllipticCurveNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "PolynomialExtendedEuclidAlgorithmNode")
                    PolynomialExtendedEuclidAlgorithmNodeClicked();
            }
            #endregion

            #region index 2
            else if (AllCiphersTreeView.SelectedNode.Index == 2)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "PlayfairCipherNode")
                    PlayfairCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "TripleDESNode")
                    TripleDESNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "GCDNode")
                    GCDNodeClicked();
            }
            #endregion

            #region Index 3
            else if (AllCiphersTreeView.SelectedNode.Index == 3)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "HillCipherNode")
                    HillCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "AESNode")
                    AESNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "PolynomialGCDNode")
                    PolynomialGCDNodeClicked();
            }
            #endregion

            #region Index 4
            else if (AllCiphersTreeView.SelectedNode.Index == 4)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "PolyalphabeticCipherNode")
                    PolyalphabeticCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "BigPowerNode")
                    BigPowerNodeClicked();
            }
            #endregion

        }
        #endregion
    }
}