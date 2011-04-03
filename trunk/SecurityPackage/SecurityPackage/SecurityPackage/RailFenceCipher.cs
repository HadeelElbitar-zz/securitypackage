using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class RailFenceCipher
    {
        #region Constructors
        string PlainText, CipherText;
        int DepthLevel , ExtraChars;
        List<char>[] Arrays;
        /// <summary>
        /// use it when decrypting only
        /// </summary>
        public RailFenceCipher() { }
        /// <summary>
        /// use it when encrypting only
        /// </summary>
        /// <param name="_PlaintText"></param>
        /// <param name="_DepthLevel"></param>
        public RailFenceCipher(string _PlaintText , int _DepthLevel)
        {
            PlainText = _PlaintText;
            PrepareDepthLevel(_DepthLevel);
        }
        #endregion

        #region Helping Functions
        void PrepareDepthLevel(int DL)
        {
            DepthLevel = DL;
            Arrays = new List<char>[DepthLevel];
            for (int i = 0; i < DepthLevel; i++)
                Arrays[i] = new List<char>();
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            if (PlainText == null || DepthLevel <= 0)
                return "Please choose a valid Plain Text and Depth Level !";
            CipherText = "";
            int Count = PlainText.Length;
            int j = -1;
            for (int i = 0; i < Count; i++)
            {
                if (j == DepthLevel - 1) j = -1;
                Arrays[++j].Add(PlainText[i]);
            }
            for (int i = 0; i < DepthLevel; i++)
            {
                int InCount = Arrays[i].Count;
                for (int k = 0; k < InCount; k++)
                    CipherText += Arrays[i][k];
            }
            return CipherText;
        }
        #endregion
        
        #region Decryption
        public string Decrypt()
        {
            if (CipherText == null)
                return "There is no Encrypted CipherText to Decrypt !";
            if (DepthLevel <= 0)
                return "please choose a valid Depth Level !";
            PlainText = "";
            int Lenght = CipherText.Length;
            int Count = Lenght / DepthLevel;
            ExtraChars = Lenght % DepthLevel;
            //if (Count * DepthLevel != Lenght) Count++;
            for (int i = 0; i < DepthLevel; i++)
                Arrays[i] = new List<char>();
            int k = 0;
            for (int j = 0; j < DepthLevel; j++)
                for (int i = 0; k < Lenght && i < Count; k++, i++)
                {
                    if (j < ExtraChars && i == Count-1)
                    {
                        Arrays[j].Add(CipherText[k++]);
                        Arrays[j].Add(CipherText[k]);
                    }
                    else
                        Arrays[j].Add(CipherText[k]);
                }
            for (int i = 0; i < Count + 1; i++)
                for (int j = 0; j < DepthLevel; j++)
                {
                    try
                    {
                        PlainText += Arrays[j][i];
                    }
                    catch { }
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
            }
        }
        /// <summary>
        /// Set new Key
        /// </summary>
        public int _DepthLevel
        {
            set
            {
                DepthLevel = value;
                PrepareDepthLevel(DepthLevel);
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
            }
        }
        #endregion
    }
}
