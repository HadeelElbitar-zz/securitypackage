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
        #region Constructor & Form Load
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //int[,] K = { { 17, 17, 5 }, { 21, 18, 21 }, { 2, 2, 19 } };
            //int[,] K = { { 7, 4, 2, 0 }, { 6, 3, -1, 2 }, { 4, 6, 2, 5 }, { 8, 2, -7, 1 } };
            //int[,] K = { { 7, 4, 2, 0, 6 }, { 6, 3, -1, 2, -1 }, { 4, 6, 2, 5, 4 }, { 8, 2, -7, 1, 2 }, { 9, 3, 7, 0, 5 } };
            //HillCipher p = new HillCipher("paye", K);
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
            //CeaserCipher p = new CeaserCipher("advance attack two hours from now plz", 2);
            //p.Encrypt();
            //p.Decrypt();
            //Euclidean A = new Euclidean();
            //A.MultiplicativeInverse(23, 26); 

            //AES p = new AES("hadeel hisham sadek mohamed al bitar Amal Hussein Sayed Yassin", "123456789abcdef123456789abcdef");
            //p.Encrypt();
            //p.Decrypt();

            //DES des = new DES("abcd");
            //ModifiedTextBox.Text = des.Encrypt();

            //RC4 rc4 = new RC4();
            //ModifiedTextBox.Text = rc4.Encrypt("abcd");

            //DiffieHellman DH = new DiffieHellman(29, 2);
            //int Key = DH.GetSharedKey(8, 3);
            //Key = DH.GetSharedKey();
            //Key = DH.GetSharedKey(28, 13);

            //KeyExchange KE = new KeyExchange();
            //Point PublicA = KE.EllipticCurveGetPublicKeyResidueClass(1, 11, new Point(2, 7), 3);
            //Point PublicB = KE.EllipticCurveGetPublicKeyResidueClass(1, 11, new Point(2, 7), 7);
            //Point Key = KE.EllipticCurveGetSharedKeyUsingResidueClass(1, 11, new Point(2, 7), 3, 7);
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
        private void CeaserCipherLabel_Click(object sender, EventArgs e)
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Ceaser Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { CeaserEncryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { CeaserDecryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };

            SubstitutionContainer.Panel2.Controls.Clear();
            SubstitutionContainer.Panel2.Controls.Add(DecryptButton);
            SubstitutionContainer.Panel2.Controls.Add(EncryptButton);
            SubstitutionContainer.Panel2.Controls.Add(KeyGroupBox);
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
        private void MonoalphabeticLabel_Click(object sender, EventArgs e)
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Monoalphabetic Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { MonoalphabeticEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { MonoalphabeticDecryptButton_Click(sender1, e1, KeyText.Text); };

            SubstitutionContainer.Panel2.Controls.Clear();
            SubstitutionContainer.Panel2.Controls.Add(DecryptButton);
            SubstitutionContainer.Panel2.Controls.Add(EncryptButton);
            SubstitutionContainer.Panel2.Controls.Add(KeyGroupBox);
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
        private void PlayFairCipherLabel_Click(object sender, EventArgs e)
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Play Fair Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { PlayFairEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { PlayFairDecryptButton_Click(sender1, e1, KeyText.Text); };

            SubstitutionContainer.Panel2.Controls.Clear();
            SubstitutionContainer.Panel2.Controls.Add(DecryptButton);
            SubstitutionContainer.Panel2.Controls.Add(EncryptButton);
            SubstitutionContainer.Panel2.Controls.Add(KeyGroupBox);
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
        private void HillCipherLabel_Click(object sender, EventArgs e)
        {
            TextBox KeySizeText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Hill Key Size", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeySizeText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { HillEncryptButton_Click(sender1, e1, int.Parse(KeySizeText.Text)); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { HillDecryptButton_Click(sender1, e1, int.Parse(KeySizeText.Text)); };

            SubstitutionContainer.Panel2.Controls.Clear();
            SubstitutionContainer.Panel2.Controls.Add(DecryptButton);
            SubstitutionContainer.Panel2.Controls.Add(EncryptButton);
            SubstitutionContainer.Panel2.Controls.Add(KeyGroupBox);
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
        private void PolyalphabeticLabel_Click(object sender, EventArgs e)
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

            SubstitutionContainer.Panel2.Controls.Clear();
            SubstitutionContainer.Panel2.Controls.Add(DecryptButton);
            SubstitutionContainer.Panel2.Controls.Add(EncryptButton);
            SubstitutionContainer.Panel2.Controls.Add(KeyModeGroupBox);
            SubstitutionContainer.Panel2.Controls.Add(KeyText);
            SubstitutionContainer.Panel2.Controls.Add(KeyLabel);
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
        private void RailFenceLabel_Click(object sender, EventArgs e)
        {
            TextBox DepthLevelText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Rail Fence Depth Level", new Size(260, 45));
            KeyGroupBox.Controls.Add(DepthLevelText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RailFenceEncryptButton_Click(sender1, e1, (int.Parse(DepthLevelText.Text))); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RailFenceDecryptButton_Click(sender1, e1, (int.Parse(DepthLevelText.Text))); };

            TranspositionContainer.Panel2.Controls.Clear();
            TranspositionContainer.Panel2.Controls.Add(DecryptButton);
            TranspositionContainer.Panel2.Controls.Add(EncryptButton);
            TranspositionContainer.Panel2.Controls.Add(KeyGroupBox);
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
        private void ColumnarCipherLabel_Click(object sender, EventArgs e)
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("Columnar Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { ColumnarEncryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { ColumnarDecryptButton_Click(sender1, e1, (int.Parse(KeyText.Text))); };

            TranspositionContainer.Panel2.Controls.Clear();
            TranspositionContainer.Panel2.Controls.Add(DecryptButton);
            TranspositionContainer.Panel2.Controls.Add(EncryptButton);
            TranspositionContainer.Panel2.Controls.Add(KeyGroupBox);
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

        #region Data Encryption Standard (DES) Encryption/Decryption
        private void DESLabel_Click(object sender, EventArgs e)
        {
            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { DESEncryptButton_Click(sender1, e1); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { DESDecryptButton_Click(sender1, e1); };

            BlockCipherContainer.Panel2.Controls.Clear();
            BlockCipherContainer.Panel2.Controls.Add(DecryptButton);
            BlockCipherContainer.Panel2.Controls.Add(EncryptButton);
        }
        void DESEncryptButton_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Encrypt(OriginalTextBox.Text);
        }
        void DESDecryptButton_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            ModifiedTextBox.Text = des.Decrypt(OriginalTextBox.Text);
        }
        #endregion

        #region Triple DES Encryption/Decryption
        private void TripleDESLabel_Click(object sender, EventArgs e)
        {
            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { TripleDESEncryptButton_Click(sender1, e1); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { TripleDESDecryptButton_Click(sender1, e1); };

            BlockCipherContainer.Panel2.Controls.Clear();
            BlockCipherContainer.Panel2.Controls.Add(DecryptButton);
            BlockCipherContainer.Panel2.Controls.Add(EncryptButton);
        }
        void TripleDESEncryptButton_Click(object sender, EventArgs e)
        {
            //DES des = new DES();
            //ModifiedTextBox.Text = des.Encrypt(OriginalTextBox.Text);
        }
        void TripleDESDecryptButton_Click(object sender, EventArgs e)
        {
            //DES des = new DES();
            //ModifiedTextBox.Text = des.Decrypt(OriginalTextBox.Text);
        }
        #endregion

        #region AES Encryption/Decryption
        private void AESLabel_Click(object sender, EventArgs e)
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("AES Hexadecimal Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { AESEncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { AESDecryptButton_Click(sender1, e1, KeyText.Text); };

            BlockCipherContainer.Panel2.Controls.Clear();
            BlockCipherContainer.Panel2.Controls.Add(DecryptButton);
            BlockCipherContainer.Panel2.Controls.Add(EncryptButton);
            BlockCipherContainer.Panel2.Controls.Add(KeyGroupBox);
        }
        void AESEncryptButton_Click(object sender, EventArgs e, string HexadecimalKey)
        {
            AES aes = new AES();
            ModifiedTextBox.Text = aes.Encrypt(OriginalTextBox.Text, HexadecimalKey);
        }
        void AESDecryptButton_Click(object sender, EventArgs e, string HexadecimalKey)
        {
            AES aes = new AES();
            ModifiedTextBox.Text = aes.Decrypt(OriginalTextBox.Text, HexadecimalKey);
        }
        #endregion

        #endregion

        #region Stream Cipher

        #region RC4
        private void RC4Label_Click(object sender, EventArgs e)
        {
            TextBox KeyText = DefineTextBox();
            GroupBox KeyGroupBox = DefineGroupBox("RC4 Key", new Size(260, 45));
            KeyGroupBox.Controls.Add(KeyText);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RC4EncryptButton_Click(sender1, e1, KeyText.Text); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RC4DecryptButton_Click(sender1, e1, KeyText.Text); };

            StreamCipherContainer.Panel2.Controls.Clear();
            StreamCipherContainer.Panel2.Controls.Add(DecryptButton);
            StreamCipherContainer.Panel2.Controls.Add(EncryptButton);
            StreamCipherContainer.Panel2.Controls.Add(KeyGroupBox);
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
        private void RSALabel_Click(object sender, EventArgs e)
        {
            Label FirstNumberLabel = DefineLabel("First Number (p)");
            TextBox FirstNumberText = DefineTextBox();
            Label SecondNumberLabel = DefineLabel("Second Number (q)");
            TextBox SecondNumberText = DefineTextBox();
            GroupBox InputGroupBox = DefineGroupBox("", new Size(300, 90));
            InputGroupBox.Controls.Add(SecondNumberText);
            InputGroupBox.Controls.Add(SecondNumberLabel);
            InputGroupBox.Controls.Add(FirstNumberText);
            InputGroupBox.Controls.Add(FirstNumberLabel);

            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { RSAEncryptButton_Click(sender1, e1, int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text)); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { RSADecryptButton_Click(sender1, e1, int.Parse(FirstNumberText.Text), int.Parse(SecondNumberText.Text)); };

            PublicKeyCryptosystemsContainer.Panel2.Controls.Clear();
            PublicKeyCryptosystemsContainer.Panel2.Controls.Add(DecryptButton);
            PublicKeyCryptosystemsContainer.Panel2.Controls.Add(EncryptButton);
            PublicKeyCryptosystemsContainer.Panel2.Controls.Add(InputGroupBox);
        }
        void RSAEncryptButton_Click(object sender, EventArgs e, int p, int q)
        {
            RSA rsa = new RSA();
            ModifiedTextBox.Text = rsa.Encrypt(OriginalTextBox.Text, p, q);
        }
        void RSADecryptButton_Click(object sender, EventArgs e, int p, int q)
        {
            RSA rsa = new RSA();
            ModifiedTextBox.Text = rsa.Decrypt(OriginalTextBox.Text, p, q);
        }
        #endregion

        #region Elliptic Curve
        private void PublicKeyEllipticCurveLabel_Click(object sender, EventArgs e)
        {
            Button EncryptButton = DefineButton("Encrypt");
            Button DecryptButton = DefineButton("Decrypt");
            EncryptButton.Click += delegate(object sender1, EventArgs e1) { PublicKeyEllipticCurveEncryptButton_Click(sender1, e1); };
            DecryptButton.Click += delegate(object sender1, EventArgs e1) { PublicKeyEllipticCurveDecryptButton_Click(sender1, e1); };

            PublicKeyCryptosystemsContainer.Panel2.Controls.Clear();
            PublicKeyCryptosystemsContainer.Panel2.Controls.Add(DecryptButton);
            PublicKeyCryptosystemsContainer.Panel2.Controls.Add(EncryptButton);
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
        private void DiffieHellmanLabel_Click(object sender, EventArgs e)
        {


            #region Radio Buttons GroupBox
            RadioButton SharedKeyRadioButton = DefineRadioButton("Shared Key");
            RadioButton SharedKeyNumberRadioButton = DefineRadioButton("Shared Key with two initial numbers");
            RadioButton PublicNumberRadioButton = DefineRadioButton("Public Number");

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

            Label FirstNumberLabel = DefineLabel("First Initial Number");
            TextBox FirstNumberText = DefineTextBox();
            Label SecondNumberLabel = DefineLabel("Second Initial Number");
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

            KeyExchangeContainer.Panel2.Controls.Clear();
            KeyExchangeContainer.Panel2.Controls.Add(GetKeyButton);
            KeyExchangeContainer.Panel2.Controls.Add(InputGroupBox);
            KeyExchangeContainer.Panel2.Controls.Add(KeyModeGroupBox);
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
                SharedControls[0].Text = "First Initial Number";
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
                SharedControls[0].Text = "Public Number";
            }
        }
        #endregion

        void DiffieHellmanGetKeyButton_Click(object sender, EventArgs e, bool FirstChecked, bool SecondChecked, bool ThirdChecked, int PrimeBase, int PrimitiveRoot, int numOne, int numTwo)
        {
            KeyExchange keyExchange = new KeyExchange();
            if (FirstChecked)
                keyExchange.DiffieHellmanGetSharedKey(PrimeBase, PrimitiveRoot);
            else if (SecondChecked)
                keyExchange.DiffieHellmanGetSharedKey(PrimeBase, PrimitiveRoot,numOne,numTwo);
            else if (ThirdChecked)
                keyExchange.DiffieHellmanGetPublicKey(PrimeBase, PrimitiveRoot,numOne);
        }
        #endregion

        #region Elliptic Curve
        private void KeyExchangeEllipticCurveLabel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        private void ExtendedEuclidMILabel_Click(object sender, EventArgs e)
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
            NumberTheoryContainer.Panel2.Controls.Clear();
            NumberTheoryContainer.Panel2.Controls.Add(MIButton);
            NumberTheoryContainer.Panel2.Controls.Add(InputGroupBox);
        }
        void MIButton_Click(object sender, EventArgs e, int Number, int Base)
        {
            NumberTheory euclidean = new NumberTheory();
            ModifiedTextBox.Text = euclidean.MultiplicativeInverse(Number, Base).ToString();
        }
    }
}