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
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Ceaser Cipher");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Monoalphabetic Cipher");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Playfair Cipher");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Hill Cipher");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Polyalphabetic Cipher");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Substitution Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Rail Fence");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Columnar Cipher");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("Transposition Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode59,
            treeNode60});
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("Classical Encryption Techniques", new System.Windows.Forms.TreeNode[] {
            treeNode58,
            treeNode61});
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("DES");
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("Triple DES");
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("AES");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("Block Cipher", new System.Windows.Forms.TreeNode[] {
            treeNode63,
            treeNode64,
            treeNode65});
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("RC4");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("Stream Cipher", new System.Windows.Forms.TreeNode[] {
            treeNode67});
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("RSA");
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("Elliptic Curve");
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("Public Key Cryptosystems", new System.Windows.Forms.TreeNode[] {
            treeNode69,
            treeNode70});
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("Diffie - Hellman");
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("Elliptic Curve");
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("Key Exchange Algorithms", new System.Windows.Forms.TreeNode[] {
            treeNode72,
            treeNode73});
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("Extended Euclid\'s Algorithm (Multiplicative Inverse of a Number Under Base N)");
            System.Windows.Forms.TreeNode treeNode76 = new System.Windows.Forms.TreeNode("Greatest Common Divisor");
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("Big Power");
            System.Windows.Forms.TreeNode treeNode78 = new System.Windows.Forms.TreeNode("Number Theory", new System.Windows.Forms.TreeNode[] {
            treeNode75,
            treeNode76,
            treeNode77});
            this.FileMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CiphersAndTextContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ModifiedTextContainer = new System.Windows.Forms.SplitContainer();
            this.ModifiedTextLabel = new System.Windows.Forms.Label();
            this.ModifiedTextBox = new System.Windows.Forms.RichTextBox();
            this.OriginalTextContainer = new System.Windows.Forms.SplitContainer();
            this.OriginalTextLabel = new System.Windows.Forms.Label();
            this.OriginalTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AllCiphersContainer = new System.Windows.Forms.SplitContainer();
            this.AllCiphersTreeView = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.FileMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CiphersAndTextContainer)).BeginInit();
            this.CiphersAndTextContainer.Panel1.SuspendLayout();
            this.CiphersAndTextContainer.Panel2.SuspendLayout();
            this.CiphersAndTextContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedTextContainer)).BeginInit();
            this.ModifiedTextContainer.Panel1.SuspendLayout();
            this.ModifiedTextContainer.Panel2.SuspendLayout();
            this.ModifiedTextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalTextContainer)).BeginInit();
            this.OriginalTextContainer.Panel1.SuspendLayout();
            this.OriginalTextContainer.Panel2.SuspendLayout();
            this.OriginalTextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllCiphersContainer)).BeginInit();
            this.AllCiphersContainer.Panel1.SuspendLayout();
            this.AllCiphersContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // FileMenuStrip
            // 
            this.FileMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.FileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.FileMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FileMenuStrip.Name = "FileMenuStrip";
            this.FileMenuStrip.Size = new System.Drawing.Size(848, 24);
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
            this.CiphersAndTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CiphersAndTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CiphersAndTextContainer.Location = new System.Drawing.Point(0, 0);
            this.CiphersAndTextContainer.Name = "CiphersAndTextContainer";
            this.CiphersAndTextContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CiphersAndTextContainer.Panel1
            // 
            this.CiphersAndTextContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // CiphersAndTextContainer.Panel2
            // 
            this.CiphersAndTextContainer.Panel2.Controls.Add(this.AllCiphersContainer);
            this.CiphersAndTextContainer.Size = new System.Drawing.Size(627, 473);
            this.CiphersAndTextContainer.SplitterDistance = 256;
            this.CiphersAndTextContainer.SplitterWidth = 5;
            this.CiphersAndTextContainer.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.13965F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.88122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.13965F));
            this.tableLayoutPanel1.Controls.Add(this.ModifiedTextContainer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.OriginalTextContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 252);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ModifiedTextContainer
            // 
            this.ModifiedTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModifiedTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextContainer.Location = new System.Drawing.Point(431, 3);
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
            this.ModifiedTextContainer.Size = new System.Drawing.Size(189, 246);
            this.ModifiedTextContainer.SplitterDistance = 38;
            this.ModifiedTextContainer.TabIndex = 3;
            // 
            // ModifiedTextLabel
            // 
            this.ModifiedTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextLabel.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            this.ModifiedTextLabel.ForeColor = System.Drawing.Color.Orange;
            this.ModifiedTextLabel.Location = new System.Drawing.Point(0, 0);
            this.ModifiedTextLabel.Name = "ModifiedTextLabel";
            this.ModifiedTextLabel.Size = new System.Drawing.Size(187, 36);
            this.ModifiedTextLabel.TabIndex = 0;
            this.ModifiedTextLabel.Text = "Modified Text";
            this.ModifiedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModifiedTextBox
            // 
            this.ModifiedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ModifiedTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifiedTextBox.ForeColor = System.Drawing.Color.Silver;
            this.ModifiedTextBox.Location = new System.Drawing.Point(0, 0);
            this.ModifiedTextBox.Name = "ModifiedTextBox";
            this.ModifiedTextBox.ReadOnly = true;
            this.ModifiedTextBox.Size = new System.Drawing.Size(187, 202);
            this.ModifiedTextBox.TabIndex = 0;
            this.ModifiedTextBox.Text = "";
            // 
            // OriginalTextContainer
            // 
            this.OriginalTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextContainer.Location = new System.Drawing.Point(3, 3);
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
            this.OriginalTextContainer.Size = new System.Drawing.Size(187, 246);
            this.OriginalTextContainer.SplitterDistance = 38;
            this.OriginalTextContainer.TabIndex = 2;
            // 
            // OriginalTextLabel
            // 
            this.OriginalTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextLabel.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalTextLabel.ForeColor = System.Drawing.Color.Orange;
            this.OriginalTextLabel.Location = new System.Drawing.Point(0, 0);
            this.OriginalTextLabel.Name = "OriginalTextLabel";
            this.OriginalTextLabel.Size = new System.Drawing.Size(185, 36);
            this.OriginalTextLabel.TabIndex = 0;
            this.OriginalTextLabel.Text = "Original Text";
            this.OriginalTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OriginalTextBox
            // 
            this.OriginalTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OriginalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalTextBox.ForeColor = System.Drawing.Color.Silver;
            this.OriginalTextBox.Location = new System.Drawing.Point(0, 0);
            this.OriginalTextBox.Name = "OriginalTextBox";
            this.OriginalTextBox.Size = new System.Drawing.Size(185, 202);
            this.OriginalTextBox.TabIndex = 0;
            this.OriginalTextBox.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(196, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AllCiphersContainer
            // 
            this.AllCiphersContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCiphersContainer.Location = new System.Drawing.Point(0, 0);
            this.AllCiphersContainer.Name = "AllCiphersContainer";
            // 
            // AllCiphersContainer.Panel1
            // 
            this.AllCiphersContainer.Panel1.Controls.Add(this.AllCiphersTreeView);
            this.AllCiphersContainer.Size = new System.Drawing.Size(623, 208);
            this.AllCiphersContainer.SplitterDistance = 336;
            this.AllCiphersContainer.TabIndex = 3;
            // 
            // AllCiphersTreeView
            // 
            this.AllCiphersTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AllCiphersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCiphersTreeView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllCiphersTreeView.Indent = 20;
            this.AllCiphersTreeView.ItemHeight = 25;
            this.AllCiphersTreeView.Location = new System.Drawing.Point(0, 0);
            this.AllCiphersTreeView.Name = "AllCiphersTreeView";
            treeNode53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode53.Name = "CeaserCipherNode";
            treeNode53.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode53.Text = "Ceaser Cipher";
            treeNode54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode54.Name = "MonoalphabeticCipherNode";
            treeNode54.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode54.Text = "Monoalphabetic Cipher";
            treeNode55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode55.Name = "PlayfairCipherNode";
            treeNode55.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode55.Text = "Playfair Cipher";
            treeNode56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode56.Name = "HillCipherNode";
            treeNode56.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode56.Text = "Hill Cipher";
            treeNode57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode57.Name = "PolyalphabeticCipherNode";
            treeNode57.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode57.Text = "Polyalphabetic Cipher";
            treeNode58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode58.Name = "SubstitutionNode";
            treeNode58.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode58.Text = "Substitution Techniques";
            treeNode59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode59.Name = "RailFenceNode";
            treeNode59.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode59.Text = "Rail Fence";
            treeNode60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode60.Name = "ColumnarCipherNode";
            treeNode60.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode60.Text = "Columnar Cipher";
            treeNode61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode61.Name = "TranspositionNode";
            treeNode61.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode61.Text = "Transposition Techniques";
            treeNode62.ForeColor = System.Drawing.Color.Orange;
            treeNode62.Name = "ClassicalEncryptionTechniquesNode";
            treeNode62.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode62.Text = "Classical Encryption Techniques";
            treeNode63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode63.Name = "DESNode";
            treeNode63.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode63.Text = "DES";
            treeNode64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode64.Name = "TripleDESNode";
            treeNode64.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode64.Text = "Triple DES";
            treeNode65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode65.Name = "AESNode";
            treeNode65.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode65.Text = "AES";
            treeNode66.ForeColor = System.Drawing.Color.Orange;
            treeNode66.Name = "BlockCipherNode";
            treeNode66.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode66.Text = "Block Cipher";
            treeNode67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode67.Name = "RC4Node";
            treeNode67.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode67.Text = "RC4";
            treeNode68.ForeColor = System.Drawing.Color.Orange;
            treeNode68.Name = "StreamCipherNode";
            treeNode68.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode68.Text = "Stream Cipher";
            treeNode69.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode69.Name = "RSANode";
            treeNode69.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode69.Text = "RSA";
            treeNode70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode70.Name = "EllipticCurveNode";
            treeNode70.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode70.Text = "Elliptic Curve";
            treeNode71.ForeColor = System.Drawing.Color.Orange;
            treeNode71.Name = "PublicKeyCryptosystemNode";
            treeNode71.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode71.Text = "Public Key Cryptosystems";
            treeNode72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode72.Name = "DiffieHellmanNode";
            treeNode72.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode72.Text = "Diffie - Hellman";
            treeNode73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode73.Name = "EllipticCurveNode";
            treeNode73.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode73.Text = "Elliptic Curve";
            treeNode74.ForeColor = System.Drawing.Color.Orange;
            treeNode74.Name = "KeyExchangeAlgorithmsNode";
            treeNode74.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode74.Text = "Key Exchange Algorithms";
            treeNode75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode75.Name = "ExtendedEuclidAlgorithmNode";
            treeNode75.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode75.Text = "Extended Euclid\'s Algorithm (Multiplicative Inverse of a Number Under Base N)";
            treeNode76.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode76.Name = "GCDNode";
            treeNode76.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode76.Text = "Greatest Common Divisor";
            treeNode77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            treeNode77.Name = "BigPowerNode";
            treeNode77.NodeFont = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold);
            treeNode77.Text = "Big Power";
            treeNode78.ForeColor = System.Drawing.Color.Orange;
            treeNode78.Name = "NumberTheoryNode";
            treeNode78.NodeFont = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold);
            treeNode78.Text = "Number Theory";
            this.AllCiphersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode62,
            treeNode66,
            treeNode68,
            treeNode71,
            treeNode74,
            treeNode78});
            this.AllCiphersTreeView.ShowLines = false;
            this.AllCiphersTreeView.ShowPlusMinus = false;
            this.AllCiphersTreeView.ShowRootLines = false;
            this.AllCiphersTreeView.Size = new System.Drawing.Size(336, 208);
            this.AllCiphersTreeView.TabIndex = 0;
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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CiphersAndTextContainer);
            this.splitContainer1.Size = new System.Drawing.Size(848, 473);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(217, 473);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(848, 497);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ModifiedTextContainer.Panel1.ResumeLayout(false);
            this.ModifiedTextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedTextContainer)).EndInit();
            this.ModifiedTextContainer.ResumeLayout(false);
            this.OriginalTextContainer.Panel1.ResumeLayout(false);
            this.OriginalTextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalTextContainer)).EndInit();
            this.OriginalTextContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.AllCiphersContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllCiphersContainer)).EndInit();
            this.AllCiphersContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        private System.Windows.Forms.SplitContainer AllCiphersContainer;
        private System.Windows.Forms.TreeView AllCiphersTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer ModifiedTextContainer;
        private System.Windows.Forms.Label ModifiedTextLabel;
        private System.Windows.Forms.RichTextBox ModifiedTextBox;
        private System.Windows.Forms.SplitContainer OriginalTextContainer;
        private System.Windows.Forms.Label OriginalTextLabel;
        private System.Windows.Forms.RichTextBox OriginalTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

