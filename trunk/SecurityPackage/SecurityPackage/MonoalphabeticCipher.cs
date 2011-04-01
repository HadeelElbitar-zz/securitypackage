using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class MonoalphabeticCipher
    {
        #region Constructors
        string PlainText, CipherText;
        Dictionary<char , char> Key = new Dictionary<char,char>();
        char[] Alphabetic = { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z' };
        public MonoalphabeticCipher() { }
        public MonoalphabeticCipher(string _PlainText , string _Key) 
        {
            PlainText = _PlainText;
            for (int i = 0; i < 26; i++)
            {
                Key.Add(Alphabetic[i], _Key[i]);
                Key.Add(Alphabetic[i + 1], _Key[i]);
            }
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            if(Key.Count == 0 || PlainText == null)
                return "Please choose a valid Plain Text and Key !";
            CipherText = "";
            foreach (char item in PlainText)
                CipherText += Key[item];
            return CipherText;
        }
        public string Encrypt(string _Key)
        {
            if (PlainText == null)
                return "Please choose a valid Plain Text !";
            for (int i = 0; i < 26; i++)
            {
                Key.Add(Alphabetic[i], _Key[i]);
                Key.Add(Alphabetic[i + 1], _Key[i]);
            }
            CipherText = "";
            foreach (char item in PlainText)
                CipherText += Key[item];
            return CipherText;
        }
        public string Encrypt(string _PlainText, string _Key)
        {
            Dictionary<char, char> TempKey = new Dictionary<char, char>();
            for (int i = 0; i < 26; i++)
            {
                TempKey.Add(Alphabetic[i], _Key[i]);
                TempKey.Add(Alphabetic[i + 1], _Key[i]);
            }
            string CT = "";
            foreach (char item in _PlainText)
                CT += TempKey[item];
            return CT;
        }
        #endregion

        #region Decryption
        public string Decrypt()
        {
            if (CipherText == null)
                return "Text didn't got encrypted !";
            string PlainText = "";
            foreach (char p in CipherText)
                foreach (KeyValuePair<char , char> pair in Key)
                    if (pair.Value == p)
                    {
                        PlainText += pair.Key;
                        break;
                    }
            return PlainText;
        }
        public string Decrypt(string _Key)
        {
            if (CipherText == null)
                return "Text didn't got encrypted !";
            string PlainText = "";
            for (int i = 0; i < 26; i++)
            {
                Key.Add(Alphabetic[i], _Key[i]);
                Key.Add(Alphabetic[i + 1], _Key[i]);
            }
            foreach (char p in CipherText)
                foreach (KeyValuePair<char, char> pair in Key)
                    if (pair.Value == p)
                    {
                        PlainText += pair.Key;
                        break;
                    }
            return PlainText;
        }
        public string Decrypt(string _CipherText, string _Key)
        {
            string PT = "";
            Dictionary<char, char> TempKey = new Dictionary<char, char>();
            for (int i = 0; i < 26; i++)
            {
                TempKey.Add(Alphabetic[i], _Key[i]);
                TempKey.Add(Alphabetic[i + 1], _Key[i]);
            }
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
