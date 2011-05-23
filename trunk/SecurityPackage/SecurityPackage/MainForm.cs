using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Swensen;
using System.Threading;

namespace SecurityPackage
{
    public partial class MainForm : Form
    {
        #region Constructor & Form Load
        public MainForm()
        {
            //Thread t = new Thread(new ThreadStart(SplashScreen));
            //t.Start();
            //Thread.Sleep(2000);
            //t.Abort();
            InitializeComponent();
        }
        private void SplashScreen()
        {
            Application.Run(new SplashScreenForm());
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //int[,] K = { { 17, 17, 5 }, { 21, 18, 21 }, { 2, 2, 19 } };
            //int[,] K = { { 7, 4, 2, 0 }, { 6, 3, -1, 2 }, { 4, 6, 2, 5 }, { 8, 2, -7, 1 } };
            //int[,] K = { { 7, 4, 2, 0, 6 }, { 6, 3, -1, 2, -1 }, { 4, 6, 2, 5, 4 }, { 8, 2, -7, 1, 2 }, { 9, 3, 7, 0, 5 } };
            //HillCipher p = new HillCipher();
            //string s = p.Encrypt("advance attack two hours from now plz", K);
            //s = p.Decrypt("COIPDCUCBTSKITIEPUDNYEYXILEURUUT", K);

            //RailFenceCipher p = new RailFenceCipher();
            //string s =  p.Encrypt("advance attack two hours from nw", 7);
            //s = p.Decrypt("aawfdtorvthoaaomncunckrwets", 7);

            //ColumnarCipher p = new ColumnarCipher();
            //string s = p.Encrypt("advance attack two hours from now", 52314);
            //s = p.Decrypt("attuodechfovakorwntwrmacaosn", 52314);

            //PolyalphabeticCipher p = new PolyalphabeticCipher();
            //string s = p.Encrypt("advance attack two hours from now plz", "AVS", 0);
            //s = p.Decrypt("AYNAAEIAMMAEUMSCOCOIKKICYACSEWY","AVSANCEATTACKTWOHOURSFROMNOWPLZ",0);
            //s = p.Encrypt("advance attack two hours from now plz", "AVS", 1);
            //s = p.Decrypt("AYNAIUEVLTVUKOOOCGUMKFMGMIGWKDZ", "AVSAVSAVSAVSAVSAVSAVSAVSAVSAVSA", 1);

            //PlayFairCipher p = new PlayFairCipher();
            //string s = p.Encrypt("advance attack two hours from now plz", "iklml");
            //s = p.Decrypt("LFZIHDFMSYUMHCRYPNPTSTCUTEOPZHAX", "iklml");

            //MonoalphabeticCipher p = new MonoalphabeticCipher();
            //string s = p.Encrypt("hadeel hisham sadek mohamed albetar", "qwertyuiopasdfghjklzxcvbnm");
            //s = p.Decrypt("iqrttsioliqdlqrtadgiqdtrqswtzqk", "qwertyuiopasdfghjklzxcvbnm");

            //CeaserCipher p = new CeaserCipher();
            //string s = p.Encrypt("advance attack two hours from now plz", 2);
            //s = p.Decrypt("cfxcpegcvvcemvyqjqwtuhtqopqyrn|",2);

            //AES p = new AES();
            //string s = p.Encrypt("hadeel hisham sadek mohamed al bitar Amal Hussein Sayed Yassin", "123456789abcdef123456789abcdef");
            //s = p.Decrypt("3820D72CBD39572137DC7A75579D414E5B4B99164739A8004F452718689602054D6D9BF786B9DEEC274AAD9D43B1FFC1DB0E9887F961E49E817A7C7133AA3703", "123456789ABCDEF123456789ABCDEF");

            //DES des = new DES();
            //ModifiedTextBox.Text = des.Encrypt("0x 12f b", "0x1234");

            //RC4 rc4 = new RC4();
            //ModifiedTextBox.Text = rc4.Encrypt("abcd");

            //KeyExchange KE = new KeyExchange();
            //Point PublicA = KE.EllipticCurveGetPublicKeyResidueClass(1, 11, new Point(2, 7), 3);
            //Point PublicB = KE.EllipticCurveGetPublicKeyResidueClass(1, 11, new Point(2, 7), 7);
            //Point Key = KE.EllipticCurveGetSharedKeyUsingResidueClass(1, 11, new Point(2, 7), 3, 7);

            //DiffieHellman DH = new DiffieHellman();
            //BigInt x = DH.DiffieHellmanGetSharedKey(71, 7, 5, 12);

            //NumberTheory NT = new NumberTheory();
            //BigInt y = NT.BigPower(2, 1000);
            //MessageBox.Show(y.ToString());
        }
        #endregion

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

