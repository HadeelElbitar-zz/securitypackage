using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class ColumnarCipher
    {
        #region Constructors
        string Key;
        int[] SortedKey;
        int NumberOfColumns;
        List<char>[] Columns;
        /// <summary>
        /// Creates an object of Columnar Cipher.
        /// </summary>
        public ColumnarCipher() { }
        #endregion

        #region Encryption

        /// <summary>
        /// Encrypt the given text with the given key.
        /// </summary>
        /// <param name="PlainText">Text to be encrypted</param>
        /// <param name="Key">Key to be used in the encryption</param>
        /// <returns>Returns a string contains the encrypted text.</returns>
        public string Encrypt(string PlainText, string Key)
        {
            //if (PlainText == null || Key == null)
            //    return "Please choose a valid Plain Text and Key !";
            string CipherText = "";
            PlainText = PlainText.Replace(" ", "");
            int indexRemove = PlainText.IndexOf('\n');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            indexRemove = PlainText.IndexOf('\t');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            PrepareKey(Key);
            int length = PlainText.Length;
            int j = -1;
            for (int i = 0; i < length; i++)
            {
                if (j == NumberOfColumns - 1) j = -1;
                Columns[++j].Add(PlainText[i]);
            }
            for (int i = 0; i < NumberOfColumns; i++)
            {
                int ColIndex = SortedKey[i];
                int InCount = Columns[ColIndex].Count;
                for (int k = 0; k < InCount; k++)
                    CipherText += Columns[ColIndex][k];
            }
            return CipherText;
        }

        #endregion

        #region Decryption

        /// <summary>
        /// Decrypt the given text with the given key.
        /// </summary>
        /// <param name="CipherText">Text to be decrypted</param>
        /// <param name="Key">Key to be used in the decryption</param>
        /// <returns>Returns a string contains the decrypted text.</returns>
        public string Decrypt(string CipherText, string Key)
        {
            CipherText = CipherText.Replace(" ", "");
            int indexRemove = CipherText.IndexOf('\n');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            indexRemove = CipherText.IndexOf('\t');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            PrepareKey(Key);
            string PlainText = "";
            int Length = CipherText.Length, NumberOfCharInCol, ExtraChars;
            for (int i = 0; i < NumberOfColumns; i++)
                Columns[i] = new List<char>();
            int k = 0, ColIndex, p = 0;
            NumberOfCharInCol = Length / NumberOfColumns;
            ExtraChars = Length % NumberOfColumns;
            for (int j = 0; j < NumberOfColumns; j++)
            {
                ColIndex = SortedKey[j];
                if (ColIndex < ExtraChars)
                {
                    for (int i = 0; k < Length && i < NumberOfCharInCol + 1; k++, i++)
                        Columns[ColIndex].Add(CipherText[k]);
                    p++;
                }
                else
                    for (int i = 0; k < Length && i < NumberOfCharInCol; k++, i++)
                        Columns[ColIndex].Add(CipherText[k]);
            }
            for (int i = 0; i < NumberOfCharInCol + 1; i++)
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    try
                    {
                        PlainText += Columns[j][i];
                    }
                    catch { }
                }
            return PlainText;
        }

        #endregion

        #region Helping Functions

        int[] SortKey(string[] _Key)
        {
            int length = _Key.Length;
            int[] Numbers = new int[length];
            SortedDictionary<int, int> Temp = new SortedDictionary<int, int>();
            for (int i = 0; i < length; i++)
                Temp.Add(Convert.ToInt32(_Key[i]), i);
            int j = -1;
            foreach (KeyValuePair<int, int> item in Temp)
                Numbers[++j] = item.Value;
            return Numbers;
        }
        void PrepareKey(string NewKey)
        {
            Key = NewKey;
            string[] Number = Key.Split(' ');
            NumberOfColumns = Number.Length;
            Columns = new List<char>[NumberOfColumns];
            for (int i = 0; i < NumberOfColumns; i++)
                Columns[i] = new List<char>();
            SortedKey = SortKey(Number);
        }

        #endregion
    }
}
