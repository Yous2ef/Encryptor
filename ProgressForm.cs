using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace مُشفر
{
    public partial class ProgressForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Dictionary<string, ListViewItem> _fileItems = new Dictionary<string, ListViewItem>();

        public CancellationToken CancellationToken => _cancellationTokenSource.Token;

        public ProgressForm()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
            
            // تخصيص الشكل العام
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public void UpdateProgress(int percentage, string currentFile, int processedFiles, int totalFiles)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string, int, int>(UpdateProgress), percentage, currentFile, processedFiles, totalFiles);
                return;
            }

            progressBar.Value = Math.Min(percentage, 100);
            lblProgress.Text = $"{percentage}%";
            lblCurrentFile.Text = $"الملف الحالي: {Path.GetFileName(currentFile)}";
            lblFileCount.Text = $"{processedFiles} من {totalFiles} ملف";
        }

        public void AddFileToList(string filePath)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddFileToList), filePath);
                return;
            }

            var item = new ListViewItem(new string[] 
            {
                Path.GetFileName(filePath),
                "في الانتظار",
                ""
            });
            
            listViewFiles.Items.Add(item);
            _fileItems[filePath] = item;
        }

        public void UpdateFileStatus(string filePath, bool success, string? errorMessage = null)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, bool, string?>(UpdateFileStatus), filePath, success, errorMessage);
                return;
            }

            if (_fileItems.TryGetValue(filePath, out ListViewItem? item))
            {
                if (success)
                {
                    item.SubItems[1].Text = "مكتمل";
                    item.ForeColor = Color.Green;
                    item.SubItems[2].Text = "";
                }
                else
                {
                    item.SubItems[1].Text = "فشل";
                    item.ForeColor = Color.Red;
                    item.SubItems[2].Text = errorMessage ?? "خطأ غير معروف";
                }
            }
        }

        public void SetCurrentFileProcessing(string filePath)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetCurrentFileProcessing), filePath);
                return;
            }

            if (_fileItems.TryGetValue(filePath, out ListViewItem? item))
            {
                item.SubItems[1].Text = "جاري المعالجة...";
                item.ForeColor = Color.Blue;
                item.EnsureVisible();
            }
        }

        public void SetCompleted()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SetCompleted));
                return;
            }

            lblCurrentFile.Text = "تم الانتهاء من جميع العمليات";
            btnCancel.Text = "إغلاق";
            btnCancel.BackColor = Color.FromArgb(25, 135, 84);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "إغلاق")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _cancellationTokenSource.Cancel();
                btnCancel.Enabled = false;
                btnCancel.Text = "جاري الإلغاء...";
                lblCurrentFile.Text = "جاري إلغاء العملية...";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (btnCancel.Text != "إغلاق")
            {
                var result = MessageBox.Show(
                    "هل تريد إلغاء العملية الجارية؟",
                    "تأكيد الإلغاء",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _cancellationTokenSource.Cancel();
                }
                else
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }
    }
}