using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace Hotel.Services
{
    internal class MethodServices
    {
        public static string HashPassword(string password)
        {
            string pass = "";
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            foreach (byte b in tmpHash)
            {
                pass += b.ToString();
            }

            return pass;
        }
        public static string HidePassword()
            {
                string password = "";
                try
                {
                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.Escape:
                                return null;
                            case ConsoleKey.Enter:
                                return password;
                            case ConsoleKey.Backspace:
                                password = password.Substring(0, (password.Length - 1));
                                Console.Write("\b \b");
                                break;
                            default:
                                password += key.KeyChar;
                                Console.Write("*");
                                break;
                        }
                    }
                }
                catch
                {
                    HidePassword();
                }
                return password;
            }

    }
}
