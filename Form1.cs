using System.Security.Cryptography;
using System.Text;

namespace مُشفر
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Encryption encryption = new Encryption();
        private List<string> selectedFiles = new List<string>();
        private List<string> selectedFolders = new List<string>();

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_key.Text))
                {
                    MessageBox.Show("يرجى إدخال مفتاح التشفير.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحديد نوع العملية بناءً على المحتوى المحدد
                if (selectedFiles.Any() || selectedFolders.Any())
                {
                    ProcessMultipleItemsAsync(true); // تشفير
                }
                else if (!string.IsNullOrWhiteSpace(txt_FilePath.Text))
                {
                    // تشفير ملف واحد (الطريقة القديمة)
                    encryption.EncryptFile(txt_key.Text, txt_FilePath.Text);
                    txt_FilePath.Text = "";
                    MessageBox.Show("تم تشفير الملف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("يرجى اختيار ملف أو مجلد للتشفير.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التشفير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_key.Text))
                {
                    MessageBox.Show("يرجى إدخال مفتاح فك التشفير.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحديد نوع العملية بناءً على المحتوى المحدد
                if (selectedFiles.Any() || selectedFolders.Any())
                {
                    ProcessMultipleItemsAsync(false); // فك التشفير
                }
                else if (!string.IsNullOrWhiteSpace(txt_FilePath.Text))
                {
                    // فك تشفير ملف واحد (الطريقة القديمة)
                    encryption.DecryptFile(txt_key.Text, txt_FilePath.Text);
                    txt_FilePath.Text = "";
                    MessageBox.Show("تم فك تشفير الملف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("يرجى اختيار ملف أو مجلد لفك التشفير.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فك التشفير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ProcessMultipleItemsAsync(bool isEncryption)
        {
            var progressForm = new ProgressForm();
            var progressReporter = new ProgressReporter();

            // ربط الأحداث
            progressReporter.ProgressChanged += (s, e) =>
            {
                progressForm.UpdateProgress(e.Percentage, e.CurrentFile, e.ProcessedFiles, e.TotalFiles);
            };

            progressReporter.FileProcessed += (s, e) =>
            {
                progressForm.UpdateFileStatus(e.FilePath, e.Success, e.ErrorMessage);
            };

            progressReporter.ErrorOccurred += (s, e) =>
            {
                // يمكن إضافة معالجة خاصة للأخطاء هنا
            };

            try
            {
                // جمع جميع الملفات من المجلدات والملفات المحددة
                var allFiles = new List<string>();
                
                // إضافة الملفات المحددة مباشرة
                allFiles.AddRange(selectedFiles);
                
                // إضافة الملفات من المجلدات المحددة
                foreach (string folder in selectedFolders)
                {
                    if (Directory.Exists(folder))
                    {
                        allFiles.AddRange(GetAllFilesRecursively(folder));
                    }
                }

                // تصفية الملفات بناءً على نوع العملية
                if (!isEncryption)
                {
                    allFiles = allFiles.Where(f => f.EndsWith(".enc", StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!allFiles.Any())
                {
                    MessageBox.Show(
                        isEncryption ? "لم يتم العثور على ملفات للتشفير." : "لم يتم العثور على ملفات مشفرة لفك التشفير.",
                        "تحذير",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // إضافة الملفات إلى نموذج التقدم
                foreach (string file in allFiles)
                {
                    progressForm.AddFileToList(file);
                }

                progressForm.Show(this);

                // تنفيذ العملية
                if (isEncryption)
                {
                    await encryption.EncryptMultipleFilesAsync(txt_key.Text, allFiles, progressReporter, progressForm.CancellationToken);
                }
                else
                {
                    await encryption.DecryptMultipleFilesAsync(txt_key.Text, allFiles, progressReporter, progressForm.CancellationToken);
                }

                progressForm.SetCompleted();
                
                // مسح القوائم بعد العملية
                selectedFiles.Clear();
                selectedFolders.Clear();
                UpdateSelectedItemsDisplay();

                MessageBox.Show(
                    isEncryption ? "تم تشفير الملفات بنجاح." : "تم فك تشفير الملفات بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("تم إلغاء العملية بواسطة المستخدم.", "إلغاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static List<string> GetAllFilesRecursively(string folderPath)
        {
            var files = new List<string>();
            
            try
            {
                files.AddRange(Directory.GetFiles(folderPath));
                
                foreach (string subfolder in Directory.GetDirectories(folderPath))
                {
                    files.AddRange(GetAllFilesRecursively(subfolder));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // تجاهل المجلدات التي ليس لدينا صلاحية للوصول إليها
            }
            catch (DirectoryNotFoundException)
            {
                // تجاهل المجلدات المحذوفة أثناء المعالجة
            }

            return files;
        }

        private void pictureBox_FilePath_Click(object sender, EventArgs e)
        {
            // إظهار قائمة خيارات للمستخدم
            var contextMenu = new ContextMenuStrip();
            
            contextMenu.Items.Add("ملف واحد", null, (s, args) => SelectSingleFile());
            contextMenu.Items.Add("ملفات متعددة", null, (s, args) => SelectMultipleFiles());
            contextMenu.Items.Add("مجلد واحد", null, (s, args) => SelectSingleFolder());
            contextMenu.Items.Add("مجلدات متعددة", null, (s, args) => SelectMultipleFolders());
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("مسح التحديد", null, (s, args) => ClearSelection());
            
            contextMenu.Show(Cursor.Position);
        }

        private void SelectSingleFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "كل الملفات (*.*)|*.*";
                openFileDialog.Title = "اختر ملف";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_FilePath.Text = openFileDialog.FileName;
                    selectedFiles.Clear();
                    selectedFolders.Clear();
                }
            }
        }

        private void SelectMultipleFiles()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "كل الملفات (*.*)|*.*";
                openFileDialog.Title = "اختر ملفات متعددة";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFiles.Clear();
                    selectedFiles.AddRange(openFileDialog.FileNames);
                    selectedFolders.Clear();
                    txt_FilePath.Text = "";
                    UpdateSelectedItemsDisplay();
                }
            }
        }

        private void SelectSingleFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "اختر مجلد";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolders.Clear();
                    selectedFolders.Add(folderDialog.SelectedPath);
                    selectedFiles.Clear();
                    txt_FilePath.Text = "";
                    UpdateSelectedItemsDisplay();
                }
            }
        }

        private void SelectMultipleFolders()
        {
            // استخدام نموذج مخصص لاختيار مجلدات متعددة
            var folderSelectionForm = new MultiFolderSelectionForm();
            if (folderSelectionForm.ShowDialog() == DialogResult.OK)
            {
                selectedFolders.Clear();
                selectedFolders.AddRange(folderSelectionForm.SelectedFolders);
                selectedFiles.Clear();
                txt_FilePath.Text = "";
                UpdateSelectedItemsDisplay();
            }
        }

        private void ClearSelection()
        {
            selectedFiles.Clear();
            selectedFolders.Clear();
            txt_FilePath.Text = "";
            UpdateSelectedItemsDisplay();
        }

        private void UpdateSelectedItemsDisplay()
        {
            if (selectedFiles.Any() || selectedFolders.Any())
            {
                var displayText = "";
                
                if (selectedFiles.Any())
                {
                    displayText += $"ملفات محددة: {selectedFiles.Count}";
                }
                
                if (selectedFolders.Any())
                {
                    if (!string.IsNullOrEmpty(displayText)) displayText += " | ";
                    displayText += $"مجلدات محددة: {selectedFolders.Count}";
                }
                
                txt_FilePath.Text = displayText;
            }
        }

        private void pictureBox_RandomKey_Click(object sender, EventArgs e)
        {
            txt_key.Text = GenerateKey(16);
        }

        private static string GenerateKey(int length)
        {
            // Combine upper and lowercase letters, numbers, and symbols for complexity         
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;:',.<>?/~";
            var result = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        var outOfRangeStart = 256 - (256 % allowedChars.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedChars[buf[i] % allowedChars.Length]);
                    }
                }
            }
            return result.ToString();
        }
    }
}
