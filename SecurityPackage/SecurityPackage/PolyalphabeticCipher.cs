using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SecurityPackage
{
    class PolyalphabeticCipher
    {
        #region Constructors
        char[,] Matrix = new char[26, 26];
        int KeyMode;
        Dictionary<char, int> AlphaIndex;
        /// <summary>
        /// Creates an object of Polyalphabetic Cipher
        /// </summary>
        public PolyalphabeticCipher() { }
        #endregion

        #region Encryption
        /// <summary>
        /// Encrypts the given text with the given key under the selected mode.
        /// </summary>
        /// <param name="PlainText"> The text to be encrypted</param>
        /// <param name="Key"> String representes the encryption key</param>
        /// <param name="Mode"> An integer represents the key mode: 0 for autokey and 1 for repeat key</param>
        /// <returns>It returns a string contains the encrypted text.</returns>
        public string Encrypt(string PlainText, string Key, int Mode)
        {
            PlainText = PlainText.ToUpper().Replace(" ", "");
            int indexRemove = PlainText.IndexOf('\n');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            indexRemove = PlainText.IndexOf('\t');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            PrepareKey(ref Key, PlainText, Mode);
            string CipherText = "";
            int i = -1;
            foreach (char item in PlainText)
                CipherText += Matrix[AlphaIndex[item], AlphaIndex[Key[++i]]];
            return CipherText;
        }
        #endregion

        #region Decryption
        /// <summary>
        /// Decrypts the given text with the given key under the selected mode.
        /// </summary>
        /// <param name="CipherText">The text to be decrypted</param>
        /// <param name="Key">String representes the encryption key</param>
        /// <param name="Mode">An integer represents the key mode: 0 for autokey and 1 for repeat key</param>
        /// <returns>It returns a string contains the decrypted text.</returns>
        public string Decrypt(string CipherText, string Key, int Mode)
        {
            CipherText = CipherText.ToUpper().Replace(" ", "");
            int indexRemove = CipherText.IndexOf('\n');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            indexRemove = CipherText.IndexOf('\t');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            PrepareKey(ref Key, CipherText, KeyMode);
            string PlainText = "";
            int i = -1;
            foreach (char item in CipherText)
                PlainText += Matrix[SearchMatrixRow(AlphaIndex[Key[++i]], item), 0];
            return PlainText;
        }
        #endregion

        #region Helping Functions

        /// <summary>
        /// Prepares the key  to fit the text length.
        /// </summary>
        /// <param name="Key">The cipher key to be used later.</param>
        /// <param name="PT">The text that's being encrypted/decrypted</param>
        /// <param name="Mode">An integer represents the key mode: 0 for autokey and 1 for repeat key</param>
        void PrepareKey(ref string Key, string PT, int Mode)
        {
            Key = Key.ToUpper().Replace(" ", "");
            int indexRemove = Key.IndexOf('\n');
            if (indexRemove != -1)
                Key = Key.Remove(indexRemove);
            indexRemove = Key.IndexOf('\t');
            if (indexRemove != -1)
                Key = Key.Remove(indexRemove);
            KeyMode = Mode;
            if (Key.Length < PT.Length && KeyMode == 1)
            {
                int Difference = PT.Length - Key.Length;
                int startIndex = PT.Length - Difference;
                Key += PT.Substring(0, Difference);
            }
            else if (Key.Length < PT.Length && KeyMode == 0)
            {
                while (Key.Length < PT.Length)
                    Key += Key;
                Key = Key.Substring(0, PT.Length);
            }
            MessageBox.Show(Key);
            BuildMatrix();
            FillIndex();
        }

        /// <summary>
        /// Builds the 26 X 26 Polyalphabetic Matrix.
        /// </summary>
        void BuildMatrix()
        {
            Matrix = new char[26, 26];
            char Initial = 'A';
            int Incremental, x;
            for (int i = 0; i < 26; i++)
            {
                Incremental = i;
                for (int j = 0; j < 26; j++)
                {
                    x = Convert.ToInt32(Initial) + Incremental;
                    if (x > 90)
                    {
                        x = 65;
                        Incremental = 0;
                    }
                    Matrix[i, j] = Convert.ToChar(x);
                    Incremental++;
                }
            }
        }

        /// <summary>
        /// Fills a dictionary with each character and its index.
        /// </summary>
        void FillIndex()
        {
            char Initial = 'A';
            AlphaIndex = new Dictionary<char, int>();
            for (int i = 0; i < 26; i++)
                AlphaIndex.Add(Convert.ToChar(Convert.ToInt32(Initial) + i), i);
        }

        /// <summary>
        /// Finds which column index the given character in the given row belongs to.
        /// </summary>
        /// <param name="RowIndex">The row index to be searched.</param>
        /// <param name="X">The character that is being seachred for its column index.</param>
        /// <returns>Returns the column index.</returns>
        int SearchMatrixRow(int RowIndex, char X)
        {
            for (int i = RowIndex; ; )
                for (int j = 0; j < 26; j++)
                    if (Matrix[i, j] == X)
                        return j;
        }

        #endregion
    }
}
