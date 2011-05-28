using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class PlayFairCipher
    {
        #region Constructors
        char[] Alphabetic = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string[,] Matrix;
        List<string> Diagrams;
        /// <summary>
        /// Creates an object of Plain Fair Cipher.
        /// </summary>
        public PlayFairCipher() { }
        #endregion

        #region Encryption
        /// <summary>
        /// Encrypt the given text using the given key.
        /// </summary>
        /// <param name="PlainText">The text to be encrypted</param>
        /// <param name="Key">The key that's used in the encryption</param>
        /// <returns>It returns a string contains the encrypted text.</returns>
        public string Encrypt(string PlainText, string Key)
        {
            if (PlainText == null || Key == null)
                return "Please choose a valid Plain Text and Key !";
            PlainText = PlainText.ToLower().Replace(" ", "");
            GetDiagrams(PlainText);
            PrepareKey(Key);
            int[] Index1, Index2;
            string CipherText = "";
            foreach (string item in Diagrams)
            {
                string Titem = item.ToUpper();
                Index1 = SearchMatrix(Titem[0]);
                Index2 = SearchMatrix(Titem[1]);
                if (Index1[0] == Index2[0]) // same i same row
                {
                    CipherText += Matrix[Index1[0], (Index1[1] + 1) % 5];
                    CipherText += Matrix[Index2[0], (Index2[1] + 1) % 5];
                }
                else if (Index1[1] == Index2[1]) // same j same column
                {
                    CipherText += Matrix[(Index1[0] + 1) % 5, Index1[1]];
                    CipherText += Matrix[(Index2[0] + 1) % 5, Index2[1]];
                }
                else
                {
                    CipherText += Matrix[Index1[0], Index2[1]];
                    CipherText += Matrix[Index2[0], Index1[1]];
                }
            }
            return CipherText;
        }
        #endregion

        #region Decryption
        /// <summary>
        /// Decrypt the given text using the given key.
        /// </summary>
        /// <param name="CipherText">The text to be decrypted</param>
        /// <param name="Key">The key that's used in the decryption</param>
        /// <returns>It returns a string contains the decrypted text.</returns>
        public string Decrypt(string CipherText, string Key)
        {
            string PlainText = "";
            CipherText = CipherText.ToLower().Replace(" ", "");
            GetDiagrams(CipherText);
            PrepareKey(Key);
            int[] Index1, Index2;
            foreach (string item in Diagrams)
            {
                string Titem = item.ToUpper();
                Index1 = SearchMatrix(Titem[0]);
                Index2 = SearchMatrix(Titem[1]);
                if (Index1[0] == Index2[0]) // same i same row
                {
                    int col1 = Index1[1] - 1, col2 = Index2[1] - 1;
                    if (Index1[1] - 1 < 0) col1 = 4;
                    if (Index2[1] - 1 < 0) col2 = 4;
                    PlainText += Matrix[Index1[0], col1];
                    PlainText += Matrix[Index2[0], col2];
                }
                else if (Index1[1] == Index2[1]) // same j same column
                {
                    int row1 = Index1[0] - 1, row2 = Index2[0] - 1;
                    if (Index1[0] - 1 < 0) row1 = 4;
                    if (Index2[0] - 1 < 0) row2 = 4;
                    PlainText += Matrix[row1, Index1[1]];
                    PlainText += Matrix[row2, Index2[1]];
                }
                else
                {
                    PlainText += Matrix[Index1[0], Index2[1]];
                    PlainText += Matrix[Index2[0], Index1[1]];
                }
            }
            return PlainText;
        }
        #endregion

        #region Helping Functions
        void PrepareKey(string NewKey)
        {
            NewKey = NewKey.ToUpper().Replace(" ", "");
            Matrix = BuildMatrix(NewKey);
        }
        /// <summary>
        /// Given the text of encryption/decryption it prepares a list of the digrams.
        /// </summary>
        /// <param name="Text">The text to be encrypted/decrypted.</param>
        void GetDiagrams(string Text)
        {
            Diagrams = new List<string>();
            if (Text.Length % 2 != 0)
                Text += "x";
            int count = Text.Length;
            for (int i = 0; i < count; i += 2)
            {
                if (Text[i] != Text[i + 1])
                    Diagrams.Add(Text[i].ToString() + Text[i + 1].ToString());
                else
                {
                    if (Text[count - 1] == 'x')
                        Text = Text.Remove(count - 1, 1);
                    Text = Text.Insert(i + 1, "x");
                    if (Text.Length % 2 != 0)
                        Text += "x";
                    count = Text.Length;
                    Diagrams.Add(Text[i].ToString() + Text[i + 1].ToString());
                }
            }
        }
        /// <summary>
        /// Get the row index and column index in the matrix for the given character
        /// </summary>
        /// <param name="X">Character we are searching for.</param>
        /// <returns>Integer array with size 2 that contains row index and column index</returns>
        int[] SearchMatrix(char X)
        {
            int[] Index = new int[2];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (Matrix[i, j][0] == X)
                    {
                        Index[0] = i;
                        Index[1] = j;
                        return Index;
                    }
                    if (Matrix[i, j][0] == 'I' && Matrix[i, j][1] == X)
                    {
                        Index[0] = i;
                        Index[1] = j;
                        return Index;
                    }
                }

            return Index;
        }
        /// <summary>
        /// Build the play fair matrix to be used in encryption/decryption using the given key.
        /// </summary>
        /// <param name="_Key">String represents the key of encryption/decryption operation.</param>
        /// <returns>Returns the play fair matrix.</returns>
        string[,] BuildMatrix(string _Key)
        {
            string[,] NewMatrix = new string[5, 5];
            List<char> Temp = new List<char>();
            bool KeyFlag = true, AlphaFlag = false;
            int i = 0, j = 0, c = 0, Tempi = 0, Tempj = 0;
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    if (KeyFlag)
                    {
                        while (true)
                        {
                            if (!Temp.Contains(_Key[c]))
                            {
                                if (_Key[c] == 'I' || _Key[c] == 'J')
                                {
                                    NewMatrix[i, j] = "IJ";
                                    Temp.Add('I');
                                    Temp.Add('J');
                                    break;
                                }
                                NewMatrix[i, j] = _Key[c].ToString();
                                Temp.Add(_Key[c]);
                                break;
                            }
                            c++;
                            if (c == _Key.Length)
                            {
                                KeyFlag = false;
                                AlphaFlag = true;
                                Tempi = i;
                                Tempj = j;
                                c = 0;
                                break;
                            }
                        }
                    }
                    else if (AlphaFlag)
                    {
                        if (NewMatrix[Tempi, Tempj] == null)
                        {
                            i = Tempi;
                            j = Tempj;
                        }
                        while (true)
                        {
                            if (!Temp.Contains(Alphabetic[c]))
                            {
                                if (Alphabetic[c] == 'I' || Alphabetic[c] == 'J')
                                {
                                    NewMatrix[i, j] = "IJ";
                                    Temp.Add('I');
                                    Temp.Add('J');
                                    break;
                                }
                                NewMatrix[i, j] = Alphabetic[c].ToString();
                                Temp.Add(Alphabetic[c]);
                                break;
                            }
                            c++;
                            if (c == 26)
                                break;
                        }
                    }
                }
            }
            return NewMatrix;
        }
        #endregion
    }
}
