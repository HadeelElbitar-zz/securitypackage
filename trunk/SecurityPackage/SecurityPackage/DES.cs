using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class DES
    {

        #region Variables
        string PlainText;
        int[] IP;
        int[] IPInverse;
        int[] E;
        int[] P;
        int[] InputKey;
        int[] PC1;
        int[] PC2;
        int[] BitsRotated;
        int[,] S1;
        int[,] S2;
        int[,] S3;
        int[,] S4;
        int[,] S5;
        int[,] S6;
        int[,] S7;
        int[,] S8;
        #endregion

        #region Constructors
        public DES(string _PlainText)
        {
            PlainText = _PlainText;
            #region Tables Initialization

            IP = new int[] { 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4, 62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8, 57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3, 61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7 };
            IPInverse = new int[] { 40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31, 38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29, 36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27, 34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25 };
            E = new int[] { 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1 };
            P = new int[] { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25 };
            InputKey = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 };
            PC1 = new int[] { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36, 63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4 };
            PC2 = new int[] { 14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32, };
            BitsRotated = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

            #region S-Boxes
            S1 = new int[4, 16] {{ 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
            {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
            {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
            {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }};

            S2 = new int[4, 16] {{ 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
            {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
            {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
            {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }};

            S3 = new int[4, 16] {{ 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
            {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
            {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
            {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }};


            S4 = new int[4, 16] {{ 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
            {13, 8, 11, 5, 6, 15, 0,3, 4, 7, 2, 12, 1, 10, 14, 9},
            {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
            {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }};


            S5 = new int[4, 16] {{2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14,9},
            {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
            {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
            {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }};

            S6 = new int[4, 16] {{ 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
            {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
            {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
            {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }};


            S7 = new int[4, 16] {{ 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
            {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
            {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
            {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }};


            S8 = new int[4, 16] {{ 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
            {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
            {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
            {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }}
            ;
            #endregion

            #endregion
        }
        #endregion

        public string Encrypt()
        {
            #region Convert To Binary
            string BinaryText = TextToBinary(PlainText);
            string BinaryKey = KeyToBinary(InputKey);
            #endregion

            string EncryptedText = "";
            int keyIndex = 0;
            while (BinaryText != "")
            {
                #region Get Bits From Plain Text & Key

                #region Binary Key
                string Key64;

                if (keyIndex + 64 <= BinaryKey.Length)
                {
                    Key64 = BinaryKey.Substring(keyIndex, 64);
                    keyIndex += 64;
                }
                else
                {
                    int len = BinaryKey.Length - keyIndex;
                    Key64 = BinaryKey.Substring(keyIndex, len);
                    Key64 += BinaryKey.Substring(0, 64 - len);
                }
                #endregion

                #region Plain Text
                string Text64 = BinaryText;
                if (Text64.Length >= 64)
                {
                    Text64 = Text64.Substring(0, 64);
                    BinaryText = BinaryText.Remove(0, 64);
                }
                else
                {
                    Text64 = Text64.PadLeft(64, '0');
                    BinaryText = "";
                }
                #endregion

                #endregion

                #region First Permutation
                string permutedText = Rearrange(Text64, IP);
                string PermutedKey = Rearrange(Key64, PC1);
                #endregion

                #region Rounds
                int RoundsCount = 16;
                string CirculatedKey = "";
                for (int i = 0; i < RoundsCount; i++)
                {
                    CirculatedKey = LeftCircularShift(PermutedKey, BitsRotated[i]);
                    string KeyI = Rearrange(CirculatedKey, PC2);

                    string[] TextArray = Round(permutedText, KeyI);
                    if (i == RoundsCount - 1)
                        permutedText = TextArray[1] + TextArray[0];
                    else
                        permutedText = TextArray[0] + TextArray[1];
                }
                #endregion

                permutedText = Rearrange(permutedText, IPInverse);

                EncryptedText += BinaryToText(permutedText);
            }
            return EncryptedText;
        }

        public string Decrypt()
        {
            #region Convert To Binary

            string BinaryText = TextToBinary(PlainText);
            string BinaryKey = KeyToBinary(InputKey);
            #endregion

            string DecryptedText = "";
            int keyIndex = 0;
            while (BinaryText != "")
            {
                #region Get Bits From Plain Text & Key

                #region Binary Key
                string Key64;

                if (keyIndex + 64 <= BinaryKey.Length)
                {
                    Key64 = BinaryKey.Substring(keyIndex, 64);
                    keyIndex += 64;
                }
                else
                {
                    int len = BinaryKey.Length - keyIndex;
                    Key64 = BinaryKey.Substring(keyIndex, len);
                    Key64 += BinaryKey.Substring(0, 64 - len);
                }
                #endregion

                #region Plain Text
                string Text64 = BinaryText;
                if (Text64.Length >= 64)
                {
                    Text64 = Text64.Substring(0, 64);
                    BinaryText = BinaryText.Remove(0, 64);
                }
                else
                {
                    Text64 = Text64.PadLeft(64, '0');
                    BinaryText = "";
                }
                #endregion

                #endregion

                #region First Permutation
                string permutedText = Rearrange(Text64, IPInverse);
                string PermutedKey = Rearrange(Key64, PC1);
                #endregion

                #region Rounds
                int RoundsCount = 16;
                string CirculatedKey = "";
                for (int i = 0; i < RoundsCount; i++)
                {
                    CirculatedKey = LeftCircularShift(PermutedKey, BitsRotated[i]);
                    string KeyI = Rearrange(CirculatedKey, PC2);

                    string[] TextArray = Round(permutedText, KeyI);
                    if (i == RoundsCount - 1)
                        permutedText = TextArray[1] + TextArray[0];
                    else
                        permutedText = TextArray[0] + TextArray[1];
                }
                #endregion

                permutedText = Rearrange(permutedText, IP);
                DecryptedText += BinaryToText(permutedText);
            }
            return DecryptedText;
        }

        #region Helping Functions
        private string TextToBinary(string Text)
        {
            int length = Text.Length;
            string BinaryText = "";
            for (int i = 0; i < length; i++)
            {
                string temp = Convert.ToString(Text[i], 2);
                if (temp.Length != 8)
                    temp = temp.PadLeft(8, '0');
                BinaryText += temp;
            }
            return BinaryText;
        }
        private string BinaryToText(string Text)
        {
            string returnText = "";
            int length = Text.Length;
            for (int i = 0; i < length; i += 8)
            {
                returnText += Convert.ToChar(Convert.ToInt32(Text.Substring(0, 8), 2));
                Text = Text.Remove(0, 8);
            }
            return returnText;
        }
        private string KeyToBinary(int[] Key)
        {
            int length = Key.Count();
            string BinaryKey = "";
            for (int i = 0; i < length; i++)
            {
                string temp = Convert.ToString(Key[i], 2);
                if (temp.Length != 8)
                    temp = temp.PadLeft(8, '0');
                BinaryKey += temp;
            }
            return BinaryKey;
        }
        private string Rearrange(string Text, int[] Permutation)
        {
            int length = Permutation.Count();
            string ArrangedText = "";
            for (int i = 0; i < length; i++)
                ArrangedText += Text[Permutation[i] - 1];
            return ArrangedText;
        }
        private string LeftCircularShift(string Key, int BitsRotated)
        {
            int length = Key.Length / 2;
            string LeftPart = Key.Substring(0, length);
            string RightPart = Key.Substring(length, length);

            for (int i = 0; i < BitsRotated; i++)
            {
                char temp = LeftPart[LeftPart.Length - 1];
                LeftPart.Remove(0, 1);
                LeftPart += temp.ToString();

                temp = RightPart[RightPart.Length - 1];
                RightPart.Remove(0, 1);
                RightPart += temp.ToString();
            }
            return LeftPart + RightPart;
        }
        private string[] Round(string Text, string Key)
        {
            int length = Text.Length / 2;
            string LeftPart = Text.Substring(0, length);
            string RightPart = Text.Substring(length, length);
            string[] ReturnString = new string[] { RightPart, "" };
            RightPart = FunctionF(RightPart, Key);
            ReturnString[1] = XORFunction(RightPart, LeftPart);
            return ReturnString;
        }
        private string FunctionF(string RightPart, string Key)
        {
            RightPart = Rearrange(RightPart, E);
            string XOR = XORFunction(RightPart, Key);

            //S-Boxes Substitution
            string SBoxesResult = "";
            int sBoxesColumns = 6;
            //S-Boxes
            for (int i = 0; i < 48; i += sBoxesColumns)
            {
                string temp = XOR.Substring(i, sBoxesColumns);
                string t = temp[0].ToString() + temp[temp.Length - 1].ToString();
                int row = (int)Convert.ToInt32(t, 2);
                t = temp.Substring(1, temp.Length - 2);
                int column = (int)Convert.ToInt32(t, 2);
                temp = Convert.ToString(S1[row, column], 2);
                if (temp.Length != 4)
                    temp = temp.PadLeft(4, '0');
                SBoxesResult += temp;
            }
            SBoxesResult = Rearrange(SBoxesResult, P);
            return SBoxesResult;
        }
        string XORFunction(string F, string S)
        {
            int length = F.Length;
            string returnString = "";
            for (int i = 0; i < length; i++)
            {
                if (F[i] == S[i])
                    returnString += '0';
                else
                    returnString += '1';
            }
            return returnString;
        }
        #endregion
    }
}