namespace SecurityPackage
{
    partial class MainForm
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Ceaser Cipher");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Monoalphabetic Cipher");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Playfair Cipher");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Hill Cipher");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Polyalphabetic Cipher");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Substitution Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Rail Fence");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Columnar Cipher");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Transposition Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Classical Encryption Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("DES");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Triple DES");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("AES");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Block Cipher", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("RC4");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Stream Cipher", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("RSA");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Elliptic Curve");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Public Key Cryptosystems", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Diffie - Hellman");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Elliptic Curve");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Key Exchange Algorithms", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Extended Euclid\'s Algorithm (Multiplicative Inverse of a Number Under Base N)");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Greatest Common Divisor");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Big Power");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Number Theory", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25});
            this.FileMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CiphersAndTextContainer = new System.Windows.Forms.SplitContainer();
            this.TextContainer = new System.Windows.Forms.SplitContainer();
            this.OriginalTextContainer = new System.Windows.Forms.SplitContainer();
            this.OriginalTextLabel = new System.Windows.Forms.Label();
            this.OriginalTextBox = new System.Windows.Forms.RichTextBox();
            this.ModifiedTextContainer = new System.Windows.Forms.SplitContainer();
            this.ModifiedTextLabel = new System.Windows.Forms.Label();
            this.ModifiedTextBox = new System.Windows.Forms.RichTextBox();
            this.CipherCntrolPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AllCiphersTreeView = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FileMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CiphersAndTextContainer)).BeginInit();
            this.CiphersAndTextContainer.Panel1.SuspendLayout();
            this.CiphersAndTextContainer.Panel2.SuspendLayout();
            this.CiphersAndTextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextContainer)).BeginInit();
            this.TextContainer.Panel1.SuspendLayout();
            this.TextContainer.Panel2.SuspendLayout();
            this.TextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalTextContainer)).BeginInit();
            this.OriginalTextContainer.Panel1.SuspendLayout();
            this.OriginalTextContainer.Panel2.SuspendLayout();
            this.OriginalTextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedTextContainer)).BeginInit();
            this.ModifiedTextContainer.Panel1.SuspendLayout();
            this.ModifiedTextContainer.Panel2.SuspendLayout();
            this.ModifiedTextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileMenuStrip
            // 
            this.FileMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.FileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.FileMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FileMenuStrip.Name = "FileMenuStrip";
            this.FileMenuStrip.Size = new System.Drawing.Size(735, 24);
            this.FileMenuStrip.TabIndex = 0;
            this.FileMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // CiphersAndTextContainer
            // 
            this.CiphersAndTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CiphersAndTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CiphersAndTextContainer.Location = new System.Drawing.Point(0, 0);
            this.CiphersAndTextContainer.Name = "CiphersAndTextContainer";
            this.CiphersAndTextContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CiphersAndTextContainer.Panel1
            // 
            this.CiphersAndTextContainer.Panel1.Controls.Add(this.TextContainer);
            // 
            // CiphersAndTextContainer.Panel2
            // 
            this.CiphersAndTextContainer.Panel2.Controls.Add(this.CipherCntrolPanel);
            this.CiphersAndTextContainer.Size = new System.Drawing.Size(435, 480);
            this.CiphersAndTextContainer.SplitterDistance = 238;
            this.CiphersAndTextContainer.SplitterWidth = 5;
            this.CiphersAndTextContainer.TabIndex = 5;
            // 
            // TextContainer
            // 
            this.TextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextContainer.Location = new System.Drawing.Point(0, 0);
            this.TextContainer.Name = "TextContainer";
            // 
            // TextContainer.Panel1
            // 
            this.TextContainer.Panel1.Controls.Add(this.OriginalTextContainer);
            // 
            // TextContainer.Panel2
            // 
            this.TextContainer.Panel2.Controls.Add(this.ModifiedTextContainer);
            this.TextContainer.Size = new System.Drawing.Size(433, 236);
            this.TextContainer.SplitterDistance = 215;
            this.TextContainer.TabIndex = 3;
            // 
            // OriginalTextContainer
            // 
            this.OriginalTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextContainer.Location = new System.Drawing.Point(0, 0);
            this.OriginalTextContainer.Name = "OriginalTextContainer";
            this.OriginalTextContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // OriginalTextContainer.Panel1
            // 
            this.OriginalTextContainer.Panel1.Controls.Add(this.OriginalTextLabel);
            // 
            // OriginalTextContainer.Panel2
            // 
            this.OriginalTextContainer.Panel2.Controls.Add(this.OriginalTextBox);
            this.OriginalTextContainer.Size = new System.Drawing.Size(215, 236);
            this.OriginalTextContainer.SplitterDistance = 36;
            this.OriginalTextContainer.TabIndex = 2;
            // 
            // OriginalTextLabel
            // 
            this.OriginalTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextLabel.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalTextLabel.ForeColor = System.Drawing.Color.Orange;
            this.OriginalTextLabel.Location = new System.Drawing.Point(0, 0);
            this.OriginalTextLabel.Name = "OriginalTextLabel";
            this.OriginalTextLabel.Size = new System.Drawing.Size(213, 34);
            this.OriginalTextLabel.TabIndex = 0;
            this.OriginalTextLabel.Text = "Original Text";
            this.OriginalTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OriginalTextBox
            // 
            this.OriginalTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OriginalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OriginalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.OriginalTextBox.Location = new System.Drawing.Point(0, 0);
            this.OriginalTextBox.Name = "OriginalTextBox";
            this.OriginalTextBox.Size = new System.Drawing.Size(213, 194);
            this.OriginalTextBox.TabIndex = 0;
            this.OriginalTextBox.Text = "";
            this.OriginalTextBox.TextChanged += new System.EventHandler(this.OriginalTextBox_TextChanged);
            // 
            // ModifiedTextContainer
            // 
            this.ModifiedTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModifiedTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextContainer.Location = new System.Drawing.Point(0, 0);
            this.ModifiedTextContainer.Name = "ModifiedTextContainer";
            this.ModifiedTextContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ModifiedTextContainer.Panel1
            // 
            this.ModifiedTextContainer.Panel1.Controls.Add(this.ModifiedTextLabel);
            // 
            // ModifiedTextContainer.Panel2
            // 
            this.ModifiedTextContainer.Panel2.Controls.Add(this.ModifiedTextBox);
            this.ModifiedTextContainer.Size = new System.Drawing.Size(214, 236);
            this.ModifiedTextContainer.SplitterDistance = 36;
            this.ModifiedTextContainer.TabIndex = 3;
            // 
            // ModifiedTextLabel
            // 
            this.ModifiedTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextLabel.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            this.ModifiedTextLabel.ForeColor = System.Drawing.Color.Orange;
            this.ModifiedTextLabel.Location = new System.Drawing.Point(0, 0);
            this.ModifiedTextLabel.Name = "ModifiedTextLabel";
            this.ModifiedTextLabel.Size = new System.Drawing.Size(212, 34);
            this.ModifiedTextLabel.TabIndex = 0;
            this.ModifiedTextLabel.Text = "Modified Text";
            this.ModifiedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModifiedTextBox
            // 
            this.ModifiedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ModifiedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModifiedTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            this.ModifiedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ModifiedTextBox.Location = new System.Drawing.Point(0, 0);
            this.ModifiedTextBox.Name = "ModifiedTextBox";
            this.ModifiedTextBox.ReadOnly = true;
            this.ModifiedTextBox.Size = new System.Drawing.Size(212, 194);
            this.ModifiedTextBox.TabIndex = 0;
            this.ModifiedTextBox.Text = "";
            // 
            // CipherCntrolPanel
            // 
            this.CipherCntrolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CipherCntrolPanel.Location = new System.Drawing.Point(0, 0);
            this.CipherCntrolPanel.Name = "CipherCntrolPanel";
            this.CipherCntrolPanel.Size = new System.Drawing.Size(433, 235);
            this.CipherCntrolPanel.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AllCiphersTreeView
            // 
            this.AllCiphersTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.AllCiphersTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllCiphersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCiphersTreeView.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllCiphersTreeView.ForeColor = System.Drawing.Color.Orange;
            this.AllCiphersTreeView.Indent = 20;
            this.AllCiphersTreeView.ItemHeight = 25;
            this.AllCiphersTreeView.Location = new System.Drawing.Point(0, 0);
            this.AllCiphersTreeView.Name = "AllCiphersTreeView";
            treeNode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode1.Name = "CeaserCipherNode";
            treeNode1.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "Ceaser Cipher";
            treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode2.Name = "MonoalphabeticCipherNode";
            treeNode2.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode2.Text = "Monoalphabetic Cipher";
            treeNode3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode3.Name = "PlayfairCipherNode";
            treeNode3.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode3.Text = "Playfair Cipher";
            treeNode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode4.Name = "HillCipherNode";
            treeNode4.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode4.Text = "Hill Cipher";
            treeNode5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode5.Name = "PolyalphabeticCipherNode";
            treeNode5.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode5.Text = "Polyalphabetic Cipher";
            treeNode6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode6.Name = "SubstitutionNode";
            treeNode6.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "Substitution Techniques";
            treeNode7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode7.Name = "RailFenceNode";
            treeNode7.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode7.Text = "Rail Fence";
            treeNode8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode8.Name = "ColumnarCipherNode";
            treeNode8.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode8.Text = "Columnar Cipher";
            treeNode9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode9.Name = "TranspositionNode";
            treeNode9.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode9.Text = "Transposition Techniques";
            treeNode10.ForeColor = System.Drawing.Color.Orange;
            treeNode10.Name = "ClassicalEncryptionTechniquesNode";
            treeNode10.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode10.Text = "Classical Encryption Techniques";
            treeNode11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode11.Name = "DESNode";
            treeNode11.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode11.Text = "DES";
            treeNode12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode12.Name = "TripleDESNode";
            treeNode12.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode12.Text = "Triple DES";
            treeNode13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode13.Name = "AESNode";
            treeNode13.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode13.Text = "AES";
            treeNode14.ForeColor = System.Drawing.Color.Orange;
            treeNode14.Name = "BlockCipherNode";
            treeNode14.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode14.Text = "Block Cipher";
            treeNode15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode15.Name = "RC4Node";
            treeNode15.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode15.Text = "RC4";
            treeNode16.ForeColor = System.Drawing.Color.Orange;
            treeNode16.Name = "StreamCipherNode";
            treeNode16.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode16.Text = "Stream Cipher";
            treeNode17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode17.Name = "RSANode";
            treeNode17.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode17.Text = "RSA";
            treeNode18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode18.Name = "EllipticCurveNode";
            treeNode18.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode18.Text = "Elliptic Curve";
            treeNode19.ForeColor = System.Drawing.Color.Orange;
            treeNode19.Name = "PublicKeyCryptosystemNode";
            treeNode19.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode19.Text = "Public Key Cryptosystems";
            treeNode20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode20.Name = "DiffieHellmanNode";
            treeNode20.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode20.Text = "Diffie - Hellman";
            treeNode21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode21.Name = "EllipticCurveNode";
            treeNode21.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode21.Text = "Elliptic Curve";
            treeNode22.ForeColor = System.Drawing.Color.Orange;
            treeNode22.Name = "KeyExchangeAlgorithmsNode";
            treeNode22.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode22.Text = "Key Exchange Algorithms";
            treeNode23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode23.Name = "ExtendedEuclidAlgorithmNode";
            treeNode23.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode23.Text = "Extended Euclid\'s Algorithm (Multiplicative Inverse of a Number Under Base N)";
            treeNode24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode24.Name = "GCDNode";
            treeNode24.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode24.Text = "Greatest Common Divisor";
            treeNode25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode25.Name = "BigPowerNode";
            treeNode25.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode25.Text = "Big Power";
            treeNode26.ForeColor = System.Drawing.Color.Orange;
            treeNode26.Name = "NumberTheoryNode";
            treeNode26.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode26.Text = "Number Theory";
            this.AllCiphersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14,
            treeNode16,
            treeNode19,
            treeNode22,
            treeNode26});
            this.AllCiphersTreeView.ShowLines = false;
            this.AllCiphersTreeView.ShowPlusMinus = false;
            this.AllCiphersTreeView.ShowRootLines = false;
            this.AllCiphersTreeView.Size = new System.Drawing.Size(294, 337);
            this.AllCiphersTreeView.TabIndex = 0;
            this.AllCiphersTreeView.TabStop = false;
            this.AllCiphersTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AllCiphersTreeView_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 20);
            this.textBox1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CiphersAndTextContainer);
            this.splitContainer1.Size = new System.Drawing.Size(735, 480);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.AllCiphersTreeView);
            this.splitContainer2.Size = new System.Drawing.Size(294, 478);
            this.splitContainer2.SplitterDistance = 137;
            this.splitContainer2.TabIndex = 1;
            this.splitContainer2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(735, 504);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.FileMenuStrip);
            this.MainMenuStrip = this.FileMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CryptoSpot";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FileMenuStrip.ResumeLayout(false);
            this.FileMenuStrip.PerformLayout();
            this.CiphersAndTextContainer.Panel1.ResumeLayout(false);
            this.CiphersAndTextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CiphersAndTextContainer)).EndInit();
            this.CiphersAndTextContainer.ResumeLayout(false);
            this.TextContainer.Panel1.ResumeLayout(false);
            this.TextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextContainer)).EndInit();
            this.TextContainer.ResumeLayout(false);
            this.OriginalTextContainer.Panel1.ResumeLayout(false);
            this.OriginalTextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalTextContainer)).EndInit();
            this.OriginalTextContainer.ResumeLayout(false);
            this.ModifiedTextContainer.Panel1.ResumeLayout(false);
            this.ModifiedTextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedTextContainer)).EndInit();
            this.ModifiedTextContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer CiphersAndTextContainer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer TextContainer;
        private System.Windows.Forms.TreeView AllCiphersTreeView;
        private System.Windows.Forms.SplitContainer ModifiedTextContainer;
        private System.Windows.Forms.Label ModifiedTextLabel;
        private System.Windows.Forms.RichTextBox ModifiedTextBox;
        private System.Windows.Forms.SplitContainer OriginalTextContainer;
        private System.Windows.Forms.Label OriginalTextLabel;
        private System.Windows.Forms.RichTextBox OriginalTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel CipherCntrolPanel;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

