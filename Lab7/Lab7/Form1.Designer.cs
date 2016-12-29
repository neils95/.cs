namespace lab7
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fileSelectionDialog = new System.Windows.Forms.OpenFileDialog();
            this.savedig = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.key = new System.Windows.Forms.TextBox();
            this.encrypt = new System.Windows.Forms.Button();
            this.decrypt = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileSelectionDialog
            // 
            this.fileSelectionDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Key:";
            // 
            // srcfile
            // 
            this.fileTextBox.Location = new System.Drawing.Point(34, 53);
            this.fileTextBox.Name = "srcfile";
            this.fileTextBox.Size = new System.Drawing.Size(388, 26);
            this.fileTextBox.TabIndex = 2;
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(34, 135);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(100, 26);
            this.key.TabIndex = 3;
            // 
            // encrypt
            // 
            this.encrypt.Location = new System.Drawing.Point(34, 182);
            this.encrypt.Name = "encrypt";
            this.encrypt.Size = new System.Drawing.Size(100, 33);
            this.encrypt.TabIndex = 4;
            this.encrypt.Text = "Encrypt";
            this.encrypt.UseVisualStyleBackColor = true;
            this.encrypt.Click += new System.EventHandler(this.encrypt_Click);
            // 
            // decrypt
            // 
            this.decrypt.Location = new System.Drawing.Point(196, 182);
            this.decrypt.Name = "decrypt";
            this.decrypt.Size = new System.Drawing.Size(97, 33);
            this.decrypt.TabIndex = 5;
            this.decrypt.Text = "Decrypt";
            this.decrypt.UseVisualStyleBackColor = true;
            this.decrypt.Click += new System.EventHandler(this.decrypt_Click);
            // 
            // browse
            // 
            this.browse.AutoSize = true;
            this.browse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browse.Image = ((System.Drawing.Image)(resources.GetObject("browse.Image")));
            this.browse.Location = new System.Drawing.Point(428, 47);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(38, 38);
            this.browse.TabIndex = 1;
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 244);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.decrypt);
            this.Controls.Add(this.encrypt);
            this.Controls.Add(this.key);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "File Encrypt/Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileSelectionDialog;
        private System.Windows.Forms.SaveFileDialog savedig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Button encrypt;
        private System.Windows.Forms.Button decrypt;
    
        private System.Windows.Forms.Button browse;
    }
}

