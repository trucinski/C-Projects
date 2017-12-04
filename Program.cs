using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CipherMethods
{
    class Program
    {
        private static readonly CaesarCipher _caesarCipher = new CaesarCipher();

        static void Main(string[] args)
        {
            bool newEncryption = true;

            do
            {
                string encryptedMessage = string.Empty;

                Console.WriteLine("How do you want your message encrypted? " +
                    "\nCaesar Cipher - 1" +
                    "\nVigenere Cipher - 2" +
                    "\nVernam Cipher - 3");
                string encryptChoice = Console.ReadLine();

                switch (encryptChoice)
                {
                    case "1":
                        encryptedMessage = _caesarCipher.CaesarShift();
                        break;
                    case "2":
                        encryptedMessage = _caesarCipher.VigenereShiftEncryption();
                        break;
                    case "3":
                        encryptedMessage = _caesarCipher.VernamShift();
                        break;
                    default:
                        Console.WriteLine("Choice was not recognized.");
                        encryptedMessage = "No message encrypted.";
                        break;
                }
                
                Console.WriteLine(encryptedMessage);
                Console.Write("Do you want to encrypt a new message? Y/N ");

                string contChoice = Console.ReadLine();
                if (contChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    newEncryption = false;
                }

            } while (newEncryption);
            
            
          
        }
                
    }
}
