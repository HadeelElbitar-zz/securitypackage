using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace SecurityPackage
{
    class HillCipher
    {
        #region Constructors
        string PlainText, CipherText;
        int[,] Key;
        int[,] KeyInverse;
        int NumberOfChars;
        Dictionary<char, int> AlphaIndex = new Dictionary<char, int>();
        public HillCipher() { }
        public HillCipher(string _PlainText, int[,] _Key)
        {
            PlainText = _PlainText.ToUpper();
            Key = _Key;
            NumberOfChars = (int)Math.Sqrt(Key.Length);
            KeyInverse = new int[NumberOfChars, NumberOfChars];
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
        int[,] MatrixMul(int[,] PT ,int[,] _Key)
        {
            int[,] Result = new int[1, NumberOfChars];
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                {
                    Result[0, i] += _Key[i, j] * PT[0, j];
                }
            return Result;
        }
        int MatrixDet(int[,] SubMatrix)
        {
            int res = 0;
            if (SubMatrix.Length == 4)
                res += SubMatrix[0, 0] * SubMatrix[1, 1] - SubMatrix[0, 1] * SubMatrix[1, 0];
            else
            {
                int Count = (int)Math.Sqrt(SubMatrix.Length);
                int[,] SmallMatrix = new int[Count - 1, Count - 1];
                for (int i = 0; i < 1; i++)
                    for (int j = 0; j < Count; j++)
                    {
                        for (int v = 0, c = 0; c < Count; c++)
                            for (int k = 0, p = 0; p < Count; p++)
                                if (c != i && p != j)
                                {
                                    SmallMatrix[v, k++] = SubMatrix[c, p];
                                    if (k == Count - 1)
                                    {
                                        k = 0;
                                        v++;
                                    }
                                    if (v == Count - 1)
                                        break;
                                }
                        res += (SubMatrix[i, j] * (int)Math.Pow(-1, (i + j)) * MatrixDet(SmallMatrix));
                    }
            }
            return res;
        }
        int CoMatrixDet(int[,] SubMatrix, int IndexI, int IndexJ)
        {
            int res = 0;
            if (SubMatrix.Length == 4)
                res += SubMatrix[0, 0] * SubMatrix[1, 1] - SubMatrix[0, 1] * SubMatrix[1, 0];
            else
            {
                int Count = (int)Math.Sqrt(SubMatrix.Length);
                int[,] SmallMatrix = new int[Count - 1, Count - 1];
                for (int v = 0, c = 0; c < Count; c++)
                    for (int k = 0, p = 0; p < Count; p++)
                        if (c != IndexI && p != IndexJ)
                        {
                            SmallMatrix[v, k++] = SubMatrix[c, p];
                            if (k == Count - 1)
                            {
                                k = 0;
                                v++;
                            }
                            if (v == Count - 1)
                                break;
                        }
                res += ((int)Math.Pow(-1, (IndexI + IndexJ)) * MatrixDet(SmallMatrix));
            }
            return res;
        }
        int[,] GetCofactorMatrix(int[,] Matrix)
        {
            int[,] Result = new int[NumberOfChars, NumberOfChars];
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                    Result[i, j] = CoMatrixDet(Matrix, i, j);
            return Result;
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            int[,] PT = new int[1, NumberOfChars];
            int[,] CT;
            int count = PlainText.Length;
            string Temp = "";
            for (int i = 0; i < count; i += NumberOfChars)
            {
                try
                {
                    Temp = PlainText.Substring(i, NumberOfChars);
                }
                catch
                {
                    Temp = PlainText.Substring(i);
                }
                int Count = Temp.Length;
                for (int j = 0; j < Count; j++)
                    PT[0, j] = AlphaIndex[Temp[j]];
                CT = MatrixMul(PT, Key);
                for (int k = 0; k < Count; k++)
                {
                    CT[0, k] = CT[0, k] % 26;
                    foreach (KeyValuePair<char, int> item in AlphaIndex)
                        if (item.Value == CT[0, k])
                        {
                            CipherText += item.Key;
                            break;
                        }
                }
            }
            return CipherText;
        }
        #endregion

        #region Decryption
        public string Decrypt()
        {
            int Determinant = MatrixDet(Key);
            Determinant = Math.Abs(Determinant) % 26;
            Determinant = 26 - (27 / (26 - Determinant));
            int[,] CofactorMatrix = GetCofactorMatrix(Key);
            
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                {
                    if (CofactorMatrix[i, j] < 0)
                        CofactorMatrix[i, j] *= -1;
                    CofactorMatrix[i, j] %= 26;
                    KeyInverse[j, i] = (CofactorMatrix[i, j] * Determinant) % 26;
                }
            int[,] CT = new int[1, NumberOfChars];
            int[,] PT;
            PlainText = "";
            int count = CipherText.Length;
            string Temp = "";
            for (int i = 0; i < count; i += NumberOfChars)
            {
                try
                {
                    Temp = CipherText.Substring(i, NumberOfChars);
                }
                catch
                {
                    Temp = CipherText.Substring(i);
                }
                int Count = Temp.Length;
                for (int j = 0; j < Count; j++)
                    CT[0, j] = AlphaIndex[Temp[j]];
                PT = MatrixMul(CT , KeyInverse);
                for (int k = 0; k < Count; k++)
                {
                    PT[0, k] = PT[0, k] % 26;
                    foreach (KeyValuePair<char, int> item in AlphaIndex)
                        if (item.Value == PT[0, k])
                        {
                            PlainText += item.Key;
                            break;
                        }
                }
            }
            return PlainText;
        }
        #endregion
    }
}
