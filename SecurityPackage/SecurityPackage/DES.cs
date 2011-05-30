using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class DES
    {
        #region Variables
        int[] IP;
        int[] IPInverse;
        int[] E;
        int[] P;
        int[] InputKey;
        int[] PC1;
        int[] PC2;
        int[] BitsRotated;
        List<int[,]> S;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the tables used in the encryption and decryption processes
        /// </summary>
        public DES()
        {
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
            S = new List<int[,]>();
            S.Add(new int[4, 16] {{ 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
            {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
            {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
            {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }});

            S.Add(new int[4, 16] {{ 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
            {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
            {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
            {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }});

            S.Add(new int[4, 16] {{ 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
            {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
            {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
            {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }});


            S.Add(new int[4, 16] {{ 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
            {13, 8, 11, 5, 6, 15, 0,3, 4, 7, 2, 12, 1, 10, 14, 9},
            {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
            {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }});


            S.Add(new int[4, 16] {{2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14,9},
            {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
            {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
            {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }});

            S.Add(new int[4, 16] {{ 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
            {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
            {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
            {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }});


            S.Add(new int[4, 16] {{ 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
            {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
            {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
            {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }});


            S.Add(new int[4, 16] {{ 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
            {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
            {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
            {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }});
            #endregion

            #endregion
        }

        #endregion

        #region Encryption/Decryption

        #region Encryption
        /// <summary>
        /// Encrypts a text with 'Data Standard Encryption' - DES Algorithm
        /// </summary>
        /// <param name="PlainText">The plain text to encrypt (Text or Hexadecimal)</param>
        /// <param name="Key">The key used to encrypt the plain text</param>
        /// <returns>The encrypted string</returns>
        public string Encrypt(string PlainText, string Key)
        {

            #region Convert Text and Key To Binary
            BaseConversion baseConversion = new BaseConversion();

            #region Text

            PlainText = PlainText.Replace(" ", "");
            PlainText = PlainText.Replace("\n", "");
            PlainText = PlainText.Replace("\t", "");
            string BinaryText = "";
            if (PlainText.IndexOf("0x") != -1 || PlainText.IndexOf("0X") != -1)
            {
                BinaryText = baseConversion.HexadecimalToBinary(PlainText.ToUpper().Substring(2));
            }
            else
                BinaryText = baseConversion.TextToBinary(PlainText);
            #endregion

            #region Key
            string BinaryKey = "";
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
                BinaryKey = baseConversion.HexadecimalToBinary(Key.Substring(2));
            else
                BinaryKey = baseConversion.TextToBinary(Key);
            #endregion

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
                    if (keyIndex >= BinaryKey.Length) keyIndex = 0;
                }
                else
                {
                    Key64 = BinaryKey.Substring(keyIndex, BinaryKey.Length - keyIndex);
                    while (Key64.Length < 64)
                        Key64 += BinaryKey;
                    if (Key64.Length > 64)
                        Key64 = Key64.Remove(63);
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
                    Text64 = Text64.PadRight(64, '0');
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
                string CirculatedKey = PermutedKey;
                BinaryString binaryString = new BinaryString();
                for (int i = 0; i < RoundsCount; i++)
                {
                    CirculatedKey = binaryString.LeftCircularShift(CirculatedKey, BitsRotated[i]);
                    string KeyI = Rearrange(CirculatedKey, PC2);
                    string[] TextArray = Round(permutedText, KeyI);
                    if (i == RoundsCount - 1)
                        permutedText = TextArray[1] + TextArray[0];
                    else
                        permutedText = TextArray[0] + TextArray[1];
                }
                #endregion

                permutedText = Rearrange(permutedText, IPInverse);
                EncryptedText += baseConversion.BinaryToHexadecimal(permutedText);
            }
            return "0x" + EncryptedText.ToUpper();
        }

        /// <summary>
        /// Encrypts an array of bytes (64 bits) with 'Data Standard Encryption' - DES Algorithm
        /// </summary>
        /// <param name="PlainText">The bytes to encrypt (Text or Hexadecimal)</param>
        /// <param name="Key">The key used to encrypt the plain text</param>
        /// <returns>The encrypted string</returns>
        public byte[] Encrypt(byte[] PlainText, string Key)
        {
            #region Convert Text and Key To Binary
            BaseConversion baseConversion = new BaseConversion();

            #region Text
            string BinaryText = "";
            int length = PlainText.Count();
            for (int i = 0; i < length; i++)
                BinaryText += Convert.ToString(PlainText[i], 2).PadLeft(8, '0');
            if (length < 8)
                BinaryText = BinaryText.PadLeft(64, '0');
            #endregion

            #region Key
            string BinaryKey = "";
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
                BinaryKey = baseConversion.HexadecimalToBinary(Key.Substring(2));
            else
                BinaryKey = baseConversion.TextToBinary(Key);
            #endregion

            #endregion

            int keyIndex = 0;

            #region Get Bits From Key

            #region Binary Key
            string Key64;
            if (keyIndex + 64 <= BinaryKey.Length)
            {
                Key64 = BinaryKey.Substring(keyIndex, 64);
                keyIndex += 64;
                if (keyIndex >= BinaryKey.Length) keyIndex = 0;
            }
            else
            {
                Key64 = BinaryKey.Substring(keyIndex, BinaryKey.Length - keyIndex);
                while (Key64.Length < 64)
                    Key64 += BinaryKey;
                if (Key64.Length > 64)
                    Key64 = Key64.Remove(63);
            }
            #endregion

            #endregion

            #region First Permutation
            string permutedText = Rearrange(BinaryText, IP);
            string PermutedKey = Rearrange(Key64, PC1);
            #endregion

            #region Rounds
            int RoundsCount = 16;
            string CirculatedKey = PermutedKey;
            BinaryString binaryString = new BinaryString();
            for (int i = 0; i < RoundsCount; i++)
            {
                CirculatedKey = binaryString.LeftCircularShift(CirculatedKey, BitsRotated[i]);
                string KeyI = Rearrange(CirculatedKey, PC2);
                string[] TextArray = Round(permutedText, KeyI);
                if (i == RoundsCount - 1)
                    permutedText = TextArray[1] + TextArray[0];
                else
                    permutedText = TextArray[0] + TextArray[1];
            }
            #endregion

            permutedText = Rearrange(permutedText, IPInverse);

            #region Convert to array of bytes
            byte[] EncryptedByte = new byte[8];
            for (int i = 0; i < 8; i++)
                EncryptedByte[i] = (byte)Convert.ToByte(permutedText.Substring(i * 8, 8), 2);
            #endregion

            return EncryptedByte;
        }
        #endregion

        #region Decryption
        /// <summary>
        /// Decrypts a text with 'Data Standard Encryption' - DES Algorithm
        /// </summary>
        /// <param name="PlainText">The plain text to decrypt (Text or Hexadecimal)</param>
        /// <param name="Key">The key used to decrypt the plain text</param>
        /// <returns>The decrypted string</returns>
        public string Decrypt(string CipherText, string Key)
        {
            #region Convert Text and Key To Binary
            BaseConversion baseConversion = new BaseConversion();

            #region Text
            CipherText = CipherText.Replace("\n", "");
            CipherText = CipherText.Replace("\t", "");
            string BinaryText = "";
            if (CipherText.IndexOf("0x") != -1 || CipherText.IndexOf("0X") != -1)
                BinaryText = baseConversion.HexadecimalToBinary(CipherText.ToUpper().Substring(2));
            else
                BinaryText = baseConversion.TextToBinary(CipherText);
            #endregion

            #region Key
            string BinaryKey = "";
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
                BinaryKey = baseConversion.HexadecimalToBinary(Key.Substring(2));
            else
                BinaryKey = baseConversion.TextToBinary(Key);
            #endregion

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
                    if (keyIndex >= BinaryKey.Length) keyIndex = 0;
                }
                else
                {
                    Key64 = BinaryKey.Substring(keyIndex, BinaryKey.Length - keyIndex);
                    while (Key64.Length < 64)
                        Key64 += BinaryKey;
                    if (Key64.Length > 64)
                        Key64 = Key64.Remove(63);
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
                    Text64 = Text64.PadRight(64, '0');
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
                BinaryString binaryString = new BinaryString();
                string CirculatedKey = binaryString.LeftCircularShift(PermutedKey, 28);
                for (int i = 0; i < RoundsCount; i++)
                {
                    string KeyI = Rearrange(CirculatedKey, PC2);
                    string[] TextArray = Round(permutedText, KeyI);
                    if (i == RoundsCount - 1)
                        permutedText = TextArray[1] + TextArray[0];
                    else
                        permutedText = TextArray[0] + TextArray[1];
                    CirculatedKey = binaryString.RightCircularShift(CirculatedKey, BitsRotated[RoundsCount - i - 1]);
                }
                #endregion

                permutedText = Rearrange(permutedText, IPInverse);
                DecryptedText += baseConversion.BinaryToHexadecimal(permutedText);
            }
            return "0x" + DecryptedText.ToUpper();
        }

        /// <summary>
        /// Decrypts an array of bytes (64 bits) with 'Data Standard Encryption' - DES Algorithm
        /// </summary>
        /// <param name="PlainText">The bytes to decrypt (Text or Hexadecimal)</param>
        /// <param name="Key">The key used to decrypt the plain text</param>
        /// <returns>The decrypted string</returns>
        public byte[] Decrypt(byte[] PlainText, string Key)
        {
            #region Convert Text and Key To Binary
            BaseConversion baseConversion = new BaseConversion();

            #region Text
            string BinaryText = "";
            int length = PlainText.Count();
            for (int i = 0; i < length; i++)
                BinaryText += Convert.ToString(PlainText[i], 2).PadLeft(8, '0');
            if (length < 8)
                BinaryText = BinaryText.PadLeft(64, '0');
            #endregion

            #region Key
            string BinaryKey = "";
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
                BinaryKey = baseConversion.HexadecimalToBinary(Key.Substring(2));
            else
                BinaryKey = baseConversion.TextToBinary(Key);
            #endregion

            #endregion

            #region Get Bits From Key

            #region Binary Key
            string Key64;
            int keyIndex = 0;
            if (keyIndex + 64 <= BinaryKey.Length)
            {
                Key64 = BinaryKey.Substring(keyIndex, 64);
                keyIndex += 64;
                if (keyIndex >= BinaryKey.Length) keyIndex = 0;
            }
            else
            {
                Key64 = BinaryKey.Substring(keyIndex, BinaryKey.Length - keyIndex);
                while (Key64.Length < 64)
                    Key64 += BinaryKey;
                if (Key64.Length > 64)
                    Key64 = Key64.Remove(63);
            }
            #endregion

            #endregion

            #region First Permutation
            string permutedText = Rearrange(BinaryText, IP);
            string PermutedKey = Rearrange(Key64, PC1);
            #endregion

            #region Rounds
            int RoundsCount = 16;
            string CirculatedKey = PermutedKey;
            BinaryString binaryString = new BinaryString();
            for (int i = 0; i < RoundsCount; i++)
            {
                string KeyI = Rearrange(CirculatedKey, PC2);
                string[] TextArray = Round(permutedText, KeyI);
                if (i == RoundsCount - 1)
                    permutedText = TextArray[1] + TextArray[0];
                else
                    permutedText = TextArray[0] + TextArray[1];
                CirculatedKey = binaryString.RightCircularShift(CirculatedKey, BitsRotated[RoundsCount - i - 1]);
            }
            #endregion

            permutedText = Rearrange(permutedText, IPInverse);

            #region Convert to array of bytes
            byte[] EncryptedByte = new byte[8];
            for (int i = 0; i < 8; i++)
                EncryptedByte[i] = (byte)Convert.ToByte(permutedText.Substring(i * 8, 8), 2);
            #endregion

            return EncryptedByte;
        }
        #endregion

        #endregion

        #region Helping Functions

        /// <summary>
        /// Rearranges a text according to a permutation array
        /// </summary>
        /// <param name="Text">The text to rearrange</param>
        /// <param name="Permutation">The permutation array whose values are used to rearrange the text</param>
        /// <returns></returns>
        private string Rearrange(string Text, int[] Permutation)
        {
            int length = Permutation.Count();
            string ArrangedText = "";
            for (int i = 0; i < length; i++)
                ArrangedText += Text[Permutation[i] - 1];
            return ArrangedText;
        }

        /// <summary>
        /// Executes the round of the DES Algorithm
        /// L(n) = R(n-1); The left part of the current round equals to the right part of the previous round
        /// Applies function F (right part, key) of DES algorithm, that's is an intermediate result
        /// Rn: The right part of the current round = XORs the left part and the intermediate result
        /// </summary>
        /// <param name="Text">The plain text = 64 bits</param>
        /// <param name="Key">The key XORed with the right part of the plain text </param>
        /// <returns>The plain text after applying DES round processes</returns>
        private string[] Round(string Text, string Key)
        {
            BinaryString binaryString = new BinaryString();
            int length = Text.Length / 2;
            string LeftPart = Text.Substring(0, length);
            string RightPart = Text.Substring(length, length);
            string[] ReturnString = new string[] { RightPart, "" };
            RightPart = FunctionF(RightPart, Key);
            ReturnString[1] = binaryString.BinaryXOR(RightPart, LeftPart);
            return ReturnString;
        }

        /// <summary>
        /// Applies DES function F to the right part of plain text with the key
        /// Rearranges the right part according to the expansion table (E Table)
        /// Intermediate Result = XORs the right part and key
        /// Rearranges this Intermediate Result according to the S-Boxes, then according to the permutaion table (P Table)
        /// </summary>
        /// <param name="RightPart">The right part of the plain text</param>
        /// <param name="Key">The key used in XORing with the right part</param>
        /// <returns>The plain text after applying DES function F</returns>
        private string FunctionF(string RightPart, string Key)
        {
            RightPart = Rearrange(RightPart, E);
            BinaryString binaryString = new BinaryString();
            string XOR = binaryString.BinaryXOR(RightPart, Key);

            //S-Boxes Substitution
            string SBoxesResult = "";
            int sBoxesColumns = 6;
            for (int i = 0; i < 48; i += sBoxesColumns)
            {
                string temp = XOR.Substring(i, sBoxesColumns);
                string t = temp[0].ToString() + temp[temp.Length - 1].ToString();
                int row = (int)Convert.ToInt32(t, 2);
                t = temp.Substring(1, temp.Length - 2);
                int column = (int)Convert.ToInt32(t, 2);
                SBoxesResult += Convert.ToString(S[i / sBoxesColumns][row, column], 2).PadLeft(4, '0');
            }
            SBoxesResult = Rearrange(SBoxesResult, P);
            return SBoxesResult;
        }

        #endregion
    }
}