        #region Controls
        Button DefineButton(string ButtonText)
        {
            Button button = new Button();
            button.Text = ButtonText;
            button.Size = new Size(270, 30);
            button.BackColor = Color.Transparent;
            button.Dock = DockStyle.Top;
            return button;
        }
        Label DefineLabel(string LabelText)
        {
            Label label = new Label();
            label.Text = LabelText;
            label.AutoSize = true;
            label.ForeColor = Color.LightSeaGreen;
            label.Dock = DockStyle.Top;
            return label;
        }
        GroupBox DefineGroupBox(string groupBoxText, Size size)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = groupBoxText;
            groupBox.Size = size;
            groupBox.ForeColor = Color.LightSeaGreen;
            groupBox.Dock = DockStyle.Top;
            return groupBox;
        }
        TextBox DefineTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Top;
            return textBox;
        }
        RadioButton DefineRadioButton(string RadioButtonText)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Text = RadioButtonText;
            radioButton.Dock = DockStyle.Top;
            return radioButton;
        }
        #endregion

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


            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void CeaserEncryptButton_Click(object sender, EventArgs e, int Key)
        {
            CeaserCipher ceaserCipher = new CeaserCipher();
            ModifiedTextBox.Text = ceaserCipher.Encrypt(OriginalTextBox.Text, Key);
        }
        void CeaserDecryptButton_Click(object sender, EventArgs e, int Key)
        {
            CeaserCipher ceaserCipher = new CeaserCipher();
            ModifiedTextBox.Text = ceaserCipher.Decrypt(OriginalTextBox.Text, Key);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void MonoalphabeticEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            MonoalphabeticCipher monoalphabeticCipher = new MonoalphabeticCipher();
            ModifiedTextBox.Text = monoalphabeticCipher.Encrypt(OriginalTextBox.Text, Key);
        }
        void MonoalphabeticDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            MonoalphabeticCipher monoalphabeticCipher = new MonoalphabeticCipher();
            ModifiedTextBox.Text = monoalphabeticCipher.Decrypt(OriginalTextBox.Text, Key);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void PlayFairEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            PlayFairCipher playFairCipher = new PlayFairCipher();
            ModifiedTextBox.Text = playFairCipher.Encrypt(OriginalTextBox.Text, Key);
        }
        void PlayFairDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            PlayFairCipher playFairCipher = new PlayFairCipher();
            ModifiedTextBox.Text = playFairCipher.Decrypt(OriginalTextBox.Text, Key);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void HillEncryptButton_Click(object sender, EventArgs e, int KeySize)
        {
            HillKeyForm HillKeyMatrix = new HillKeyForm(KeySize, OriginalTextBox.Text, ModifiedTextBox);
            HillKeyMatrix.Show();
        }
        void HillDecryptButton_Click(object sender, EventArgs e, int KeySize)
        {
            HillKeyForm HillKeyMatrix = new HillKeyForm(KeySize, OriginalTextBox.Text, ModifiedTextBox);
            HillKeyMatrix.Show();
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyModeGroupBox);
            CipherCntrolPanel.Controls.Add(KeyText);
            CipherCntrolPanel.Controls.Add(KeyLabel);
        }
        void PolyalphabeticEncryptButton_Click(object sender, EventArgs e, string Key, bool KeyMode)
        {
            PolyalphabeticCipher polyalphabeticCipher = new PolyalphabeticCipher();
            if (KeyMode)
                ModifiedTextBox.Text = polyalphabeticCipher.Encrypt(OriginalTextBox.Text, Key, 0);
            else
                ModifiedTextBox.Text = polyalphabeticCipher.Encrypt(OriginalTextBox.Text, Key, 1);
        }
        void PolyalphabeticDecryptButton_Click(object sender, EventArgs e, string Key, bool KeyMode)
        {
            PolyalphabeticCipher polyalphabeticCipher = new PolyalphabeticCipher();
            if (KeyMode)
                ModifiedTextBox.Text = polyalphabeticCipher.Decrypt(OriginalTextBox.Text, Key, 0);
            else
                ModifiedTextBox.Text = polyalphabeticCipher.Decrypt(OriginalTextBox.Text, Key, 1);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void RailFenceEncryptButton_Click(object sender, EventArgs e, int DepthLevel)
        {
            RailFenceCipher railFenceCipher = new RailFenceCipher();
            ModifiedTextBox.Text = railFenceCipher.Encrypt(OriginalTextBox.Text, DepthLevel);
        }
        void RailFenceDecryptButton_Click(object sender, EventArgs e, int DepthLevel)
        {
            RailFenceCipher railFenceCipher = new RailFenceCipher();
            ModifiedTextBox.Text = railFenceCipher.Decrypt(OriginalTextBox.Text, DepthLevel);
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
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { ColumnarEncryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { ColumnarDecryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void ColumnarEncryptButton_Click(object sender, EventArgs e, int Key)
        {
            ColumnarCipher ColumnarCipher = new ColumnarCipher();
            ModifiedTextBox.Text = ColumnarCipher.Encrypt(OriginalTextBox.Text, Key);
        }
        void ColumnarDecryptButton_Click(object sender, EventArgs e, int Key)
        {
            ColumnarCipher ColumnarCipher = new ColumnarCipher();
            ModifiedTextBox.Text = ColumnarCipher.Decrypt(OriginalTextBox.Text, Key);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void DESEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Encrypt(OriginalTextBox.Text, Key);
        }
        void DESDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Decrypt(OriginalTextBox.Text, Key);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void DoubleDESEncryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Encrypt(des.Encrypt(OriginalTextBox.Text, FirstKeyText), SecondKeyText);
        }
        void DoubleDESDecryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Decrypt(des.Decrypt(OriginalTextBox.Text, FirstKeyText), SecondKeyText);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void TripleDESEncryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText, string ThirdKeyText)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Encrypt(des.Encrypt(des.Encrypt(OriginalTextBox.Text, FirstKeyText), SecondKeyText), ThirdKeyText);
        }
        void TripleDESDecryptButton_Click(object sender, EventArgs e, string FirstKeyText, string SecondKeyText, string ThirdKeyText)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Decrypt(des.Decrypt(des.Decrypt(OriginalTextBox.Text, FirstKeyText), SecondKeyText), ThirdKeyText);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void AESEncryptButton_Click(object sender, EventArgs e, string Key)
        {
            AES aes = new AES();
            ModifiedTextBox.Text = aes.Encrypt(OriginalTextBox.Text, Key);
        }
        void AESDecryptButton_Click(object sender, EventArgs e, string Key)
        {
            AES aes = new AES();
            ModifiedTextBox.Text = aes.Decrypt(OriginalTextBox.Text, Key);
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(KeyGroupBox);
        }
        void RC4EncryptButton_Click(object sender, EventArgs e, string Key)
        {
            RC4 rc4 = new RC4();
            ModifiedTextBox.Text = rc4.Encrypt(OriginalTextBox.Text, Key);
        }
        void RC4DecryptButton_Click(object sender, EventArgs e, string Key)
        {
            RC4 rc4 = new RC4();
            ModifiedTextBox.Text = rc4.Decrypt(OriginalTextBox.Text, Key);
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
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RSAEncryptButton_Click(sender1, e1, int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text), int.Parse(KeyText.Text)); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RSADecryptButton_Click(sender1, e1, int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text), int.Parse(KeyText.Text)); };

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
            CipherCntrolPanel.Controls.Add(InputGroupBox);
        }
        void RSAEncryptButton_Click(object sender, EventArgs e, int p, int q, int Key)
        {
            RSA rsa = new RSA();
            ModifiedTextBox.Text = rsa.Encrypt(OriginalTextBox.Text, p, q, Key);
        }
        void RSADecryptButton_Click(object sender, EventArgs e, int p, int q, int Key)
        {
            RSA rsa = new RSA();
            ModifiedTextBox.Text = rsa.Decrypt(OriginalTextBox.Text, p, q, Key);
        }
        #endregion

        #region Elliptic Curve
        private void KeyCryptosystemEllipticCurveNodeClicked()
        {
            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { PublicKeyEllipticCurveEncryptButton_Click(sender1, e1); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { PublicKeyEllipticCurveDecryptButton_Click(sender1, e1); };

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(DecryptButton);
            CipherCntrolPanel.Controls.Add(EncryptButton);
        }
        void PublicKeyEllipticCurveEncryptButton_Click(object sender, EventArgs e)
        {
        }
        void PublicKeyEllipticCurveDecryptButton_Click(object sender, EventArgs e)
        {
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
            SharedKeyRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { SharedKeyRadioButton_CheckedChanged(sender1, e1, SharedKeyRadioButton.Checked, SharedControls); };
            SharedKeyRadioButton.Checked = true;
            SharedKeyNumberRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { SharedKeyNumberRadioButton_CheckedChanged(sender1, e1, SharedKeyNumberRadioButton.Checked, SharedControls); };
            PublicNumberRadioButton.CheckedChanged += delegate(object sender1, EventArgs e1) { PublicNumberRadioButton_CheckedChanged(sender1, e1, PublicNumberRadioButton.Checked, SharedControls); };
            #endregion

            Button GetKeyButton = DefineButton("Get Key");
            GetKeyButton.Click += delegate(object sender1, EventArgs e1) { DiffieHellmanGetKeyButton_Click(sender1, e1, SharedKeyRadioButton.Checked, SharedKeyNumberRadioButton.Checked, PublicNumberRadioButton.Checked, int.Parse(PrimeBaseText.Text), int.Parse(PrimeBaseText.Text), int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text)); };

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(GetKeyButton);
            CipherCntrolPanel.Controls.Add(InputGroupBox);
            CipherCntrolPanel.Controls.Add(KeyModeGroupBox);
        }

        #region RadioButtons Checked Changed
        void SharedKeyRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
                foreach (Control item in SharedControls)
                    item.Hide();
        }
        void SharedKeyNumberRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
        {
            if (Checked)
            {
                for (int i = 3; i >= 0; i--)
                    SharedControls[i].Show();
                SharedControls[0].Text = "First Initial Key";
            }
        }
        void PublicNumberRadioButton_CheckedChanged(object sender, EventArgs e, bool Checked, List<Control> SharedControls)
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

        }
        #endregion

        #endregion

        #region Number Theory

        #region Extended Euclid's Algorithm
        private void ExtendedEuclidAlgorithmNodeClicked()
        {
            Label NumberLabel = DefineLabel("Number");
            TextBox NumberText = DefineTextBox();
            Label BaseLabel = DefineLabel("Base");
            TextBox BaseText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(200, 90));
            InputGroupBox.Controls.Add(BaseText);
            InputGroupBox.Controls.Add(BaseLabel);
            InputGroupBox.Controls.Add(NumberText);
            InputGroupBox.Controls.Add(NumberLabel);

            Button MIButton = DefineButton("Multiplicative Inverse");
            MIButton.Click += delegate(object sender1, EventArgs e1) { MIButton_Click(sender1, e1, int.Parse(NumberText.Text), int.Parse(BaseText.Text)); };

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(MIButton);
            CipherCntrolPanel.Controls.Add(InputGroupBox);
        }
        void MIButton_Click(object sender, EventArgs e, int Number, int Base)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.MultiplicativeInverse(Number, Base).ToString();
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(GCDButton);
            CipherCntrolPanel.Controls.Add(InputGroupBox);
        }
        void GCDButton_Click(object sender, EventArgs e, int FirstNumber, int SecondNumber)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.GCD(FirstNumber, SecondNumber).ToString();
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

            CipherCntrolPanel.Controls.Clear();
            CipherCntrolPanel.Controls.Add(BigPowerButton);
            CipherCntrolPanel.Controls.Add(InputGroupBox);
        }
        void BigPowerButton_Click(object sender, EventArgs e, int Base, int Power, int Mod)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.BigPower(Base, Power, Mod).ToString();
        }
        #endregion

        #endregion

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
                else if (AllCiphersTreeView.SelectedNode.Name == "EllipticCurveNode")
                    KeyCryptosystemEllipticCurveNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "EllipticCurveNode")
                    KeyExchangeEllipticCurveNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "GCDNode")
                    GCDNodeClicked();
            }
            #endregion

            #region index 2
            else if (AllCiphersTreeView.SelectedNode.Index == 2)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "PlayfairCipherNode")
                    PlayfairCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "TripleDESNode")
                    TripleDESNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "BigPowerNode")
                    BigPowerNodeClicked();
            }
            #endregion

            #region Index 3
            else if (AllCiphersTreeView.SelectedNode.Index == 3)
            {
                if (AllCiphersTreeView.SelectedNode.Name == "HillCipherNode")
                    HillCipherNodeClicked();
                else if (AllCiphersTreeView.SelectedNode.Name == "AESNode")
                    AESNodeClicked();
            }
            #endregion

            #region Index 4
            else if (AllCiphersTreeView.SelectedNode.Name == "PolyalphabeticCipherNode")
                PolyalphabeticCipherNodeClicked();
            #endregion

        }
    }
}