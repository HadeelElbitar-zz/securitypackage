using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class CeaserCipher
    {
        #region Constructors
        /// <summary>
        /// Creates an object of Ceaser Cipher.
        /// </summary>
        public CeaserCipher() { }
        #endregion

        #region Encryption
        /// <summary>
        /// Encrypt the given text using the given key.
        /// </summary>
        /// <param name="PlainText">Text to be encyrpted</param>
        /// <param name="Key">Key to be used in encryption</param>
        /// <returns>It returns a string contains the encrypted text.</returns>
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
        /// <summary>
        /// Decrypt the given text using the given key.
        /// </summary>
        /// <param name="CipherText">Text to be decrypted</param>
        /// <param name="Key">Key to be used in decryption</param>
        /// <returns>It returns a string contains the decrypted text.</returns>
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
