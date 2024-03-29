﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;

namespace SecurityPackage
{
    class HillCipher
    {
        #region Constructors
        int[,] Key;
        int[,] KeyInverse;
        int NumberOfChars;
        Dictionary<char, int> AlphaIndex;
        /// <summary>
        /// Creates an object of Hill Cipher.
        /// </summary>
        public HillCipher() { }
        #endregion

        #region Encryption

        /// <summary>
        /// Encrypts the given text using the given key matrix.
        /// </summary>
        /// <param name="PlainText">Text to be encrypted</param>
        /// <param name="_Key">Key matrix to be used in the encryption</param>
        /// <returns>It returns a string contains the encrypted text.</returns>
        public string Encrypt(string PlainText, int[,] _Key)
        {
            if (PlainText == null || _Key == null)
                return "Please choose a valid Plain Text and Key !";
            PlainText = PlainText.ToUpper().Replace(" ", "");
            int indexRemove = PlainText.IndexOf('\n');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            indexRemove = PlainText.IndexOf('\t');
            if (indexRemove != -1)
                PlainText = PlainText.Remove(indexRemove);
            PrepareKey(_Key);
            string CipherText = "";
            int[,] PT;
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
                PT = new int[1, NumberOfChars];
                for (int j = 0; j < Count; j++)
                    PT[0, j] = AlphaIndex[Temp[j]];
                CT = MatrixMul(PT, Key);
                for (int k = 0; k < NumberOfChars; k++)
                {
                    if (CT[0, k] < 0)
                        CT[0, k] = 26 - ((-1 * CT[0, k]) % 26);
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
        /// <summary>
        /// Decrypts the given text using the given key matrix.
        /// </summary>
        /// <param name="CipherText">Text to be decrypted</param>
        /// <param name="_Key">Key matrix to be used in the decryption</param>
        /// <returns>It returns a string contains the decrypted text.</returns>
        public string Decrypt(string CipherText, int[,] _Key)
        {
            NumberTheory MI = new NumberTheory();
            CipherText = CipherText.ToUpper().Replace(" ", "");
            int indexRemove = CipherText.IndexOf('\n');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            indexRemove = CipherText.IndexOf('\t');
            if (indexRemove != -1)
                CipherText = CipherText.Remove(indexRemove);
            PrepareKey(_Key);
            int Determinant = MatrixDet(Key);
            if (Determinant < 0)
                Determinant = 26 - ((Determinant * -1) % 26);
            Determinant %= 26;
            Determinant = MI.MultiplicativeInverse(Determinant, 26);
            if (Determinant == int.MinValue)
            {
                MessageBox.Show("The Determinant can't be converted into base 26! .. unable to decrypt text!");
                return null;
            }
            else if (Determinant < 0)
                Determinant = 26 - Determinant;
            int[,] CofactorMatrix = GetCofactorMatrix(Key);

            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                {
                    if (CofactorMatrix[i, j] < 0)
                        CofactorMatrix[i, j] = 26 - ((CofactorMatrix[i, j] * -1) % 26);
                    CofactorMatrix[i, j] %= 26;
                    KeyInverse[j, i] = (CofactorMatrix[i, j] * Determinant) % 26;
                }
            int[,] CT;
            int[,] PT;
            string PlainText = "";
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
                CT = new int[1, NumberOfChars];
                for (int j = 0; j < NumberOfChars; j++)
                    CT[0, j] = AlphaIndex[Temp[j]];
                PT = MatrixMul2(KeyInverse,CT);
                for (int k = 0; k < NumberOfChars; k++)
                {
                    if (PT[0, k] < 0)
                        PT[0, k] = 26 - ((-1 * PT[0, k]) % 26);
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

        #region Helping Functions
        void PrepareKey(int[,] NewKey)
        {
            Key = NewKey;
            NumberOfChars = (int)Math.Sqrt(Key.Length);
            KeyInverse = new int[NumberOfChars, NumberOfChars];
            FillIndex();
        }
        /// <summary>
        /// Fill a dectionary that contains every character with its index.
        /// </summary>
        void FillIndex()
        {
            AlphaIndex = new Dictionary<char, int>();
            char Initial = 'A';
            for (int i = 0; i < 26; i++)
                AlphaIndex.Add(Convert.ToChar(Convert.ToInt32(Initial) + i), i);
        }
        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="PT">The first matrix</param>
        /// <param name="_Key">The second matrix</param>
        /// <returns>The result of multiplication matrix</returns>
        int[,] MatrixMul(int[,] PT, int[,] _Key)
        {
            int[,] Result = new int[1, NumberOfChars];
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                {
                    Result[0, i] += _Key[i, j] * PT[0, j];
                }
            return Result;
        }
        int[,] MatrixMul2(int[,] _Key, int[,] CT)
        {
            int[,] Result = new int[1, NumberOfChars];
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                {
                    Result[0, i] += (_Key[i, j] * CT[0, j]);
                }
            return Result;
        }
        /// <summary>
        /// Finds the determinant for any matrix with any size.
        /// </summary>
        /// <param name="SubMatrix">The matrix to find the determinant for</param>
        /// <returns>Returns an integer represents the determinant value.</returns>
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
        /// <summary>
        /// Finds the cofacrot matrix for any given matrix with any size.
        /// </summary>
        /// <param name="Matrix">The matrix to find the cofactor matrix for.</param>
        /// <returns>Returns the cofactor matrix with size of the same input matrix size.</returns>
        int[,] GetCofactorMatrix(int[,] Matrix)
        {
            int[,] Result = new int[NumberOfChars, NumberOfChars];
            if (Matrix.Length == 4)
            {
                Result[0, 0] = Matrix[1, 1];
                Result[0, 1] = Matrix[1, 0];
                Result[1, 0] = Matrix[0, 1];
                Result[1, 1] = Matrix[0, 0];
                return Result;
            }
            for (int i = 0; i < NumberOfChars; i++)
                for (int j = 0; j < NumberOfChars; j++)
                    Result[i, j] = CoMatrixDet(Matrix, i, j);
            return Result;
        }
        #endregion
    }
}
