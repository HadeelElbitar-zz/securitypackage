using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class PolyalphabeticCipher
    {
        #region Constructors
        string PlainText, CipherText, Key;
        char[,] Matrix = new char[26, 26];
        Dictionary<char, int> AlphaIndex = new Dictionary<char, int>();
        public PolyalphabeticCipher() { }
        public PolyalphabeticCipher(string _PlainText, string _Key, int Mode) // Mode = 0 "AutoKey" , Mode = 1 "RepeatKey"
        {
            PlainText = _PlainText.ToLower();
            Key = _Key.ToUpper();
            if (Key.Length < PlainText.Length && Mode == 0)
            {
                int Difference = PlainText.Length - Key.Length;
                int startIndex = PlainText.Length - Difference;
                Key += PlainText.Substring(startIndex, Difference);
                Key = Key.ToUpper();
            }
            else if (Key.Length < PlainText.Length && Mode == 1)
            {
                int Difference = PlainText.Length - Key.Length;
                Key += Key.Substring(0, Difference);
            }
            BuildMatrix();
            FillIndex();
        }
        #endregion

        #region Helping Functions
        void BuildMatrix()
        {
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
        void FillIndex()
        {
            char Initial = 'A';
            for (int i = 0; i < 26; i++)
            {
                AlphaIndex.Add(Convert.ToChar(Convert.ToInt32(Initial) + i), i);
            }
        }
        int SearchMatrixRow(int RowIndex , char X)
        {
            for (int i = RowIndex; ;)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (Matrix[i, j] == X)
                        return j;
                }
            }
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            CipherText = "";
            int i = -1;
            string TPlainText = PlainText.ToUpper();
            foreach (char item in TPlainText)
                CipherText += Matrix[AlphaIndex[item], AlphaIndex[Key[++i]]];
            return CipherText;
        }
        #endregion

        #region Decryption
        public string Decrypt()
        {
            if (CipherText == null)
                return "Text didn't got encrypted !";
            string PlainText = "";
            int i = -1;
            foreach (char item in CipherText)
                PlainText += Matrix[SearchMatrixRow(AlphaIndex[Key[++i]], item), 0];
            return PlainText;
        }
        #endregion
    }
}
