using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class PlayFairCipher
    {
        #region Constructors
        string PlainText, CipherText, Key;
        char[] Alphabetic = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string[,] Matrix;
        List<string> Diagrams = new List<string>();
        /// <summary>
        /// use it when decrypting only
        /// </summary>
        public PlayFairCipher() { }
        /// <summary>
        /// use it when encrypting only
        /// </summary>
        /// <param name="_PlainText"></param>
        /// <param name="_Key"></param>
        public PlayFairCipher(string _PlainText, string _Key)
        {
            PlainText = _PlainText.ToLower().Replace(" ","");
            GetDiagrams(PlainText);
            PrepareKey(_Key);
        }
        #endregion

        #region Helping Functions
        void PrepareKey(string NewKey)
        {
            Key = NewKey.ToUpper().Replace(" ","");
            BuildMatrix();
        }
        void BuildMatrix()
        {
            Matrix = new string[5, 5];
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
                            if (!Temp.Contains(Key[c]))
                            {
                                if (Key[c] == 'I' || Key[c] == 'J')
                                {
                                    Matrix[i, j] = "IJ";
                                    Temp.Add('I');
                                    Temp.Add('J');
                                    break;
                                }
                                Matrix[i, j] = Key[c].ToString();
                                Temp.Add(Key[c]);
                                break;
                            }
                            c++;
                            if (c == Key.Length)
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
                        if (Matrix[Tempi , Tempj] == null)
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
                                    Matrix[i, j] = "IJ";
                                    Temp.Add('I');
                                    Temp.Add('J');
                                    break;
                                }
                                Matrix[i, j] = Alphabetic[c].ToString();
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
        }
        void GetDiagrams(string Text)
        {
            Diagrams = new List<string>();
            if (Text.Length % 2 != 0)
                Text += "x";
            int count = Text.Length;
            for (int i = 0; i < count; i+=2)
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
        string [,] BuildMatrix(string _Key)
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

        #region Encryption
        public string Encrypt()
        {
            if (PlainText == null || Key == null)
                return "Please choose a valid Plain Text and Key !";
            int[] Index1, Index2;
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
        public string Decrypt()
        {
            if (CipherText == null)
                return "Text didn't got encrypted !";
            if (Key == null)
                return "please choose a valid key !";
            string PlainText = "";
                GetDiagrams(CipherText);
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

        #region Setting Properties
        /// <summary>
        /// Set new PlainText
        /// </summary>
        public string _PlainText
        {
            set
            {
                PlainText = value;
                PlainText = PlainText.Replace(" ", "");
            }
        }
        /// <summary>
        /// Set new Key
        /// </summary>
        public string _Key
        {
            set
            {
                Key = value;
                PrepareKey(Key);
            }
        }
        /// <summary>
        /// returns the CihperText generated or set new value to Decrypt
        /// </summary>
        public string _CipherText
        {
            get
            {
                return CipherText;
            }
            set
            {
                CipherText = value;
                CipherText = CipherText.Replace(" ", "");
            }
        }
        #endregion
    }
}
