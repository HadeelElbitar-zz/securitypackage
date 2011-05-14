using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SecurityPackage
{
    class PolyalphabeticCipher
    {
        #region Constructors
        string PlainText, CipherText, Key;
        char[,] Matrix = new char[26, 26];
        int KeyMode;
        Dictionary<char, int> AlphaIndex = new Dictionary<char, int>();
        /// <summary>
        /// use it when decrypting only
        /// </summary>
        public PolyalphabeticCipher() { }
        /// <summary>
        /// use it when encrypting only
        /// </summary>
        /// <param name="_PlainText"></param>
        /// <param name="_Key"></param>
        public PolyalphabeticCipher(string _PlainText, string _Key, int Mode) // Mode = 0 "AutoKey" , Mode = 1 "RepeatKey"
        {
            PlainText = _PlainText.ToLower().Replace(" ","");
            PrepareKey(_Key,PlainText, Mode);
        }
        #endregion

        #region Helping Functions
        void PrepareKey(string NewKey ,string PT, int Mode)
        {
            Key = NewKey.ToUpper();
            KeyMode = Mode;
            if (Key.Length < PT.Length && KeyMode == 0)
            {
                int Difference = PT.Length - Key.Length;
                int startIndex = PT.Length - Difference;
                Key += PT.Substring(startIndex, Difference);
                Key = Key.ToUpper();
            }
            else if (Key.Length < PT.Length && KeyMode == 1)
            {
                int Difference = PT.Length - Key.Length;
                Key += Key.Substring(0, Difference);
            }
            //Key = Key.Replace(" ", "");
            BuildMatrix();
            FillIndex();
        }
        void BuildMatrix()
        {
            char Initial = 'A';
            int Incremental, x;
            for (int i = 0; i < 26; i++)
            {
                Incremental = i;
                for (int j = 0; j < 26; j++)
                {
                    x = Convert.ToInt32(Initial) + Incremental;
                    if (x > 90)
                    {
                        x = 65;
                        Incremental = 0;
                    }
                    Matrix[i, j] = Convert.ToChar(x);
                    Incremental++;
                }
            }
        }
        void FillIndex()
        {
            char Initial = 'A';
            AlphaIndex = new Dictionary<char, int>();
            for (int i = 0; i < 26; i++)
                AlphaIndex.Add(Convert.ToChar(Convert.ToInt32(Initial) + i), i);
        }
        int SearchMatrixRow(int RowIndex , char X)
        {
            for (int i = RowIndex; ;)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (Matrix[i, j] == X)
                        return j;
                }
            }
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            if (PlainText == null || Key == null)
                return "Please choose a valid Plain Text and Key !";
            MessageBox.Show(Key);
            CipherText = "";
            int i = -1;
            string TPlainText = PlainText.ToUpper();
            foreach (char item in TPlainText)
                CipherText += Matrix[AlphaIndex[item], AlphaIndex[Key[++i]]];
            return CipherText;
        }
        #endregion

        #region Decryption
        public string Decrypt()
        {
            if (CipherText == null)
                return "There is no Encrypted CipherText to Decrypt !";
            if (Key == null || (KeyMode != 0 && KeyMode != 1))
                return "please choose a valid key and Mode !";
            if (CipherText == null)
                return "Text didn't got encrypted !";
            PrepareKey(Key, CipherText, KeyMode);
            string PlainText = "";
            int i = -1;
            foreach (char item in CipherText)
                PlainText += Matrix[SearchMatrixRow(AlphaIndex[Key[++i]], item), 0];
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
                Key = Key.Replace(" ", "");
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
        /// <summary>
        /// change the key mode 0: Auto Key , 1: Repeat Key
        /// </summary>
        public int _Mode
        {
            set
            {
                KeyMode = value;
            }
        }
        #endregion
    }
}
