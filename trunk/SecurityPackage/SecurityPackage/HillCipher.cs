using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class HillCipher
    {
        #region Constructors
        string PlainText, CipherText;
        int[,] Key;
        int NumberOfChars;
        Dictionary<char, int> AlphaIndex = new Dictionary<char, int>();
        public HillCipher() { }
        public HillCipher(string _PlainText, int[,] _Key)
        {
            PlainText = _PlainText.ToUpper();
            Key = _Key;
            NumberOfChars = (int)Math.Sqrt(Key.Length);
            FillIndex();
        }
        #endregion

        #region Helping Functions
        void FillIndex()
        {
            char Initial = 'A';
            for (int i = 0; i < 26; i++)
            {
                AlphaIndex.Add(Convert.ToChar(Convert.ToInt32(Initial) + i), i);
            }
        }
        int[,] MatrixMul(int[,] PT)
        {
            int[,] Result = new int[1, NumberOfChars];
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                {
                    Result[0, i] += Key[i, j] * PT[0, j];
                }
            return Result;
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            int[,] PT = new int[1, NumberOfChars];
            int[,] CT;
            int count = PlainText.Length;
            string Temp;
            for (int i = 0; i < count; i += NumberOfChars)
            {
                Temp = PlainText.Substring(i, NumberOfChars);
                for (int j = 0; j < NumberOfChars; j++)
                    PT[0, j] = AlphaIndex[Temp[j]];
                CT = MatrixMul(PT);
                for (int k = 0; k < NumberOfChars; k++)
                {
                    CT[0, k] = CT[0, k] % 26;
                    foreach (KeyValuePair<char, int> item in AlphaIndex)
                    {
                        if (item.Value == CT[0, k])
                        {
                            CipherText += item.Key;
                            break;
                        }
                    }
                }
            }
            return CipherText;
        }
        #endregion
    }
}
