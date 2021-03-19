using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();

            var p = DecryptString(password);

            Console.WriteLine("Decrypted PAssword: " + p);
            Console.ReadKey();
        }

        private const string Salt = "pass!0nL0g!cAndExecut!0nThr0ugh0urTechn0l0gy123456";

        public static string EncryptString(string normalString)
        {
            const string saltInternal = Salt;

            var utfData = Encoding.UTF8.GetBytes(normalString);

            var saltBytes = Encoding.UTF8.GetBytes(saltInternal);

            string encStr;

            using (var aes = new AesManaged())
            {
                var rfc = new Rfc2898DeriveBytes(saltInternal, saltBytes);

                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;

                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                aes.Key = rfc.GetBytes(aes.KeySize / 8);

                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                using (var encTransform = aes.CreateEncryptor())
                {
                    using (var encStream = new MemoryStream())
                    {
                        using (var encryptor = new CryptoStream(encStream, encTransform, CryptoStreamMode.Write))
                        {
                            encryptor.Write(utfData, 0, utfData.Length);

                            encryptor.Flush();

                            encryptor.Close();

                            var encBytes = encStream.ToArray();

                            encStr = Convert.ToBase64String(encBytes);
                        }
                    }
                }
            }

            return encStr;
        }

        public static string DecryptString(string encryptedString)
        {
            const string saltInternalDecrypt = Salt;

            var encBytes = Convert.FromBase64String(encryptedString);

            var saltBytes = Encoding.UTF8.GetBytes(saltInternalDecrypt);

            string decStr;

            using (var aes = new AesManaged())
            {
                var rfs = new Rfc2898DeriveBytes(saltInternalDecrypt, saltBytes);

                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;

                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                aes.Key = rfs.GetBytes(aes.KeySize / 8);

                aes.IV = rfs.GetBytes(aes.BlockSize / 8);

                using (var decrypt = aes.CreateDecryptor())
                {
                    using (var decryptStream = new MemoryStream())
                    {
                        var decryptor = new CryptoStream(decryptStream, decrypt, CryptoStreamMode.Write);

                        decryptor.Write(encBytes, 0, encBytes.Length);

                        decryptor.Flush();

                        decryptor.Close();

                        var decBytes = decryptStream.ToArray();

                        decStr = Encoding.UTF8.GetString(decBytes, 0, decBytes.Length);
                    }
                }
            }

            return decStr;
        }
    }
}
