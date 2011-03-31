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
        int DepthLevel;
        List<char>[] Arrays;
        public RailFenceCipher() { }
        public RailFenceCipher(string _PlaintText , int _DepthLevel)
        {
            PlainText = _PlaintText;
            DepthLevel = _DepthLevel;
            Arrays = new List<char>[DepthLevel];
            for (int i = 0; i < DepthLevel; i++)
                Arrays[i] = new List<char>();
        }
        #endregion

        #region Encryption
        public string Encrypt()
        {
            CipherText = "";
            int Count = PlainText.Length;
            int j = -1;
            for (int i = 0; i < Count; i++)
            {
                if (j == DepthLevel - 1) j = -1;
                //if (PlainText[i] == ' ')
                //    continue;
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
            PlainText = "";
            int Count = CipherText.Length / DepthLevel;
            int Lenght = CipherText.Length;
            if (Count * DepthLevel != Lenght) Count++;
            for (int i = 0; i < DepthLevel; i++)
                Arrays[i] = new List<char>();
            int k = 0;
            for (int j = 0; j < DepthLevel; j++)
                for (int i = 0; k < Lenght && i < Count; k++, i++)
                    Arrays[j].Add(CipherText[k]);
            for (int i = 0; i < Count; i++)
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
