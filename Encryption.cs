using System.Security.Cryptography;
using System.Text;

namespace مُشفر
{
    public class Encryption
    {/// <summary>
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
        public  void DecryptFile(string key, string filePath)
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
