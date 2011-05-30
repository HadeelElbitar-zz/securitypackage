using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class BaseConversion
    {
        #region From Text

        /// <summary>
        /// Converts a text string to a binary string
        /// Each character is left padded with zeros to be be of length 8..
        /// </summary>
        /// <param name="Text"> The text string to convert</param>
        /// <returns>The binary string</returns>
        public string TextToBinary(string Text)
        {
            int length = Text.Length;
            string BinaryText = "";
            for (int i = 0; i < length; i++)
            {
                string temp = Convert.ToString(Text[i], 2).PadLeft(8, '0');
                BinaryText += temp;
            }
            return BinaryText;
        }

        /// <summary>
        /// Converts a text string to an array of binary strings 
        /// Each character is converted to a binary string left padded with zeros to be be of length 8
        /// <param name="Text"> The text string to convert</param>
        /// <returns>The array of binary strings</returns>
        public string[] TextToBinaryStrings(string Text)
        {
            int length = Text.Length;
            string[] BinaryText = new string[length];
            for (int i = 0; i < length; i++)
                BinaryText[i] = Convert.ToString(Text[i], 2).PadLeft(8, '0');
            return BinaryText;
        }

        /// <summary>
        /// Converts a text string to a decimal number string
        /// </summary>
        /// <param name="Text"> The text string to convert</param>
        /// <returns>The decimal string</returns>
        public string TextToDecimal(string Text)
        {
            int length = Text.Length;
            string BinaryText = "";
            for (int i = 0; i < length; i++)
            {
                string temp = Convert.ToString(Text[i], 10);
                BinaryText += temp;
            }
            return BinaryText;
        }

        /// <summary>
        /// Converts a text string to a hexadecimal number string
        /// </summary>
        /// <param name="Text"> The text string to convert</param>
        /// <returns>The hexadecimal string</returns>
        public string TextToHexadecimal(string Text)
        {
            int length = Text.Length;
            string BinaryText = "";
            for (int i = 0; i < length; i++)
            {
                string temp = Convert.ToString(Text[i], 16);
                BinaryText += temp;
            }
            return BinaryText;
        }

        #endregion

        #region From Hexadecimal

        /// <summary>
        /// Converts a hexadecimal string to a text string
        /// </summary>
        /// <param name="Text"> The hexadecimal string to convert</param>
        /// <returns>The text string</returns>
        public string HexadecimalToText(string HexadecimalText)
        {
            int length = HexadecimalText.Length;
            string Text = "";
            for (int i = 0; i < length; i += 2)
                Text += (char)Convert.ToInt32(HexadecimalText.Substring(i, 2), 16); ;
            return Text;
        }

        /// <summary>
        /// Converts a hexadecimal string to a binary string
        /// </summary>
        /// <param name="Text"> The hexadecimal string to convert</param>
        /// <returns>The binary string</returns>
        public string HexadecimalToBinary(string Text)
        {
            int length = Text.Length;
            string BinaryText = "";
            for (int i = 0; i < length; i++)
            {
                BinaryText += Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 2).PadLeft(4, '0');
            }
            return BinaryText;
        }

        /// <summary>
        /// Converts a hexadecimal string to a binary string
        /// Each character is converted to a binary string left padded with zeros to be be of length 4
        /// </summary>
        /// <param name="Text"> The hexadecimal string to convert</param>
        /// <returns>The binary string</returns>
        public string[] HexadecimalToBinaryStrings(string Text)
        {
            int length = Text.Length;
            string[] BinaryText = new string[length];
            for (int i = 0; i < length; i++)
                BinaryText[i] = Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 2).PadLeft(4, '0');
            return BinaryText;
        }

        /// <summary>
        /// Converts a hexadecimal string to a decimal string
        /// </summary>
        /// <param name="Text"> The hexadecimal string to convert</param>
        /// <returns>The decimal string</returns>
        public string[] HexadecimalToDecimal(string Text)
        {
            int length = Text.Length;
            string[] DecimalText = new string[length];
            for (int i = 0; i < length; i++)
                DecimalText[i] = Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 10).PadLeft(4, '0');
            return DecimalText;
        }

        /// <summary>
        /// Converts a hexadecimal string of two hexadecimal characters to a decimal string
        /// something like "0xF3" for example
        /// </summary>
        /// <param name="Text"> The hexadecimal string to convert</param>
        /// <returns>The decimal integer</returns>
        public int HexadecimalToDecimalTwo(string Text)
        {
            return int.Parse(Convert.ToString(Convert.ToInt32(Text, 16), 10));
        }

        #endregion

        #region From Binary

        /// <summary>
        /// Converts a binary string to a text string
        /// </summary>
        /// <param name="Text"> The binary string to convert</param>
        /// <returns>The text string</returns>
        public string BinaryToText(string Text)
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
            for (int i = 0; i < returnText.Length; i++)
            {
                if (returnText[i] == '\0')
                {
                    returnText = returnText.Remove(i, 1);
                    i--;
                }
            }
            return returnText;
        }

        /// <summary>
        /// Converts a binary string to a hexadecimal string
        /// </summary>
        /// <param name="Text"> The binary string to convert</param>
        /// <returns>The hexadecimal string</returns>
        public string BinaryToHexadecimal(string Text)
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

        #endregion
    }
}