using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    interface IEncryptDecrypt
    {
        string Encrypt(string inputText);

        string Decrypt(string inputText);
    }
}
