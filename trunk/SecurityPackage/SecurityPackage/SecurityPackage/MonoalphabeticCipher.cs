using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class MonoalphabeticCipher
    {
        #region Constructors
        string PlainText, CipherText, TempKey;
        Dictionary<char , char> Key = new Dictionary<char,char>();
        char[] Alphabetic = { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z' };
        /// <summary>
        /// use it when decrypting only
        /// </summary>
        public MonoalphabeticCipher() { }
        /// <summary>
        /// use it when encrypting only
        /// </summary>
        /// <param name="_PlainText"></param>
        /// <param name="_Key"></param>
        public MonoalphabeticCipher(string _PlainText , string _Key) 
        {
            PlainText = _PlainText.Replace(" ", "");
            PrepareKey(_Key.Replace(" ", ""));
        }
        #endregion

        #region Helping Functions
        void PrepareKey(string NewKey)
        {
            for (int i = 0, j = -1; i < 26; i++)
            {
                Key.Add(Alphabetic[++j], NewKey[i]);
                Key.Add(Alphabetic[++j], NewKey[i]);
            }
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            if(Key.Count < 52 || PlainText == null)
                return "Please choose a valid Plain Text and Key !";
            CipherText = "";
            foreach (char item in PlainText)
                CipherText += Key[item];
            return CipherText;
        }
        string Encrypt(string _Key)
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
        string Encrypt(string _PlainText, string _Key)
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
        string Decrypt(string _Key)
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
        string Decrypt(string _CipherText, string _Key)
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

        #region Setting Properties
        /// <summary>
        /// Set new PlainText
        /// </summary>
        public string _PlainText
        {
            set
            {
                PlainText = value;
                PlainText = PlainText.Replace(" ", "");
            }
        }
        /// <summary>
        /// Set new Key
        /// </summary>
        public string _Key
        {
            set
            {
                TempKey = value;
                PrepareKey(TempKey.Replace(" ", ""));
            }
        }
        /// <summary>
        /// returns the CihperText generated or set new value to Decrypt
        /// </summary>
        public string _CipherText
        {
            get
            {
                return CipherText;
            }
            set
            {
                CipherText = value;
                CipherText = CipherText.Replace(" ", "");
            }
        }
        #endregion
    }
}
