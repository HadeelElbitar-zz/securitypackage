using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class CeaserCipher
    {
        #region Constructors 
        string PlainText, CipherText;
        int Key = int.MinValue;
        public CeaserCipher(string _PlainText , int _Key)
        {
            PlainText = _PlainText;
            Key = _Key;
        }
        public CeaserCipher() { }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            if (PlainText == null || Key == int.MinValue)
                return "Please choose a valid Plain Text and Key !";
            CipherText = "";
            foreach (char p in PlainText)
                CipherText += Convert.ToChar(Convert.ToInt32(p) + Key);
            return CipherText;
        }
        public string Encrypt(int _Key)
        {
            if (PlainText == null)
                return "Please choose a valid Plain Text !";
            CipherText = "";
            Key = _Key;
            foreach (char p in PlainText)
                CipherText += Convert.ToChar(Convert.ToInt32(p) + Key);
            return CipherText;
        }
        public string Encrypt(string _PlainText , int _Key)
        {
            string CT = "";
            foreach (char p in PlainText)
                CT += Convert.ToChar(Convert.ToInt32(p) + Key);
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
                PlainText += Convert.ToChar(Convert.ToInt32(p) - Key);
            return PlainText;
        }
        public string Decrypt(int _Key)
        {
            if (CipherText == null)
                return "Text didn't got encrypted !";
            string PlainText = "";
            Key = _Key;
            foreach (char p in CipherText)
                PlainText += Convert.ToChar(Convert.ToInt32(p) - Key);
            return PlainText;
        }
        public string Decrypt(string _CipherText , int _Key)
        {
            string PT = "";
            foreach (char p in _CipherText)
                PT += Convert.ToChar(Convert.ToInt32(p) - Key);
            return PT;
        }
        #endregion
    }
}
