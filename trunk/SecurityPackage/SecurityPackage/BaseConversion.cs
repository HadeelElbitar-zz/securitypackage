using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class BaseConversion
    {
        public BaseConversion()
        { }
        public string TextToBinary(string Text)
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
        public string[] TextToBinaryStrings(string Text)
        {
            int length = Text.Length;
            string[] BinaryText = new string[length];
            for (int i = 0; i < length; i++)
            {
                BinaryText[i] = Convert.ToString(Text[i], 2).PadLeft(8, '0');
            }
            return BinaryText;
        }
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



        public string HexadecimalToText(string HexadecimalText)
        {
            int length = HexadecimalText.Length;
            string Text = "";
            for (int i = 0; i < length; i += 2)
            {
                Text += (char)Convert.ToInt32(HexadecimalText.Substring(i, 2), 16); ;
            }
            return Text;
        }

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
        public string[] HexadecimalToBinaryStrings(string Text)
        {
            int length = Text.Length;
            string[] BinaryText = new string[length];
            for (int i = 0; i < length; i++)
            {
                BinaryText[i] = Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 2).PadLeft(4, '0');
            }
            return BinaryText;
        }
        public string[] HexadecimalToDecimal(string Text)
        {
            int length = Text.Length;
            string[] DecimalText = new string[length];
            for (int i = 0; i < length; i++)
            {
                DecimalText[i] = Convert.ToString(Convert.ToInt32(Text[i].ToString(), 16), 10).PadLeft(4, '0');
            }
            return DecimalText;
        }
        public int HexadecimalToDecimalOne(char Text)
        {
            return int.Parse(Convert.ToString(Convert.ToInt32(Text.ToString(), 16), 10));
        }

        public int HexadecimalToDecimalTwo(string Text)
        {
            return int.Parse(Convert.ToString(Convert.ToInt32(Text, 16), 10));
        }

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
            return returnText;
        }
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
    }
}
