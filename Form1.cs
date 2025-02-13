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

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // محاولة تشفير الملف باستخدام المفتاح ومسار الملف المدخلين.
                encryption.EncryptFile(txt_key.Text, txt_FilePath.Text);
                txt_FilePath.Text = "";
                MessageBox.Show("تم تشفير الملف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // عرض رسالة الخطأ إذا حدث استثناء أثناء التشفير.
                MessageBox.Show("حدث خطأ أثناء التشفير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // محاولة فك تشفير الملف باستخدام المفتاح ومسار الملف المدخلين.
                encryption.DecryptFile(txt_key.Text, txt_FilePath.Text);
                txt_FilePath.Text = "";
                MessageBox.Show("تم فك تشفير الملف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (CryptographicException ex)
            {
                // في حالة فشل فك التشفير بسبب مفتاح غير صحيح أو تلف الملف.
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // في حالة حدوث أي خطأ آخر.
                MessageBox.Show("حدث خطأ أثناء فك التشفير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_FilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "كل الملفات (*.*)|*.*"; // File types filter
                openFileDialog.Title = "اختر ملف";
                openFileDialog.Multiselect = false; // Allow single file selection

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    txt_FilePath.Text = selectedFilePath;
                }
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
