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
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Ceaser Cipher");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Monoalphabetic Cipher");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Playfair Cipher");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Hill Cipher");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Polyalphabetic Cipher");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Substitution Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode55,
            treeNode56,
            treeNode57,
            treeNode58,
            treeNode59});
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("Rail Fence");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("Columnar Cipher");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("Transposition Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode61,
            treeNode62});
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("Classical Encryption Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode60,
            treeNode63});
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("DES");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("Double DES");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("Triple DES");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("AES");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("Block Cipher", new System.Windows.Forms.TreeNode[] {
            treeNode65,
            treeNode66,
            treeNode67,
            treeNode68});
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("RC4");
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("Stream Cipher", new System.Windows.Forms.TreeNode[] {
            treeNode70});
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("RSA");
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("Elliptic Curve");
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("Public Key Cryptosystems", new System.Windows.Forms.TreeNode[] {
            treeNode72,
            treeNode73});
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("Diffie - Hellman");
            System.Windows.Forms.TreeNode treeNode76 = new System.Windows.Forms.TreeNode("Elliptic Curve");
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("Key Exchange Algorithms", new System.Windows.Forms.TreeNode[] {
            treeNode75,
            treeNode76});
            System.Windows.Forms.TreeNode treeNode78 = new System.Windows.Forms.TreeNode("Extended Euclid\'s Algorithm (Multiplicative Inverse of a Number Under Base N)");
            System.Windows.Forms.TreeNode treeNode79 = new System.Windows.Forms.TreeNode("Greatest Common Divisor");
            System.Windows.Forms.TreeNode treeNode80 = new System.Windows.Forms.TreeNode("Big Power");
            System.Windows.Forms.TreeNode treeNode81 = new System.Windows.Forms.TreeNode("Number Theory", new System.Windows.Forms.TreeNode[] {
            treeNode78,
            treeNode79,
            treeNode80});
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
            this.CiphersAndTextContainer.Size = new System.Drawing.Size(435, 583);
            this.CiphersAndTextContainer.SplitterDistance = 289;
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
            this.TextContainer.Size = new System.Drawing.Size(433, 287);
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
            this.OriginalTextContainer.Size = new System.Drawing.Size(215, 287);
            this.OriginalTextContainer.SplitterDistance = 43;
            this.OriginalTextContainer.TabIndex = 2;
            // 
            // OriginalTextLabel
            // 
            this.OriginalTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextLabel.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalTextLabel.ForeColor = System.Drawing.Color.Orange;
            this.OriginalTextLabel.Location = new System.Drawing.Point(0, 0);
            this.OriginalTextLabel.Name = "OriginalTextLabel";
            this.OriginalTextLabel.Size = new System.Drawing.Size(213, 41);
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
            this.OriginalTextBox.Size = new System.Drawing.Size(213, 238);
            this.OriginalTextBox.TabIndex = 0;
            this.OriginalTextBox.Text = "";
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
            this.ModifiedTextContainer.Size = new System.Drawing.Size(214, 287);
            this.ModifiedTextContainer.SplitterDistance = 43;
            this.ModifiedTextContainer.TabIndex = 3;
            // 
            // ModifiedTextLabel
            // 
            this.ModifiedTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextLabel.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            this.ModifiedTextLabel.ForeColor = System.Drawing.Color.Orange;
            this.ModifiedTextLabel.Location = new System.Drawing.Point(0, 0);
            this.ModifiedTextLabel.Name = "ModifiedTextLabel";
            this.ModifiedTextLabel.Size = new System.Drawing.Size(212, 41);
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
            this.ModifiedTextBox.Size = new System.Drawing.Size(212, 238);
            this.ModifiedTextBox.TabIndex = 0;
            this.ModifiedTextBox.Text = "";
            // 
            // CipherCntrolPanel
            // 
            this.CipherCntrolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CipherCntrolPanel.Location = new System.Drawing.Point(0, 0);
            this.CipherCntrolPanel.Name = "CipherCntrolPanel";
            this.CipherCntrolPanel.Size = new System.Drawing.Size(433, 287);
            this.CipherCntrolPanel.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 166);
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
            treeNode55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode55.Name = "CeaserCipherNode";
            treeNode55.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode55.Text = "Ceaser Cipher";
            treeNode56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode56.Name = "MonoalphabeticCipherNode";
            treeNode56.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode56.Text = "Monoalphabetic Cipher";
            treeNode57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode57.Name = "PlayfairCipherNode";
            treeNode57.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode57.Text = "Playfair Cipher";
            treeNode58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode58.Name = "HillCipherNode";
            treeNode58.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode58.Text = "Hill Cipher";
            treeNode59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode59.Name = "PolyalphabeticCipherNode";
            treeNode59.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode59.Text = "Polyalphabetic Cipher";
            treeNode60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode60.Name = "SubstitutionNode";
            treeNode60.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode60.Text = "Substitution Techniques";
            treeNode61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode61.Name = "RailFenceNode";
            treeNode61.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode61.Text = "Rail Fence";
            treeNode62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode62.Name = "ColumnarCipherNode";
            treeNode62.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode62.Text = "Columnar Cipher";
            treeNode63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode63.Name = "TranspositionNode";
            treeNode63.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode63.Text = "Transposition Techniques";
            treeNode64.ForeColor = System.Drawing.Color.Orange;
            treeNode64.Name = "ClassicalEncryptionTechniquesNode";
            treeNode64.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode64.Text = "Classical Encryption Techniques";
            treeNode65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode65.Name = "DESNode";
            treeNode65.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode65.Text = "DES";
            treeNode66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode66.Name = "DoubleDESNode";
            treeNode66.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode66.Text = "Double DES";
            treeNode67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode67.Name = "TripleDESNode";
            treeNode67.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode67.Text = "Triple DES";
            treeNode68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode68.Name = "AESNode";
            treeNode68.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode68.Text = "AES";
            treeNode69.ForeColor = System.Drawing.Color.Orange;
            treeNode69.Name = "BlockCipherNode";
            treeNode69.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode69.Text = "Block Cipher";
            treeNode70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode70.Name = "RC4Node";
            treeNode70.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode70.Text = "RC4";
            treeNode71.ForeColor = System.Drawing.Color.Orange;
            treeNode71.Name = "StreamCipherNode";
            treeNode71.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode71.Text = "Stream Cipher";
            treeNode72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode72.Name = "RSANode";
            treeNode72.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode72.Text = "RSA";
            treeNode73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode73.Name = "EllipticCurveNode";
            treeNode73.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode73.Text = "Elliptic Curve";
            treeNode74.ForeColor = System.Drawing.Color.Orange;
            treeNode74.Name = "PublicKeyCryptosystemNode";
            treeNode74.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode74.Text = "Public Key Cryptosystems";
            treeNode75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode75.Name = "DiffieHellmanNode";
            treeNode75.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode75.Text = "Diffie - Hellman";
            treeNode76.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode76.Name = "EllipticCurveNode";
            treeNode76.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode76.Text = "Elliptic Curve";
            treeNode77.ForeColor = System.Drawing.Color.Orange;
            treeNode77.Name = "KeyExchangeAlgorithmsNode";
            treeNode77.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode77.Text = "Key Exchange Algorithms";
            treeNode78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode78.Name = "ExtendedEuclidAlgorithmNode";
            treeNode78.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode78.Text = "Extended Euclid\'s Algorithm (Multiplicative Inverse of a Number Under Base N)";
            treeNode79.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode79.Name = "GCDNode";
            treeNode79.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode79.Text = "Greatest Common Divisor";
            treeNode80.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode80.Name = "BigPowerNode";
            treeNode80.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode80.Text = "Big Power";
            treeNode81.ForeColor = System.Drawing.Color.Orange;
            treeNode81.Name = "NumberTheoryNode";
            treeNode81.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode81.Text = "Number Theory";
            this.AllCiphersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode64,
            treeNode69,
            treeNode71,
            treeNode74,
            treeNode77,
            treeNode81});
            this.AllCiphersTreeView.ShowLines = false;
            this.AllCiphersTreeView.ShowPlusMinus = false;
            this.AllCiphersTreeView.ShowRootLines = false;
            this.AllCiphersTreeView.Size = new System.Drawing.Size(294, 411);
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
            this.splitContainer1.Size = new System.Drawing.Size(735, 583);
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
            this.splitContainer2.Size = new System.Drawing.Size(294, 581);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 1;
            this.splitContainer2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(735, 607);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.FileMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

