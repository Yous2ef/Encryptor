using System.Security.Cryptography;
using System.Text;

namespace مُشفر
{
    public class Encryption
    {
        /// <summary>
        /// تشفر الملف الموجود في المسار المحدد باستخدام المفتاح المقدم.
        /// يتم إنشاء IV عشوائي ويتم إضافته في بداية الملف المُشفر.
        /// يتم حفظ الملف المُشفر بإضافة امتداد ".enc"، ويتم حذف الملف الأصلي بعد التشفير.
        /// </summary>
        /// <param name="key">مفتاح التشفير (كلمة المرور) كسلسلة.</param>
        /// <param name="filePath">مسار الملف المراد تشفيره.</param>
        public void EncryptFile(string key, string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("الملف غير موجود.", filePath);
            }

            try
            {
                // قراءة محتوى الملف الأصلي.
                byte[] fileContent = File.ReadAllBytes(filePath);

                using (Aes aes = Aes.Create())
                {
                    // استخراج مفتاح 256-بت من السلسلة الموفرة.
                    aes.Key = GetKeyBytes(key);
                    // إنشاء IV عشوائي.
                    aes.IV = GenerateRandomIv();

                    // إنشاء مُشفر باستخدام المفتاح و IV.
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // تحديد مسار الملف الناتج (إضافة ".enc").
                    string outputFilePath = filePath + ".enc";

                    // إنشاء الملف الناتج وكتابة IV أولاً.
                    using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create))
                    {
                        fsOutput.Write(aes.IV, 0, aes.IV.Length);

                        // استخدام CryptoStream لكتابة البيانات المُشفرة.
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(fileContent, 0, fileContent.Length);
                        }
                    }
                }

                // حذف الملف الأصلي بعد الانتهاء من التشفير بنجاح.
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("حدث خطأ أثناء التشفير: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// يفك تشفير الملف المُشفر الموجود في المسار المحدد باستخدام المفتاح المقدم.
        /// يتوقع أن يكون IV مخزنًا في بداية الملف.
        /// إذا كان اسم الملف ينتهي بـ ".enc"، سيتم إزالته في اسم الملف الناتج.
        /// </summary>
        /// <param name="key">مفتاح فك التشفير (كلمة المرور) كسلسلة.</param>
        /// <param name="filePath">مسار الملف المراد فك تشفيره.</param>
        public void DecryptFile(string key, string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("الملف غير موجود.", filePath);
            }

            try
            {
                // قراءة بيانات الملف المُشفر.
                byte[] fileContent = File.ReadAllBytes(filePath);

                using (Aes aes = Aes.Create())
                {
                    // استخراج مفتاح 256-بت من السلسلة الموفرة.
                    aes.Key = GetKeyBytes(key);

                    // تحديد طول IV.
                    int ivLength = aes.BlockSize / 8;
                    if (fileContent.Length < ivLength)
                    {
                        throw new Exception("الملف قصير جدًا بحيث لا يحتوي على IV صالح.");
                    }

                    // استخراج IV من بداية الملف.
                    byte[] iv = new byte[ivLength];
                    Array.Copy(fileContent, 0, iv, 0, ivLength);
                    aes.IV = iv;

                    // إنشاء مفكك تشفير باستخدام المفتاح و IV.
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // إنشاء دفق للبيانات المُشفرة (باستثناء IV).
                    using (MemoryStream msEncrypted = new MemoryStream(fileContent, ivLength, fileContent.Length - ivLength))
                    using (CryptoStream cs = new CryptoStream(msEncrypted, decryptor, CryptoStreamMode.Read))
                    using (MemoryStream msDecrypted = new MemoryStream())
                    {
                        cs.CopyTo(msDecrypted);
                        byte[] decryptedData = msDecrypted.ToArray();

                        // تحديد مسار الملف الناتج.
                        string outputFilePath;
                        if (filePath.EndsWith(".enc", StringComparison.OrdinalIgnoreCase))
                        {
                            outputFilePath = filePath.Substring(0, filePath.Length - 4);
                        }
                        else
                        {
                            outputFilePath = filePath + ".dec";
                        }

                        // كتابة البيانات المفكوكة إلى الملف الناتج.
                        File.WriteAllBytes(outputFilePath, decryptedData);
                    }
                }
                // حذف الملف الأصلي بعد الانتهاء من فك التشفير بنجاح.
                File.Delete(filePath);
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("فشل فك التشفير. ربما يكون المفتاح غير صحيح أو الملف تالف.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("حدث خطأ أثناء فك التشفير: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// تشفر عدة ملفات باستخدام المفتاح المقدم مع تقارير التقدم
        /// </summary>
        /// <param name="key">مفتاح التشفير</param>
        /// <param name="filePaths">مسارات الملفات المراد تشفيرها</param>
        /// <param name="progressReporter">مُقرر التقدم</param>
        /// <param name="cancellationToken">رمز الإلغاء</param>
        public async Task EncryptMultipleFilesAsync(string key, IEnumerable<string> filePaths, 
            ProgressReporter? progressReporter = null, CancellationToken cancellationToken = default)
        {
            var fileList = filePaths.ToList();
            int totalFiles = fileList.Count;
            int processedFiles = 0;

            foreach (string filePath in fileList)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    progressReporter?.ReportProgress(
                        (processedFiles * 100) / totalFiles,
                        Path.GetFileName(filePath),
                        processedFiles,
                        totalFiles
                    );

                    await Task.Run(() => EncryptFile(key, filePath), cancellationToken);
                    progressReporter?.ReportFileProcessed(filePath, true);
                }
                catch (Exception ex)
                {
                    progressReporter?.ReportFileProcessed(filePath, false, ex.Message);
                    progressReporter?.ReportError($"فشل في تشفير الملف: {filePath}", ex);
                }
                finally
                {
                    processedFiles++;
                }
            }

            progressReporter?.ReportProgress(100, "مكتمل", totalFiles, totalFiles);
        }

        /// <summary>
        /// يفك تشفير عدة ملفات باستخدام المفتاح المقدم مع تقارير التقدم
        /// </summary>
        /// <param name="key">مفتاح فك التشفير</param>
        /// <param name="filePaths">مسارات الملفات المراد فك تشفيرها</param>
        /// <param name="progressReporter">مُقرر التقدم</param>
        /// <param name="cancellationToken">رمز الإلغاء</param>
        public async Task DecryptMultipleFilesAsync(string key, IEnumerable<string> filePaths, 
            ProgressReporter? progressReporter = null, CancellationToken cancellationToken = default)
        {
            var fileList = filePaths.ToList();
            int totalFiles = fileList.Count;
            int processedFiles = 0;

            foreach (string filePath in fileList)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    progressReporter?.ReportProgress(
                        (processedFiles * 100) / totalFiles,
                        Path.GetFileName(filePath),
                        processedFiles,
                        totalFiles
                    );

                    await Task.Run(() => DecryptFile(key, filePath), cancellationToken);
                    progressReporter?.ReportFileProcessed(filePath, true);
                }
                catch (Exception ex)
                {
                    progressReporter?.ReportFileProcessed(filePath, false, ex.Message);
                    progressReporter?.ReportError($"فشل في فك تشفير الملف: {filePath}", ex);
                }
                finally
                {
                    processedFiles++;
                }
            }

            progressReporter?.ReportProgress(100, "مكتمل", totalFiles, totalFiles);
        }

        /// <summary>
        /// تشفر مجلد كامل مع جميع محتوياته بشكل تكراري
        /// </summary>
        /// <param name="key">مفتاح التشفير</param>
        /// <param name="folderPath">مسار المجلد</param>
        /// <param name="progressReporter">مُقرر التقدم</param>
        /// <param name="cancellationToken">رمز الإلغاء</param>
        public async Task EncryptFolderAsync(string key, string folderPath, 
            ProgressReporter? progressReporter = null, CancellationToken cancellationToken = default)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"المجلد غير موجود: {folderPath}");
            }

            var allFiles = GetAllFilesRecursively(folderPath);
            await EncryptMultipleFilesAsync(key, allFiles, progressReporter, cancellationToken);
        }

        /// <summary>
        /// يفك تشفير مجلد كامل مع جميع محتوياته بشكل تكراري
        /// </summary>
        /// <param name="key">مفتاح فك التشفير</param>
        /// <param name="folderPath">مسار المجلد</param>
        /// <param name="progressReporter">مُقرر التقدم</param>
        /// <param name="cancellationToken">رمز الإلغاء</param>
        public async Task DecryptFolderAsync(string key, string folderPath, 
            ProgressReporter? progressReporter = null, CancellationToken cancellationToken = default)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"المجلد غير موجود: {folderPath}");
            }

            var encryptedFiles = GetAllFilesRecursively(folderPath)
                .Where(f => f.EndsWith(".enc", StringComparison.OrdinalIgnoreCase));
            
            await DecryptMultipleFilesAsync(key, encryptedFiles, progressReporter, cancellationToken);
        }

        /// <summary>
        /// تشفر عدة مجلدات باستخدام المفتاح المقدم
        /// </summary>
        /// <param name="key">مفتاح التشفير</param>
        /// <param name="folderPaths">مسارات المجلدات</param>
        /// <param name="progressReporter">مُقرر التقدم</param>
        /// <param name="cancellationToken">رمز الإلغاء</param>
        public async Task EncryptMultipleFoldersAsync(string key, IEnumerable<string> folderPaths, 
            ProgressReporter? progressReporter = null, CancellationToken cancellationToken = default)
        {
            var allFiles = new List<string>();
            
            foreach (string folderPath in folderPaths)
            {
                if (Directory.Exists(folderPath))
                {
                    allFiles.AddRange(GetAllFilesRecursively(folderPath));
                }
            }

            await EncryptMultipleFilesAsync(key, allFiles, progressReporter, cancellationToken);
        }

        /// <summary>
        /// يفك تشفير عدة مجلدات باستخدام المفتاح المقدم
        /// </summary>
        /// <param name="key">مفتاح فك التشفير</param>
        /// <param name="folderPaths">مسارات المجلدات</param>
        /// <param name="progressReporter">مُقرر التقدم</param>
        /// <param name="cancellationToken">رمز الإلغاء</param>
        public async Task DecryptMultipleFoldersAsync(string key, IEnumerable<string> folderPaths, 
            ProgressReporter? progressReporter = null, CancellationToken cancellationToken = default)
        {
            var allEncryptedFiles = new List<string>();
            
            foreach (string folderPath in folderPaths)
            {
                if (Directory.Exists(folderPath))
                {
                    var encryptedFiles = GetAllFilesRecursively(folderPath)
                        .Where(f => f.EndsWith(".enc", StringComparison.OrdinalIgnoreCase));
                    allEncryptedFiles.AddRange(encryptedFiles);
                }
            }

            await DecryptMultipleFilesAsync(key, allEncryptedFiles, progressReporter, cancellationToken);
        }

        /// <summary>
        /// يجلب جميع الملفات في المجلد والمجلدات الفرعية بشكل تكراري
        /// </summary>
        /// <param name="folderPath">مسار المجلد</param>
        /// <returns>قائمة بمسارات جميع الملفات</returns>
        private static List<string> GetAllFilesRecursively(string folderPath)
        {
            var files = new List<string>();
            
            try
            {
                // إضافة الملفات في المجلد الحالي
                files.AddRange(Directory.GetFiles(folderPath));
                
                // إضافة الملفات من المجلدات الفرعية
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

        /// <summary>
        /// ينشئ IV عشوائي باستخدام AES.
        /// </summary>
        /// <returns>مصفوفة بايت تحتوي على IV.</returns>
        public static byte[] GenerateRandomIv()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        /// <summary>
        /// يستخرج مفتاح 256-بت من السلسلة الموفرة باستخدام SHA-256.
        /// </summary>
        /// <param name="key">السلسلة المستخدمة كمفتاح.</param>
        /// <returns>مصفوفة بايت تحتوي على مفتاح 256-بت.</returns>
        private static byte[] GetKeyBytes(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
        }
    }
}
