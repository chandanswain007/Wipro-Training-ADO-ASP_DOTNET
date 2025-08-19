﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureAppl
{
    // This class must be public to be seen by other projects
    public static class EncryptionHelper
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("YourSuperSecretKey32charslong!!!");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("YourSecretIV16ch");

        public static string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            var buffer = Convert.FromBase64String(cipherText);
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(buffer))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}