﻿using System;
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
        public ColumnarCipher() { }
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
            foreach (KeyValuePair<char, int> item in Temp)
                Numbers[++j] = item.Value;
            return Numbers;
        }
        void PrepareKey(int NewKey)
        {
            Key = NewKey.ToString();
            NumberOfColumns = Key.Length;
            //MaxNumOfElements = PlainText.Length / NumberOfColumns;
            Columns = new List<char>[NumberOfColumns];
            for (int i = 0; i < NumberOfColumns; i++)
                Columns[i] = new List<char>();
            SortedKey = SortKey(Key);
        }
        #endregion

        #region Encryption
        public string Encrypt(string PlainText, int Key)
        {
            //if (PlainText == null || Key == null)
            //    return "Please choose a valid Plain Text and Key !";
            string CipherText = "";
            PlainText = PlainText.Replace(" ", "");
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
        public string Decrypt(string CipherText, int Key)
        {
            //if (CipherText == null)
            //    return "There is no Encrypted CipherText to Decrypt !";
            //if (Key == null)
            //    return "please choose a valid key !";
            CipherText = CipherText.Replace(" ", "");
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
    }
}