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

            //795168df67
            PlainText = PlainText.Replace(" ", "");

            #region Convert Text and Key To Binary

            #region Text
            //bool HexText = false;
            //string BinaryText = "";
            //if (PlainText.IndexOf("0x") != -1 || PlainText.IndexOf("0X") != -1)
            //{
            //    HexText = true;
            //    BinaryText = HexadecimalToBinary(PlainText.Substring(2));
            //}
            //else
            //    BinaryText = TextToBinary(PlainText);
            #endregion

            #region Key

            //We are supposed to get a text key an generate its hexadecimal keystream
            string[] DecimalKey = { "" };
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
            {
                Key = Key.Substring(2);
                DecimalKey = HexadecimalToDecimal(Key);
            }
            //else
            //    BinaryKey = TextToBinary(Key);
            #endregion

            #endregion


            #region Initialization

            int KeyLength = DecimalKey.Length;
            S = new int[255];
            T = new int[255];
            for (int k = 0; k < 255; k++)
            {
                S[k] = k;
                T[k] = int.Parse(DecimalKey[k % KeyLength]);
            }
            #endregion


            #region Initial Permutation of S
            int Index = 0;
            for (int k = 0; k < 255; k++)
            {
                Index = (Index + S[k] + T[k]) % 255;
                Swap(ref S[k], ref S[Index]);
            }
            #endregion

            #region Stream Generation
            int i = 0, j = 0;
            string EncryptedString = "";
            foreach (char ch in PlainText)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinarySubText = Convert.ToString(ch, 2).PadLeft(8, '0');
                string BinaryXORResult = BinaryXOR(BinaryKey, BinarySubText);
                EncryptedString += BinaryToHexadecimal(BinaryXORResult);
            }
            #endregion
            //EncryptedString = HexadecimalToText(EncryptedString);
            return EncryptedString;
        }

        public string Decrypt(string CipherText, string Key)
        {
            //PlainText = "pedia";
            Key = "0x6044db6d41b7";
            //CipherText="0x1021BF0420";

            CipherText = "795168df67";
            CipherText = CipherText.Replace(" ", "");

            #region Convert Text and Key To Binary

            #region Text
            //bool HexText = false;
            //string BinaryText = "";
            //if (PlainText.IndexOf("0x") != -1 || PlainText.IndexOf("0X") != -1)
            //{
            //    HexText = true;
            //    BinaryText = HexadecimalToBinary(PlainText.Substring(2));
            //}
            //else
            //    BinaryText = TextToBinary(PlainText);
            #endregion

            #region Key

            //We are supposed to get a text key an generate its hexadecimal keystream
            string[] DecimalKey = { "" };
            if (Key.IndexOf("0x") != -1 || Key.IndexOf("0X") != -1)
            {
                Key = Key.Substring(2);
                DecimalKey = HexadecimalToDecimal(Key);
            }
            //else
            //    BinaryKey = TextToBinary(Key);
            #endregion

            #endregion


            #region Initialization

            int KeyLength = DecimalKey.Length;
            S = new int[255];
            T = new int[255];
            for (int k = 0; k < 255; k++)
            {
                S[k] = k;
                T[k] = int.Parse(DecimalKey[k % KeyLength]);
            }
            #endregion


            #region Initial Permutation of S
            int Index = 0;
            for (int k = 0; k < 255; k++)
            {
                Index = (Index + S[k] + T[k]) % 255;
                Swap(ref S[k], ref S[Index]);
            }
            #endregion

            #region Stream Generation
            int i = 0, j = 0;
            string EncryptedString = "";
            foreach (char ch in CipherText)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinarySubText = Convert.ToString(ch, 2).PadLeft(8, '0');
                string BinaryXORResult = BinaryXOR(BinaryKey, BinarySubText);
                EncryptedString += BinaryToHexadecimal(BinaryXORResult);
            }
            #endregion
            //EncryptedString = HexadecimalToText(EncryptedString);
            return EncryptedString;
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
        private string HexadecimalToBinary(string Text)
        {
            int length = Text.Length;
            string BinaryText = "";
            for (int i = 0; i < length; i++)
            {
                BinaryText += Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 2).PadLeft(4, '0');
            }
            return BinaryText;
        }
        private string[] HexadecimalToDecimal(string Text)
        {
            int length = Text.Length;
            string[] DecimalText = new string[length];
            for (int i = 0; i < length; i++)
            {
                DecimalText[i] = Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 10).PadLeft(4, '0');
            }
            return DecimalText;
        }
        string BinaryToHexadecimal(string Text)
        {
            int length = Text.Length;
            string HexadecimalText = "";
            for (int i = 0; i < length; i += 4)
            {
                try
                {
                    HexadecimalText += Convert.ToString(Convert.ToInt32(Text.Substring(i, 4), 2), 16);
                }
                catch { }
            }
            return HexadecimalText;
        }
        private string BinaryToText(string Text)
        {
            string returnText = "";
            int length = Text.Length;
            for (int i = 0; i < length; i += 8)
            {
                try
                {
                    returnText += Convert.ToChar(Convert.ToInt32(Text.Substring(0, 8), 2));
                    Text = Text.Remove(0, 8);
                }
                catch { }
            }
            return returnText;
        }
        string HexadecimalToText(string HexadecimalText)
        {
            int length = HexadecimalText.Length;
            string Text = "";
            for (int i = 0; i < length; i += 2)
            {
                Text += (char)Convert.ToInt32(HexadecimalText.Substring(i, 2), 16); ;
            }
            return Text;
        }
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
