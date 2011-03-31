using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class ColumnarCipher
    {
        #region Constructors
        string PlainText, CipherText, Key;
        int[] SortedKey , NumberOfCharsPerEachColumn;
        int NumberOfColumns , MaxNumOfElements;
        List<char>[] Columns;
        public ColumnarCipher() { }
        public ColumnarCipher(string _PlainText, int _Key)
        {
            PlainText = _PlainText;
            Key = _Key.ToString();
            NumberOfColumns = Key.Length;
            MaxNumOfElements = PlainText.Length / NumberOfColumns;
            NumberOfCharsPerEachColumn = new int[NumberOfColumns];
            Columns = new List<char>[NumberOfColumns];
            for (int i = 0; i < NumberOfColumns; i++)
                Columns[i] = new List<char>();
            SortedKey = SortKey(Key);
        }
        #endregion

        #region Helping Functions
        int[] SortKey(string _Key)
        {
            int length = _Key.Length;
            int[] Numbers = new int[length];
            SortedDictionary<char, int> Temp = new SortedDictionary<char, int>();
            for (int i = 0; i < length; i++)
                Temp.Add(_Key[i], i);
            int j = -1;
            foreach (KeyValuePair<char,int> item in Temp)
                Numbers[++j] = item.Value;
            return Numbers;
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            CipherText = "";
            int length = PlainText.Length;
            int j = -1;
            for (int i = 0; i < length; i++)
            {
                if (j == NumberOfColumns - 1) j = -1;
                Columns[++j].Add(PlainText[i]);
                NumberOfCharsPerEachColumn[j]++;
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
        public string Decrypt()
        {
            PlainText = "";
            int Length = CipherText.Length, NumberOfCharInCol;
            for (int i = 0; i < NumberOfColumns; i++)
                Columns[i] = new List<char>();
            int k = 0, ColIndex;
            for (int j = 0; j < NumberOfColumns; j++)
            {
                ColIndex = SortedKey[j];
                NumberOfCharInCol = NumberOfCharsPerEachColumn[ColIndex];
                for (int i = 0; k < Length && i < NumberOfCharInCol; k++, i++)
                    Columns[ColIndex].Add(CipherText[k]);
            }
            NumberOfCharInCol = Length / NumberOfColumns + 1;
            for (int i = 0; i < NumberOfCharInCol; i++)
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
    }
}
