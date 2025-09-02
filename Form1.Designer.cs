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
            panel1 = new Panel();
            lblTitle = new Label();
            lblDescription = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FilePath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_RandomKey).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 58, 64);
            label1.Location = new Point(540, 20);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(164, 21);
            label1.TabIndex = 0;
            label1.Text = "اختيار الملفات/المجلدات";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(52, 58, 64);
            label2.Location = new Point(607, 80);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(54, 21);
            label2.TabIndex = 1;
            label2.Text = "المفتاح";
            // 
            // txt_FilePath
            // 
            txt_FilePath.BackColor = Color.White;
            txt_FilePath.BorderStyle = BorderStyle.FixedSingle;
            txt_FilePath.Font = new Font("Segoe UI", 11F);
            txt_FilePath.Location = new Point(60, 20);
            txt_FilePath.Multiline = true;
            txt_FilePath.Name = "txt_FilePath";
            txt_FilePath.ReadOnly = true;
            txt_FilePath.RightToLeft = RightToLeft.Yes;
            txt_FilePath.Size = new Size(470, 40);
            txt_FilePath.TabIndex = 2;
            txt_FilePath.Text = "انقر على الأيقونة لاختيار الملفات أو المجلدات";
            txt_FilePath.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_key
            // 
            txt_key.BackColor = Color.White;
            txt_key.BorderStyle = BorderStyle.FixedSingle;
            txt_key.Font = new Font("Segoe UI", 11F);
            txt_key.Location = new Point(60, 80);
            txt_key.Name = "txt_key";
            txt_key.RightToLeft = RightToLeft.Yes;
            txt_key.Size = new Size(470, 27);
            txt_key.TabIndex = 3;
            // 
            // btn_Decrypt
            // 
            btn_Decrypt.BackColor = Color.FromArgb(220, 53, 69);
            btn_Decrypt.Cursor = Cursors.Hand;
            btn_Decrypt.FlatAppearance.BorderSize = 0;
            btn_Decrypt.FlatStyle = FlatStyle.Flat;
            btn_Decrypt.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_Decrypt.ForeColor = Color.White;
            btn_Decrypt.Location = new Point(340, 17);
            btn_Decrypt.Name = "btn_Decrypt";
            btn_Decrypt.Size = new Size(169, 45);
            btn_Decrypt.TabIndex = 4;
            btn_Decrypt.Text = "فك التشفير ";
            btn_Decrypt.UseVisualStyleBackColor = false;
            btn_Decrypt.Click += btn_Decrypt_Click;
            // 
            // btn_Encrypt
            // 
            btn_Encrypt.BackColor = Color.FromArgb(25, 135, 84);
            btn_Encrypt.Cursor = Cursors.Hand;
            btn_Encrypt.FlatAppearance.BorderSize = 0;
            btn_Encrypt.FlatStyle = FlatStyle.Flat;
            btn_Encrypt.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_Encrypt.ForeColor = Color.White;
            btn_Encrypt.Location = new Point(165, 17);
            btn_Encrypt.Name = "btn_Encrypt";
            btn_Encrypt.Size = new Size(169, 45);
            btn_Encrypt.TabIndex = 5;
            btn_Encrypt.Text = "  تشفير ";
            btn_Encrypt.UseVisualStyleBackColor = false;
            btn_Encrypt.Click += btn_Encrypt_Click;
            // 
            // pictureBox_FilePath
            // 
            pictureBox_FilePath.BackColor = Color.FromArgb(13, 110, 253);
            pictureBox_FilePath.Cursor = Cursors.Hand;
            pictureBox_FilePath.Image = (Image)resources.GetObject("pictureBox_FilePath.Image");
            pictureBox_FilePath.Location = new Point(15, 20);
            pictureBox_FilePath.Name = "pictureBox_FilePath";
            pictureBox_FilePath.Size = new Size(40, 40);
            pictureBox_FilePath.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_FilePath.TabIndex = 6;
            pictureBox_FilePath.TabStop = false;
            pictureBox_FilePath.Click += pictureBox_FilePath_Click;
            // 
            // pictureBox_RandomKey
            // 
            pictureBox_RandomKey.BackColor = Color.White;
            pictureBox_RandomKey.Cursor = Cursors.Hand;
            pictureBox_RandomKey.Image = (Image)resources.GetObject("pictureBox_RandomKey.Image");
            pictureBox_RandomKey.Location = new Point(15, 77);
            pictureBox_RandomKey.Name = "pictureBox_RandomKey";
            pictureBox_RandomKey.Size = new Size(40, 33);
            pictureBox_RandomKey.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_RandomKey.TabIndex = 7;
            pictureBox_RandomKey.TabStop = false;
            pictureBox_RandomKey.Click += pictureBox_RandomKey_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 249, 250);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(lblDescription);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 80);
            panel1.TabIndex = 8;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(13, 110, 253);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(700, 40);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "🔐 برنامج المُشفر المتقدم";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Bottom;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.FromArgb(108, 117, 125);
            lblDescription.Location = new Point(0, 40);
            lblDescription.Name = "lblDescription";
            lblDescription.RightToLeft = RightToLeft.Yes;
            lblDescription.Size = new Size(700, 40);
            lblDescription.TabIndex = 12;
            lblDescription.Text = "يدعم تشفير الملفات والمجلدات المتعددة مع إمكانية متابعة التقدم";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txt_FilePath);
            panel2.Controls.Add(pictureBox_RandomKey);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox_FilePath);
            panel2.Controls.Add(txt_key);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 80);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20);
            panel2.Size = new Size(700, 140);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(248, 249, 250);
            panel3.Controls.Add(btn_Encrypt);
            panel3.Controls.Add(btn_Decrypt);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 220);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20);
            panel3.Size = new Size(700, 85);
            panel3.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 305);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "المُشفر المتقدم - Advanced Encryptor";
            ((System.ComponentModel.ISupportInitialize)pictureBox_FilePath).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_RandomKey).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblTitle;
        private Label lblDescription;
    }
}
