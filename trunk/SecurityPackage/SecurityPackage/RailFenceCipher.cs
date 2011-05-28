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
        /// <summary>
        /// Creates an object of Rail Fence Cipher
        /// </summary>
        public RailFenceCipher() { }
        #endregion

        #region Encryption
        /// <summary>
        /// Encrypts the given text with the given depth level.
        /// </summary>
        /// <param name="PlainText"> Text to be encrypted</param>
        /// <param name="DepthLevel"> An integer represents the depth level of encryption</param>
        /// <returns>It returns a string contains the encrypted text.</returns>
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
        /// <summary>
        /// Decrypts the given text with the given depth level.
        /// </summary>
        /// <param name="CipherText"> Text to be decrypted</param>
        /// <param name="DepthLevel"> An integer represents the depth level of decryption</param>
        /// <returns>It returns a string contains the decrypted text.</returns>
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

        #region Helping Functions
        /// <summary>
        /// Prepares the lists of depth level to use it later in the cipher to store the chars.
        /// </summary>
        /// <param name="DL">Depth Level</param>
        void PrepareDepthLevel(int DL)
        {
            Arrays = new List<char>[DL];
            for (int i = 0; i < DL; i++)
                Arrays[i] = new List<char>();
        }
        #endregion
    }
}