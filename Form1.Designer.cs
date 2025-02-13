namespace مُشفر
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            txt_FilePath = new TextBox();
            txt_key = new TextBox();
            btn_Decrypt = new Button();
            btn_Encrypt = new Button();
            pictureBox_FilePath = new PictureBox();
            pictureBox_RandomKey = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FilePath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_RandomKey).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(694, 16);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(86, 32);
            label1.TabIndex = 0;
            label1.Text = "الملف :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(694, 68);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(94, 32);
            label2.TabIndex = 1;
            label2.Text = "المفتاح :";
            // 
            // txt_FilePath
            // 
            txt_FilePath.Font = new Font("Segoe UI", 16F);
            txt_FilePath.Location = new Point(55, 16);
            txt_FilePath.Name = "txt_FilePath";
            txt_FilePath.RightToLeft = RightToLeft.Yes;
            txt_FilePath.Size = new Size(633, 36);
            txt_FilePath.TabIndex = 2;
            // 
            // txt_key
            // 
            txt_key.Font = new Font("Segoe UI", 16F);
            txt_key.Location = new Point(55, 68);
            txt_key.Name = "txt_key";
            txt_key.RightToLeft = RightToLeft.Yes;
            txt_key.Size = new Size(633, 36);
            txt_key.TabIndex = 3;
            // 
            // btn_Decrypt
            // 
            btn_Decrypt.Cursor = Cursors.Hand;
            btn_Decrypt.Font = new Font("Segoe UI", 18F);
            btn_Decrypt.Location = new Point(383, 139);
            btn_Decrypt.Name = "btn_Decrypt";
            btn_Decrypt.Size = new Size(198, 47);
            btn_Decrypt.TabIndex = 4;
            btn_Decrypt.Text = "فك التشفير";
            btn_Decrypt.UseVisualStyleBackColor = true;
            btn_Decrypt.Click += btn_Decrypt_Click;
            // 
            // btn_Encrypt
            // 
            btn_Encrypt.Cursor = Cursors.Hand;
            btn_Encrypt.Font = new Font("Segoe UI", 18F);
            btn_Encrypt.Location = new Point(163, 139);
            btn_Encrypt.Name = "btn_Encrypt";
            btn_Encrypt.Size = new Size(198, 47);
            btn_Encrypt.TabIndex = 5;
            btn_Encrypt.Text = "تشفير";
            btn_Encrypt.UseVisualStyleBackColor = true;
            btn_Encrypt.Click += btn_Encrypt_Click;
            // 
            // pictureBox_FilePath
            // 
            pictureBox_FilePath.Cursor = Cursors.Hand;
            pictureBox_FilePath.Image = (Image)resources.GetObject("pictureBox_FilePath.Image");
            pictureBox_FilePath.Location = new Point(12, 16);
            pictureBox_FilePath.Name = "pictureBox_FilePath";
            pictureBox_FilePath.Size = new Size(37, 36);
            pictureBox_FilePath.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_FilePath.TabIndex = 6;
            pictureBox_FilePath.TabStop = false;
            pictureBox_FilePath.Click += pictureBox_FilePath_Click;
            // 
            // pictureBox_RandomKey
            // 
            pictureBox_RandomKey.Cursor = Cursors.Hand;
            pictureBox_RandomKey.Image = (Image)resources.GetObject("pictureBox_RandomKey.Image");
            pictureBox_RandomKey.Location = new Point(12, 68);
            pictureBox_RandomKey.Name = "pictureBox_RandomKey";
            pictureBox_RandomKey.Size = new Size(37, 36);
            pictureBox_RandomKey.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_RandomKey.TabIndex = 7;
            pictureBox_RandomKey.TabStop = false;
            pictureBox_RandomKey.Click += pictureBox_RandomKey_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 220);
            Controls.Add(pictureBox_RandomKey);
            Controls.Add(pictureBox_FilePath);
            Controls.Add(btn_Encrypt);
            Controls.Add(btn_Decrypt);
            Controls.Add(txt_key);
            Controls.Add(txt_FilePath);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "المُشفر";
            ((System.ComponentModel.ISupportInitialize)pictureBox_FilePath).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_RandomKey).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txt_FilePath;
        private TextBox txt_key;
        private Button btn_Decrypt;
        private Button btn_Encrypt;
        private PictureBox pictureBox_FilePath;
        private PictureBox pictureBox_RandomKey;
    }
}
