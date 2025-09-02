namespace مُشفر
{
    partial class MultiFolderSelectionForm
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
            listBoxFolders = new ListBox();
            btnAddFolder = new Button();
            btnRemoveFolder = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxFolders
            // 
            listBoxFolders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxFolders.Font = new Font("Segoe UI", 9F);
            listBoxFolders.FormattingEnabled = true;
            listBoxFolders.Location = new Point(18, 38);
            listBoxFolders.Margin = new Padding(3, 2, 3, 2);
            listBoxFolders.Name = "listBoxFolders";
            listBoxFolders.RightToLeft = RightToLeft.Yes;
            listBoxFolders.SelectionMode = SelectionMode.MultiExtended;
            listBoxFolders.Size = new Size(389, 229);
            listBoxFolders.TabIndex = 0;
            // 
            // btnAddFolder
            // 
            btnAddFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddFolder.BackColor = Color.FromArgb(25, 135, 84);
            btnAddFolder.FlatAppearance.BorderSize = 0;
            btnAddFolder.FlatStyle = FlatStyle.Flat;
            btnAddFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddFolder.ForeColor = Color.White;
            btnAddFolder.Location = new Point(423, 38);
            btnAddFolder.Margin = new Padding(3, 2, 3, 2);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(88, 26);
            btnAddFolder.TabIndex = 1;
            btnAddFolder.Text = "إضافة مجلد";
            btnAddFolder.UseVisualStyleBackColor = false;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // btnRemoveFolder
            // 
            btnRemoveFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveFolder.BackColor = Color.FromArgb(220, 53, 69);
            btnRemoveFolder.FlatAppearance.BorderSize = 0;
            btnRemoveFolder.FlatStyle = FlatStyle.Flat;
            btnRemoveFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveFolder.ForeColor = Color.White;
            btnRemoveFolder.Location = new Point(423, 75);
            btnRemoveFolder.Margin = new Padding(3, 2, 3, 2);
            btnRemoveFolder.Name = "btnRemoveFolder";
            btnRemoveFolder.Size = new Size(88, 26);
            btnRemoveFolder.TabIndex = 2;
            btnRemoveFolder.Text = "حذف مجلد";
            btnRemoveFolder.UseVisualStyleBackColor = false;
            btnRemoveFolder.Click += btnRemoveFolder_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.BackColor = Color.FromArgb(13, 110, 253);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(441, 8);
            btnOK.Margin = new Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(70, 26);
            btnOK.TabIndex = 3;
            btnOK.Text = "موافق";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(362, 8);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(70, 26);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(18, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(493, 19);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "اختيار مجلدات متعددة";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(listBoxFolders);
            panel1.Controls.Add(btnAddFolder);
            panel1.Controls.Add(btnRemoveFolder);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 282);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(248, 249, 250);
            panel2.Controls.Add(btnOK);
            panel2.Controls.Add(btnCancel);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 282);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 41);
            panel2.TabIndex = 7;
            // 
            // MultiFolderSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(528, 323);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(544, 362);
            Name = "MultiFolderSelectionForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اختيار مجلدات متعددة";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxFolders;
        private Button btnAddFolder;
        private Button btnRemoveFolder;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTitle;
        private Panel panel1;
        private Panel panel2;
    }
}