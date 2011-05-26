using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class RC4
    {
        #region Variables
        int[] S;
        int[] T;
        #endregion

        #region Constructors
        public RC4()
        {
            //Key = "8AEC1320";
        }
        #endregion

        public string Encrypt(string PlainText, string Key)
        {
            PlainText = "pedia";
            Key = "0x6044db6d41b7";
            //CipherText="0x1021BF0420";

            PlainText = PlainText.Replace(" ", "");
            int length = PlainText.Length;
            bool HexadecimalKey = false;
            int[] KeyIntegers = new int[1];
            BaseConversion baseConversion = new BaseConversion();

            #region Text and Key preprocessing

            #region Convert Text to Binary
            string[] BinaryPlainText = new string[length];
            if (PlainText.IndexOf("0x") != -1 || PlainText.IndexOf("0X") != -1)
            {
                PlainText = PlainText.Substring(2);
                BinaryPlainText = baseConversion.HexadecimalToBinaryStrings(PlainText);
            }
            else
            {
                BinaryPlainText = baseConversion.TextToBinaryStrings(PlainText);
            }
            #endregion

            #region Key Integers Array
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
            {
                Key = Key.Substring(2);
                HexadecimalKey = true;
                length = Key.Length;
                KeyIntegers = new int[(length / 2) + (length % 2)];
                for (int k = 0; k < length / 2; k++)
                {
                    KeyIntegers[k] = baseConversion.HexadecimalToDecimalTwo(Key[k * 2].ToString() + Key[k * 2 + 1].ToString());
                }
                if (length % 2 != 0)
                    KeyIntegers[KeyIntegers.Length - 1] = baseConversion.HexadecimalToDecimalTwo(Key[length - 1].ToString());
            }
            else
            {
                length = Key.Length;
                for (int k = 0; k < length; k++)
                    KeyIntegers[k] = int.Parse(Key[k].ToString());
            }
            #endregion

            #endregion

            #region Key Generation
            int KeyLength = KeyIntegers.Length;
            S = new int[256];
            int[] T = new int[256];
            if (HexadecimalKey)
            {
                for (int k = 0; k < 256; k++)
                {
                    S[k] = k;
                    T[k] = (KeyIntegers[k % KeyLength]);
                }
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
            foreach (string BinarySubText in BinaryPlainText)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinaryXORResult = BinaryXOR(BinaryKey, BinarySubText);
                EncryptedString += baseConversion.BinaryToHexadecimal(BinaryXORResult);
            }
            #endregion

            EncryptedString = "0x" + EncryptedString.ToUpper();
            return EncryptedString;
        }

        public string Decrypt(string CipherText, string Key)
        {
            return "";
        }
        //public string Decrypt(string CipherText, string Key)
        //{
        //    //PlainText = "pedia";
        //    Key = "0x6044db6d41b7";
        //    //CipherText="0x1021BF0420";

        //    CipherText = "795168df67";
        //    CipherText = CipherText.Replace(" ", "");

        //    #region Convert Text and Key To Binary

        //    #region Text
        //    //bool HexText = false;
        //    //string BinaryText = "";
        //    //if (PlainText.IndexOf("0x") != -1 || PlainText.IndexOf("0X") != -1)
        //    //{
        //    //    HexText = true;
        //    //    BinaryText = HexadecimalToBinary(PlainText.Substring(2));
        //    //}
        //    //else
        //    //    BinaryText = TextToBinary(PlainText);
        //    #endregion

        //    #region Key

        //    //We are supposed to get a text key an generate its hexadecimal keystream
        //    string[] DecimalKey = { "" };
        //    if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
        //    {
        //        Key = Key.Substring(2);
        //        DecimalKey = HexadecimalToDecimal(Key);
        //    }
        //    //else
        //    //    BinaryKey = TextToBinary(Key);
        //    #endregion

        //    #endregion


        //    #region Initialization

        //    int KeyLength = DecimalKey.Length;
        //    S = new int[255];
        //    T = new int[255];
        //    for (int k = 0; k < 255; k++)
        //    {
        //        S[k] = k;
        //        T[k] = int.Parse(DecimalKey[k % KeyLength]);
        //    }
        //    #endregion


        //    #region Initial Permutation of S
        //    int Index = 0;
        //    for (int k = 0; k < 255; k++)
        //    {
        //        Index = (Index + S[k] + T[k]) % 255;
        //        Swap(ref S[k], ref S[Index]);
        //    }
        //    #endregion

        //    #region Stream Generation
        //    int i = 0, j = 0;
        //    string EncryptedString = "";
        //    foreach (char ch in CipherText)
        //    {
        //        i = (i + 1) % 256;
        //        j = (j + S[i]) % 256;
        //        Swap(ref S[i], ref S[j]);
        //        int k = S[(S[i] + S[j]) % 256];
        //        string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
        //        string BinarySubText = Convert.ToString(ch, 2).PadLeft(8, '0');
        //        string BinaryXORResult = BinaryXOR(BinaryKey, BinarySubText);
        //        EncryptedString += baseConversion.BinaryToHexadecimal(BinaryXORResult);
        //    }
        //    #endregion
        //    //EncryptedString = HexadecimalToText(EncryptedString);
        //    return EncryptedString;
        //}

        #region Helping Functions
        void Swap(ref int firstValue, ref int SecondValue)
        {
            int temp = firstValue;
            firstValue = SecondValue;
            SecondValue = temp;
        }
        string BinaryXOR(string F, string S)
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
