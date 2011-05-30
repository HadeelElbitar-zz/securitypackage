using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class CeaserCipher
    {
        #region Constructors
        List<char> Chars;
        /// <summary>
        /// Creates an object of Ceaser Cipher.
        /// </summary>
        public CeaserCipher()
        {
            Chars = new List<char>();
            #region Fill List
            Chars.Add('A');
            Chars.Add('B');
            Chars.Add('C');
            Chars.Add('D');
            Chars.Add('E');
            Chars.Add('F');
            Chars.Add('G');
            Chars.Add('H');
            Chars.Add('I');
            Chars.Add('J');
            Chars.Add('K');
            Chars.Add('L');
            Chars.Add('M');
            Chars.Add('N');
            Chars.Add('O');
            Chars.Add('P');
            Chars.Add('Q');
            Chars.Add('R');
            Chars.Add('S');
            Chars.Add('T');
            Chars.Add('U');
            Chars.Add('V');
            Chars.Add('W');
            Chars.Add('X');
            Chars.Add('Y');
            Chars.Add('Z');
            #endregion
        }
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
            string CT = "";
            PlainText = PlainText.Replace(" ", "").ToUpper();
            int indexRemove = PlainText.IndexOf('\n');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            indexRemove = PlainText.IndexOf('\t');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            int index;
            foreach (char p in PlainText)
            {
                index = Chars.IndexOf(p) + Key;
                if (index < 0)
                    index = 26 - ((-1 * index) % 26);
                index %= 26;
                CT += Chars.ElementAt(index);
            }
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
            CipherText = CipherText.Replace(" ", "").ToUpper();
            int indexRemove = CipherText.IndexOf('\n');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            indexRemove = CipherText.IndexOf('\t');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            string PT = "";
            int index;
            foreach (char p in CipherText)
            {
                index = Chars.IndexOf(p) - Key;
                if (index < 0)
                    index = 26 - ((-1 * index) % 26);
                index %= 26;
                PT += Chars.ElementAt(index);
            }
            return PT;
        }
        #endregion
    }
}
