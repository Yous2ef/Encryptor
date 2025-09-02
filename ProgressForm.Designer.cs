namespace مُشفر
{
    partial class ProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            this.progressBar = new ProgressBar();
            this.lblCurrentFile = new Label();
            this.lblProgress = new Label();
            this.lblFileCount = new Label();
            this.btnCancel = new Button();
            this.listViewFiles = new ListView();
            this.columnHeaderFile = new ColumnHeader();
            this.columnHeaderStatus = new ColumnHeader();
            this.columnHeaderError = new ColumnHeader();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.progressBar.Location = new Point(20, 60);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(540, 30);
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.lblCurrentFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCurrentFile.Location = new Point(20, 20);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.RightToLeft = RightToLeft.Yes;
            this.lblCurrentFile.Size = new Size(540, 20);
            this.lblCurrentFile.TabIndex = 1;
            this.lblCurrentFile.Text = "الملف الحالي: جاري التحضير...";
            this.lblCurrentFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblProgress.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblProgress.Location = new Point(480, 100);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.RightToLeft = RightToLeft.Yes;
            this.lblProgress.Size = new Size(80, 20);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "0%";
            this.lblProgress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFileCount
            // 
            this.lblFileCount.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.lblFileCount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblFileCount.Location = new Point(20, 100);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.RightToLeft = RightToLeft.Yes;
            this.lblFileCount.Size = new Size(450, 20);
            this.lblFileCount.TabIndex = 3;
            this.lblFileCount.Text = "0 من 0 ملف";
            this.lblFileCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.btnCancel.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(480, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.listViewFiles.Columns.AddRange(new ColumnHeader[] {
            this.columnHeaderFile,
            this.columnHeaderStatus,
            this.columnHeaderError});
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.GridLines = true;
            this.listViewFiles.Location = new Point(20, 140);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.RightToLeft = RightToLeft.Yes;
            this.listViewFiles.RightToLeftLayout = true;
            this.listViewFiles.Size = new Size(540, 200);
            this.listViewFiles.TabIndex = 5;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = View.Details;
            // 
            // columnHeaderFile
            // 
            this.columnHeaderFile.Text = "الملف";
            this.columnHeaderFile.Width = 300;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "الحالة";
            this.columnHeaderStatus.Width = 100;
            // 
            // columnHeaderError
            // 
            this.columnHeaderError.Text = "الخطأ";
            this.columnHeaderError.Width = 140;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCurrentFile);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Controls.Add(this.lblFileCount);
            this.panel1.Controls.Add(this.listViewFiles);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(580, 360);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = Color.FromArgb(248, 249, 250);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.Location = new Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(580, 55);
            this.panel2.TabIndex = 7;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(580, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            //this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new Size(600, 450);
            this.Name = "ProgressForm";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "تقدم العملية";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBar progressBar;
        private Label lblCurrentFile;
        private Label lblProgress;
        private Label lblFileCount;
        private Button btnCancel;
        private ListView listViewFiles;
        private ColumnHeader columnHeaderFile;
        private ColumnHeader columnHeaderStatus;
        private ColumnHeader columnHeaderError;
        private Panel panel1;
        private Panel panel2;
    }
}