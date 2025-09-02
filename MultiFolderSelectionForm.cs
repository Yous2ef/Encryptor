using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace مُشفر
{
    public partial class MultiFolderSelectionForm : Form
    {
        public List<string> SelectedFolders { get; private set; } = new List<string>();

        public MultiFolderSelectionForm()
        {
            InitializeComponent();
            
            // تخصيص شكل النموذج
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "اختر مجلد لإضافته";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    
                    // التأكد من عدم إضافة نفس المجلد مرتين
                    if (!listBoxFolders.Items.Contains(selectedPath))
                    {
                        listBoxFolders.Items.Add(selectedPath);
                    }
                    else
                    {
                        MessageBox.Show("هذا المجلد موجود بالفعل في القائمة.", "تحذير", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItems.Count > 0)
            {
                // حذف العناصر المحددة
                var itemsToRemove = listBoxFolders.SelectedItems.Cast<string>().ToList();
                
                foreach (string item in itemsToRemove)
                {
                    listBoxFolders.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار مجلد أو أكثر لحذفه.", "تحذير", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listBoxFolders.Items.Count == 0)
            {
                MessageBox.Show("يرجى إضافة مجلد واحد على الأقل.", "تحذير", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تحديث قائمة المجلدات المحددة
            SelectedFolders.Clear();
            SelectedFolders.AddRange(listBoxFolders.Items.Cast<string>());
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}