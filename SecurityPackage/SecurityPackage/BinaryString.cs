using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class BinaryString
    {
        /// <summary>
        /// Makes N left-circular shifts to left and right parts of Key
        /// </summary>
        /// <param name="Key">The key to left-circular shift</param>
        /// <param name="BitsRotated">N: Number of left-circular shifts</param>
        /// <returns>The left-circular shifted string</returns>
        public string LeftCircularShift(string Key, int BitsRotated)
        {
            int length = Key.Length / 2;
            string LeftPart = Key.Substring(0, length);
            string RightPart = Key.Substring(length, length);

            for (int i = 0; i < BitsRotated; i++)
            {
                char temp = LeftPart[0];
                LeftPart = LeftPart.Remove(0, 1);
                LeftPart += temp.ToString();

                temp = RightPart[0];
                RightPart = RightPart.Remove(0, 1);
                RightPart += temp.ToString();
            }
            return LeftPart + RightPart;
        }

        /// <summary>
        /// Makes N right-circular shifts to left and right parts of Key
        /// </summary>
        /// <param name="Key">The key to right-circular shift</param>
        /// <param name="BitsRotated">N: Number of right-circular shifts</param>
        /// <returns>The right-circular shifted string</returns>
        public string RightCircularShift(string Key, int BitsRotated)
        {
            int length = Key.Length / 2;
            string LeftPart = Key.Substring(0, length);
            string RightPart = Key.Substring(length, length);

            for (int i = 0; i < BitsRotated; i++)
            {
                length = LeftPart.Length - 1;
                char temp = LeftPart[length];
                LeftPart = LeftPart.Remove(length, 1);
                LeftPart = LeftPart.Insert(0, temp.ToString());

                length = RightPart.Length - 1;
                temp = RightPart[length];
                RightPart = RightPart.Remove(length, 1);
                RightPart = RightPart.Insert(0, temp.ToString());
            }
            return LeftPart + RightPart;
        }

        /// <summary>
        /// XOR two binary strings, may be of different lengths
        /// </summary>
        /// <param name="F">The first binary string</param>
        /// <param name="S">The second binary string</param>
        /// <returns>The XOR of the two binary strings</returns>
        public string BinaryXOR(string F, string S)
        {
            #region Preprocessing
            int FLength = F.Length;
            int SLength = S.Length;
            int length = 0;
            if (FLength > SLength)
            {
                S = S.PadLeft(FLength, '0');
                length = FLength;
            }
            else
            {
                F = F.PadLeft(SLength, '0');
                length = SLength;
            }
            #endregion

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
    }
}
