using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class MonoalphabeticCipher
    {
        #region Constructors
        char[] Alphabetic = { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z' };
        public MonoalphabeticCipher() { }
        #endregion

        #region Encryption
        public string Encrypt(string PlainText, string Key)
        {
            Dictionary<char, char> TempKey = new Dictionary<char, char>();
            PlainText = PlainText.Replace(" ", "");
            for (int i = 0, j = 0; j < 26; i += 2, j++)
            {
                TempKey.Add(Alphabetic[i], Key[j]);
                TempKey.Add(Alphabetic[i + 1], Key[j]);
            }
            string CT = "";
            foreach (char item in PlainText)
                CT += TempKey[item];
            return CT;
        }
        #endregion

        #region Decryption
        public string Decrypt(string CipherText, string Key)
        {
            Dictionary<char, char> TempKey = new Dictionary<char, char>();
            CipherText = CipherText.Replace(" ", "");
            for (int i = 0, j = 0; j < 26; i += 2, j++)
            {
                TempKey.Add(Alphabetic[i], Key[j]);
                TempKey.Add(Alphabetic[i + 1], Key[j]);
            }
            string PT = "";
            foreach (char p in CipherText)
                foreach (KeyValuePair<char, char> pair in TempKey)
                    if (pair.Value == p)
                    {
                        PT += pair.Key;
                        break;
                    }
            return PT;
        }
        #endregion
    }
}
