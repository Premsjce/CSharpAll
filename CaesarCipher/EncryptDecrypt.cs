using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class EncryptDecrypt : IEncryptDecrypt
    {
        static char[] _charForPassword = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~!@#$%^&*()".ToCharArray();
        static int offset = 8;
        public string Decrypt(string inputText)
        {

            StringBuilder decryptedText = new StringBuilder();

            char[] inputCharArray = inputText.ToCharArray();

            foreach (char ch in inputCharArray)
            {
                int index = Array.IndexOf(_charForPassword, ch);
                decryptedText.Append(_charForPassword[index - offset]);
            }

            return decryptedText.ToString();
        }

        public string Encrypt(string inputText)
        {
            StringBuilder encryptedText = new StringBuilder();

            char[] inputCharArray = inputText.ToCharArray();


            foreach (char ch in inputCharArray)
            {
                int index = Array.IndexOf(_charForPassword, ch);
                encryptedText.Append(_charForPassword[index + offset]);
            }

            return encryptedText.ToString();
        }
    }
}
