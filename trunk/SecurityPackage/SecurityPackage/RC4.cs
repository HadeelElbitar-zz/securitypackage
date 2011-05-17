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
        string[] T;
        #endregion

        #region Constructors
        public RC4()
        {
            //Key = "8AEC1320";
        }
        #endregion

        public string Encrypt(string PlainText, string Key)
        {
            #region Initialization
            int KeyLength = Key.Length;
            S = new int[255];
            T = new string[255];
            for (int k = 0; k < 255; k++)
            {
                S[k] = k;
                T[k] = Key.Substring((k * 2) % KeyLength, 2);
            }
            #endregion

            #region Stream Generation
            int i = 0, j = 0;
            string EncryptedString = "";
            foreach (char ch in PlainText)
            {
                i = (i + 1) % 255;
                int t = int.Parse(Convert.ToString(Convert.ToByte(T[i], 16), 10));
                j = (j + S[i] + t) % 255;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinarySubText = Convert.ToString(ch, 2).PadLeft(8, '0');
                string BinaryXORResult = XORFunction(BinaryKey, BinarySubText);
                EncryptedString += Convert.ToChar(Convert.ToInt32(BinaryXORResult, 2));//Binary to Character
            }
            #endregion

            return EncryptedString;
        }

        public string Decrypt(string CipherText, string Key)
        {
            #region Initialization
            int KeyLength = Key.Length;
            S = new int[255];
            T = new string[255];
            for (int k = 0; k < 255; k++)
            {
                S[k] = k;
                T[k] = Key.Substring((k * 2) % KeyLength, 2);
            }
            #endregion

            #region Stream Generation
            int i = 0, j = 0;
            string DecryptedString = "";
            foreach (char ch in CipherText)
            {
                i = (i + 1) % 255;
                int t = int.Parse(Convert.ToString(Convert.ToByte(T[i], 16), 10));
                j = (j + S[i] + t) % 255;
                Swap(ref S[i], ref S[j]);
                int k = S[(S[i] + S[j]) % 256];
                string BinaryKey = Convert.ToString(k, 2).PadLeft(8, '0');
                string BinarySubText = Convert.ToString(ch, 2).PadLeft(8, '0');
                string BinaryXORResult = XORFunction(BinaryKey, BinarySubText);
                DecryptedString += Convert.ToChar(Convert.ToInt32(BinaryXORResult, 2));//Binary to Character
            }
            #endregion

            return DecryptedString;
        }

        #region Helping Functions
        void Swap(ref int firstValue, ref int SecondValue)
        {
            int temp = firstValue;
            firstValue = SecondValue;
            SecondValue = temp;
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