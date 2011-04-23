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
        /// <summary>
        /// To Initialize Object Enter the PlainText you want to Encrypt and the Key of Encryption
        /// </summary>
        /// <param name="_PlainText"></param>
        /// <param name="_Key"></param>
        /// /// <summary>
        /// use it when encrypting only
        /// </summary>
        /// <param name="_PlainText"></param>
        /// <param name="_Key"></param>
        public CeaserCipher(string _PlainText , int _Key)
        {
            PlainText = _PlainText.Replace(" ", "");
            Key = _Key;
        }
        /// <summary>
        /// use it when decrypting only
        /// </summary>
        public CeaserCipher() { }
        #endregion

        #region Encryption
        /// <summary>
        /// Encrypt the PlainText using Key and return CipherText
        /// </summary>
        /// <returns></returns>
        public string Encrypt()
        {
            if (PlainText == null || Key <= 0)
                return "Please choose a valid Plain Text and Key !";
            CipherText = "";
            foreach (char p in PlainText)
                CipherText += Convert.ToChar(Convert.ToInt32(p) + Key);
            return CipherText;
        }
        string Encrypt(int _Key)
        {
            if (PlainText == null)
                return "Please choose a valid Plain Text !";
            CipherText = "";
            Key = _Key;
            foreach (char p in PlainText)
                CipherText += Convert.ToChar(Convert.ToInt32(p) + Key);
            return CipherText;
        }
        string Encrypt(string _PlainText , int _Key)
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
                return "There is no Encrypted CipherText to Decrypt !";
            if (Key <= 0)
                return "please choose a valid key !";
            string PlainText = "";
            foreach (char p in CipherText)
                PlainText += Convert.ToChar(Convert.ToInt32(p) - Key);
            return PlainText;
        }
        string Decrypt(int _Key)
        {
            if (CipherText == null)
                return "Text didn't got encrypted !";
            string PlainText = "";
            Key = _Key;
            foreach (char p in CipherText)
                PlainText += Convert.ToChar(Convert.ToInt32(p) - Key);
            return PlainText;
        }
        string Decrypt(string _CipherText , int _Key)
        {
            string PT = "";
            foreach (char p in _CipherText)
                PT += Convert.ToChar(Convert.ToInt32(p) - Key);
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
                PlainText = value.Replace(" ", "");
            }
        }
        /// <summary>
        /// Set new Key
        /// </summary>
        public int _Key
        {
            set
            {
                Key = value;
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
                CipherText = value.Replace(" ", "");
            }
        }
        #endregion
    }
}
