using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SymmetricEncryptionTripleDES
{
    public class TripleDESEncryption
    {
        public byte[] GenerateRandomeNumbers(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public byte[] Encrypt(byte[] toBeEncrypted, byte[] key, byte[] iv)
        {
            using (var tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Mode = CipherMode.CBC;
                tripleDES.Padding = PaddingMode.PKCS7;

                tripleDES.Key = key;
                tripleDES.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, tripleDES.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(toBeEncrypted, 0, toBeEncrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] toBeDecrypted, byte[] key, byte[] iv)
        {
            using (var tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Mode = CipherMode.CBC;
                tripleDES.Padding = PaddingMode.PKCS7;

                tripleDES.Key = key;
                tripleDES.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, tripleDES.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(toBeDecrypted, 0, toBeDecrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }

            }
        }
    }
}
