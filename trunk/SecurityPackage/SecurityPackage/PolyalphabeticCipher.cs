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
        public PolyalphabeticCipher() { }
        #endregion

        #region Encryption
        public string Encrypt(string PlainText, string Key, int Mode)
        {
            PlainText = PlainText.ToUpper().Replace(" ", "");
            PrepareKey(ref Key, PlainText, Mode);
            string CipherText = "";
            int i = -1;
            foreach (char item in PlainText)
                CipherText += Matrix[AlphaIndex[item], AlphaIndex[Key[++i]]];
            return CipherText;
        }
        #endregion

        #region Decryption
        public string Decrypt(string CipherText, string Key, int Mode)
        {
            CipherText = CipherText.ToUpper().Replace(" ", "");
            PrepareKey(ref Key, CipherText, KeyMode);
            string PlainText = "";
            int i = -1;
            foreach (char item in CipherText)
                PlainText += Matrix[SearchMatrixRow(AlphaIndex[Key[++i]], item), 0];
            return PlainText;
        }
        #endregion

        #region Helping Functions
        void PrepareKey(ref string Key, string PT, int Mode)
        {
            Key = Key.ToUpper().Replace(" ", "");
            KeyMode = Mode;
            if (Key.Length < PT.Length && KeyMode == 0)
            {
                int Difference = PT.Length - Key.Length;
                int startIndex = PT.Length - Difference;
                Key += PT.Substring(startIndex, Difference);
            }
            else if (Key.Length < PT.Length && KeyMode == 1)
            {
                while (Key.Length < PT.Length)
                    Key += Key;
                Key = Key.Substring(0, PT.Length);
            }
            BuildMatrix();
            FillIndex();
        }
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
        void FillIndex()
        {
            char Initial = 'A';
            AlphaIndex = new Dictionary<char, int>();
            for (int i = 0; i < 26; i++)
                AlphaIndex.Add(Convert.ToChar(Convert.ToInt32(Initial) + i), i);
        }
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
