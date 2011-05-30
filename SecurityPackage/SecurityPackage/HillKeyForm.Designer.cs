namespace SecurityPackage
{
    partial class HillKeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HillKeyForm));
            this.KeyMatrixDataGrid = new System.Windows.Forms.DataGridView();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.EncryptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KeyMatrixDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // KeyMatrixDataGrid
            // 
            this.KeyMatrixDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.KeyMatrixDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.KeyMatrixDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KeyMatrixDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KeyMatrixDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.KeyMatrixDataGrid.Location = new System.Drawing.Point(0, 0);
            this.KeyMatrixDataGrid.Name = "KeyMatrixDataGrid";
            this.KeyMatrixDataGrid.Size = new System.Drawing.Size(800, 348);
            this.KeyMatrixDataGrid.TabIndex = 0;
            // 
            // DecryptButton
            // 
            this.DecryptButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DecryptButton.Location = new System.Drawing.Point(0, 383);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(800, 29);
            this.DecryptButton.TabIndex = 2;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EncryptButton.Location = new System.Drawing.Point(0, 354);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(800, 29);
            this.EncryptButton.TabIndex = 3;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // HillKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.KeyMatrixDataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HillKeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hill Cipher Key Matrix";
            this.Load += new System.EventHandler(this.HillKeyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KeyMatrixDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView KeyMatrixDataGrid;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button EncryptButton;
    }
}