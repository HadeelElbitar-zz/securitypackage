using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class RailFenceCipher
    {
        #region Constructors
        List<char>[] Arrays;
        public RailFenceCipher() { }
        #endregion

        #region Helping Functions
        void PrepareDepthLevel(int DL)
        {
            Arrays = new List<char>[DL];
            for (int i = 0; i < DL; i++)
                Arrays[i] = new List<char>();
        }
        #endregion

        #region Encryption
        public string Encrypt(string PlainText, int DepthLevel)
        {
            PlainText = PlainText.Replace(" ", "");
            PrepareDepthLevel(DepthLevel);
            string CipherText = "";
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
        public string Decrypt(string CipherText, int DepthLevel)
        {
            CipherText = CipherText.Replace(" ", "");
            PrepareDepthLevel(DepthLevel);
            string PlainText = "";
            int Lenght = CipherText.Length;
            int Count = Lenght / DepthLevel;
            int ExtraChars = Lenght % DepthLevel;
            for (int i = 0; i < DepthLevel; i++)
                Arrays[i] = new List<char>();
            int k = 0;
            for (int j = 0; j < DepthLevel; j++)
                for (int i = 0; k < Lenght && i < Count; k++, i++)
                {
                    if (j < ExtraChars && i == Count - 1)
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
    }
}