using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class CeaserCipher
    {
        #region Constructors
        public CeaserCipher() { }
        #endregion

        #region Encryption
        public string Encrypt(string PlainText, int Key)
        {
            if (PlainText == null || Key <= 0)
                return "Please choose a valid Plain Text and Key !";
            string CT = "";
            PlainText = PlainText.Replace(" ", "");
            foreach (char p in PlainText)
                CT += Convert.ToChar(Convert.ToInt32(p) + Key);
            return CT;
        }
        #endregion

        #region Decryption
        public string Decrypt(string CipherText, int Key)
        {
            if (CipherText == null)
                return "There is no Encrypted CipherText to Decrypt !";
            if (Key <= 0)
                return "please choose a valid key !";
            CipherText = CipherText.Replace(" ", "");
            string PT = "";
            foreach (char p in CipherText)
                PT += Convert.ToChar(Convert.ToInt32(p) - Key);
            return PT;
        }
        #endregion
    }
}
