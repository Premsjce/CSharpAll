using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswordGenerator
{
    public class PasswordGenerator
    {

        public static string GetPassword(int offset)
        {
            char[] _charForPassword = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~!@#$%^&*()".ToCharArray();
            StringBuilder _password = new StringBuilder();
            Random _random = new Random();


            for(int i = 0; i< offset; i++)
            {
                _password.Append(_charForPassword[_random.Next(_charForPassword.Length)]);
            }

            return _password.ToString();
        }
    }
}
