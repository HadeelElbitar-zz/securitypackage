using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class RC4
    {
        #region Constructor
        /// <summary>
        /// Makes a new instance of RC4 class
        /// </summary>
        public RC4() { }
        #endregion

        #region Encryption/Decryption

        #region Encryption

        /// <summary>
        /// Encrypts a plain text according to the RC4 algorithm
        /// </summary>
        /// <param name="PlainText">The plain text to encrypt</param>
        /// <param name="Key">The key used to encrypt the plain text (Text or Hexadecimal)</param>
        /// <returns>The encrypted string (hexadecimal format)</returns>
        public string Encrypt(string PlainText, string Key)
        {
            #region Text and Key preprocessing
            BaseConversion baseConversion = new BaseConversion();

            #region Convert Text to Binary
            PlainText = PlainText.Replace(" ", "");
            PlainText = PlainText.Replace("\n", "");
            string[] BinaryPlainText = new string[PlainText.Length];
            if (PlainText.IndexOf("0x") != -1 || PlainText.IndexOf("0X") != -1)
                BinaryPlainText = baseConversion.HexadecimalToBinaryStrings(PlainText.Substring(2));
            else
                BinaryPlainText = baseConversion.TextToBinaryStrings(PlainText);
            #endregion

            #region Key Integers Array

            int[] KeyIntegers = new int[1];
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
            {
                Key = Key.Substring(2);
                int length = Key.Length;
                KeyIntegers = new int[(length / 2) + (length % 2)];
                for (int k = 0; k < length / 2; k++)
                    KeyIntegers[k] = baseConversion.HexadecimalToDecimalTwo(Key[k * 2].ToString() + Key[k * 2 + 1].ToString());
                if (length % 2 != 0)
                    KeyIntegers[KeyIntegers.Length - 1] = baseConversion.HexadecimalToDecimalTwo(Key[length - 1].ToString());
            }
            else
            {
                int length = Key.Length;
                KeyIntegers = new int[length];
                for (int k = 0; k < length; k++)
                    KeyIntegers[k] = int.Parse(Key[k].ToString());
            }
            #endregion

            #endregion

            #region Key Generation
            int KeyLength = KeyIntegers.Length;
            int[] S = new int[256];
            int[] T = new int[256];
            for (int k = 0; k < 256; k++)
            {
                S[k] = k;
                T[k] = (KeyIntegers[k % KeyLength]);
            }
            #endregion

            #region Initial Permutation of S
            int Index = 0;
            for (int k = 0; k < 256; k++)
            {
                Index = (Index + S[k] + T[k]) % 256;
                Swap(ref S[k], ref S[Index]);
            }
            #endregion

            #region Stream Generation
            int i = 0, j = 0;
            string EncryptedString = "";
            BinaryString binaryString = new BinaryString();
            foreach (string BinarySubText in BinaryPlainText)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinaryXORResult = binaryString.BinaryXOR(BinaryKey, BinarySubText);
                EncryptedString += baseConversion.BinaryToHexadecimal(BinaryXORResult);
            }
            #endregion

            EncryptedString = "0x" + EncryptedString.ToUpper();
            return EncryptedString;
        }

        #endregion

        #region Decryption

        /// <summary>
        /// Decrypts a plain text according to the RC4 algorithm
        /// </summary>
        /// <param name="CipherText">The plain text to decrypt</param>
        /// <param name="Key">The key used to decrypt the plain text (Text or Hexadecimal)</param>
        /// <returns>The decrypted string (text format)</returns>
        public string Decrypt(string CipherText, string Key)
        {
            #region Text and Key preprocessing

            BaseConversion baseConversion = new BaseConversion();

            #region Convert Text to Binary
            CipherText = CipherText.Replace(" ", "");
            CipherText = CipherText.Replace("\n", "");
            CipherText = CipherText.Replace("\t", "");
            string[] BinaryPlainText = new string[CipherText.Length];
            if (CipherText.IndexOf("0x") != -1 || CipherText.IndexOf("0X") != -1)
            {
                CipherText = CipherText.Substring(2);
                int length = CipherText.Length;
                BinaryPlainText = new string[(length / 2) + (length % 2)];
                for (int k = 0; k < length / 2; k++)
                    BinaryPlainText[k] = baseConversion.HexadecimalToBinary(CipherText[k * 2].ToString() + CipherText[k * 2 + 1].ToString()).ToString();
                if (length % 2 != 0)
                    BinaryPlainText[BinaryPlainText.Length - 1] = baseConversion.HexadecimalToBinary(Key[length - 1].ToString()).ToString();
            }
            else
                BinaryPlainText = baseConversion.TextToBinaryStrings(CipherText);
            #endregion

            #region Key Integers Array
            int[] KeyIntegers = new int[1];
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
            {
                Key = Key.Substring(2);
                int length = Key.Length;
                KeyIntegers = new int[(length / 2) + (length % 2)];
                for (int k = 0; k < length / 2; k++)
                    KeyIntegers[k] = baseConversion.HexadecimalToDecimalTwo(Key[k * 2].ToString() + Key[k * 2 + 1].ToString());
                if (length % 2 != 0)
                    KeyIntegers[KeyIntegers.Length - 1] = baseConversion.HexadecimalToDecimalTwo(Key[length - 1].ToString());
            }
            else
            {
                int length = Key.Length;
                KeyIntegers = new int[length];
                for (int k = 0; k < length; k++)
                    KeyIntegers[k] = int.Parse(Key[k].ToString());
            }
            #endregion

            #endregion

            #region Key Generation
            int KeyLength = KeyIntegers.Length;
            int[] S = new int[256];
            int[] T = new int[256];
            for (int k = 0; k < 256; k++)
            {
                S[k] = k;
                T[k] = (KeyIntegers[k % KeyLength]);
            }
            #endregion

            #region Initial Permutation of S
            int Index = 0;
            for (int k = 0; k < 256; k++)
            {
                Index = (Index + S[k] + T[k]) % 256;
                Swap(ref S[k], ref S[Index]);
            }
            #endregion

            #region Stream Generation
            int i = 0, j = 0;
            string DecryptedString = "";
            BinaryString binaryString = new BinaryString();
            foreach (string BinarySubText in BinaryPlainText)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinaryXORResult = binaryString.BinaryXOR(BinaryKey, BinarySubText);
                DecryptedString += baseConversion.BinaryToText(BinaryXORResult);
            }
            #endregion

            return DecryptedString;
        }
        #endregion


        #endregion

        #region Helping Functions

        /// <summary>
        /// Swaps two ineteger values
        /// </summary>
        /// <param name="firstValue">The first integer</param>
        /// <param name="SecondValue">The second integer</param>
        private void Swap(ref int firstValue, ref int SecondValue)
        {
            int temp = firstValue;
            firstValue = SecondValue;
            SecondValue = temp;
        }

        #endregion
    }
}