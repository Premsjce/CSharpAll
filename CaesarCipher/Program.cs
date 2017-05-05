using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string inputString = Console.ReadLine();
            EncryptDecrypt ed = new EncryptDecrypt();
            string encryptedString = ed.Encrypt(inputString);
            string decryptedString = ed.Decrypt(encryptedString);

            Console.WriteLine("Encrypted Text is " + encryptedString);
            Console.WriteLine();
            Console.WriteLine("Decrypted Text is " + decryptedString);
        }
    }
}
