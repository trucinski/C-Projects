using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherMethods
{
    class CaesarCipher
    {
        internal string CaesarShift()
        {
            // cipher text runs UTF-8 21 - 7e.

            char[] cipherText = new char[] { '!', '\"', '#', '$', '%', '&', '\'', '(', ')',
            '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
            'J', 'K', 'L', 'M', 'N', 'O', 'P','Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
            'Z', '[', '\\', ']', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{',
            '|', '}', '~'};

            Console.WriteLine("Enter message to encrypt: ");
            string inputMessage = Console.ReadLine();

            bool parsed = false;
            int parsedOffset = 0;
            while (!parsed)
            {
                Console.WriteLine("What offset do you want to use? ");
                string offsetInput = Console.ReadLine();               
                parsed = Int32.TryParse(offsetInput, out parsedOffset);
            }

            if (parsedOffset < 0)
            {
                parsedOffset = cipherText.Count() + parsedOffset;
            }

            char[] encryptedMessage = new char[inputMessage.Length];

            var inputCharArray = inputMessage.ToCharArray();

            for (int i = 0; i < encryptedMessage.Count(); i++)
            {
                if (inputCharArray[i].Equals(' '))
                {
                    encryptedMessage[i] = ' ';
                    continue;
                }

                for (int j = 0; j < cipherText.Count(); j++)
                {
                    if (inputCharArray[i].Equals(cipherText[j]))
                    {
                        int outputIndex = (j + parsedOffset) % cipherText.Count();
                        encryptedMessage[i] = cipherText[outputIndex];
                        break;
                    }
                }
            }

            return new string(encryptedMessage);
           
        }

        internal string VernamShift()
        {
            throw new NotImplementedException();
        }

        internal string VigenereShiftEncryption()
        {
            char[] cipherText = new char[] { '!', '\"', '#', '$', '%', '&', '\'', '(', ')',
            '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
            'J', 'K', 'L', 'M', 'N', 'O', 'P','Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
            'Z', '[', '\\', ']', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{',
            '|', '}', '~'};


            Console.WriteLine("Enter message to encrypt: ");
            string inputMessage = Console.ReadLine();

            string encryptKey = string.Empty;
            bool keyLength = false;
            do
            {
                Console.WriteLine("Enter a key to encrypt your message with " +
                "\n(must be at least as long as your message):");
                encryptKey = Console.ReadLine();

                if ((inputMessage.Length.Equals(encryptKey.Length)))
                {
                    keyLength = true;
                }
            } while (!keyLength);                       

            char[] encryptedMessage = new char[inputMessage.Length];

            var inputCharArray = inputMessage.ToCharArray();
            var inputKeyArray = encryptKey.ToCharArray();

            
            int messageIndex = 0;
            int keyIndex = 0;            
            
                for (int i = 0; i < inputCharArray.Count(); i++)
                {
                    if (inputCharArray[i].Equals(' '))
                    {
                        encryptedMessage[i] = ' ';
                        continue;
                    }

                    for (int j = 0; j < cipherText.Count(); j++)
                    {
                        if (inputCharArray[i].Equals(cipherText[j]))
                        {
                            messageIndex = j;
                            break;
                        }
                    }                   
                    
                    for (int l = 0; l < cipherText.Count(); l++)
                    {
                        if (inputKeyArray[i].Equals(cipherText[l]))
                        {
                            keyIndex = l;
                            break;
                        }
                    }                                     
                    
                encryptedMessage[i] = cipherText[(messageIndex + keyIndex) % cipherText.Count()];
                }

            return new string(encryptedMessage);            
        }
    }
}
