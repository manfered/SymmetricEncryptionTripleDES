using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryptionTripleDES
{
    class Program
    {
        static void Main(string[] args)
        {
            var trippleDES = new TripleDESEncryption();

            var key = trippleDES.GenerateRandomeNumbers(24);

            var iv = trippleDES.GenerateRandomeNumbers(8);
            const string message = "Message to Encrypt";

            var encrypted = trippleDES.Encrypt(Encoding.UTF8.GetBytes(message), key, iv);
            var decrypted = trippleDES.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("Triple DES Encryption");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Message text = {message}");
            Console.WriteLine($"Encrypted Text = {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrypted text = {decryptedMessage}");
        }
    }
}
