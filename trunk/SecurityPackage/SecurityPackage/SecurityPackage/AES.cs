using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class AES
    {
        #region Variables
        string PlainText, Key, BinaryText, HexText;
        Dictionary<string, string> BinaryHex = new Dictionary<string, string>();
        Dictionary<string, string> HexBinary = new Dictionary<string, string>();
        Dictionary<string, int> HexInt = new Dictionary<string, int>();
        string[,] SBox = {{"63","7C","77","7B","F2","6B","6F","C5","30","01","67","2B","FE","D7","AB","76"},
                         {"CA","82","C9","7D","FA","59","47","F0","AD","D4","A2","AF","9C","A4","72","C0"},
                         {"B7","FD","93","26","36","3F","F7","CC","34","A5","E5","F1","71","D8","31","15"},
                         {"04","C7","23","C3","18","96","05","9A","07","12","80","E2","EB","27","B2","75"},
                         {"09","83","2C","1A","1B","6E","5A","A0","52","3B","D6","B3","29","E3","2F","84"},
                         {"53","D1","00","ED","20","FC","B1","5B","6A","CB","BE","39","4A","4C","58","CF"},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},
                         {"","","","","","","","","","","","","","","",""},};

        string[,] InverseSBox = {{"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},
                                 {"","","","","","","","","","","","","","","",""},};

        string[,] MixColumnsMatrix = { { "02", "03", "01", "01" }, { "01", "02", "03", "01" }, { "01", "01", "02", "03" }, { "03", "01", "01", "02" } };
        #endregion
        public AES(string Text, string HexaKey)
        {
            FillDectionary();
            PlainText = Text.Replace(" ", "");
            Key = HexaKey.Replace(" ", "").ToUpper();
            if (Key.Length != 32)
                Complete(ref Key);
            BinaryText = TextToBinary(PlainText);
            HexText = BinaryTextToHex(BinaryText);
            if (HexText.Length < 32)
                Complete(ref HexText);
        }

        #region Encryption
        public string Encrypt()
        {
            string CipherText = "", SubText;
            string[,] PlainTextMatrix, KeyMatrix, StepResults;
            KeyMatrix = ConstructMatrix(Key);
            while (HexText.Length != 0)
            {
                SubText = HexText.Substring(0, 32);
                HexText = HexText.Remove(0, 32);
                PlainTextMatrix = ConstructMatrix(SubText);
                StepResults = AddRoundKey(PlainTextMatrix, KeyMatrix);
                for (int i = 0; i < 9; i++)
                {
                    SubstituteByte(ref StepResults);
                    StepResults = ShiftRows(StepResults);
                    StepResults = MixColumns(StepResults);
                }

            }
            return CipherText;
        }
        #endregion

        #region Helping Functions
        string[,] ShiftRows(string[,] Matrix)
        {
            string[,] Result = new string[4, 4];
            Result[0, 0] = Matrix[0, 0];
            Result[0, 1] = Matrix[0, 1];
            Result[0, 2] = Matrix[0, 2];
            Result[0, 3] = Matrix[0, 3];
            Result[1, 0] = Matrix[1, 1];
            Result[1, 1] = Matrix[1, 2];
            Result[1, 2] = Matrix[1, 3];
            Result[1, 3] = Matrix[1, 0];
            Result[2, 0] = Matrix[2, 2];
            Result[2, 1] = Matrix[2, 3];
            Result[2, 2] = Matrix[2, 0];
            Result[2, 3] = Matrix[2, 1];
            Result[3, 0] = Matrix[3, 3];
            Result[3, 1] = Matrix[3, 0];
            Result[3, 2] = Matrix[3, 1];
            Result[3, 3] = Matrix[3, 2];
            return Result;
        }
        void SubstituteByte(ref string[,] Matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Matrix[i, j] = SBox[HexInt[Matrix[i, j][0].ToString()], HexInt[Matrix[i, j][1].ToString()]];
                }
            }
        }
        string[,] AddRoundKey(string[,] Text, string[,] Key)
        {
            string[,] Result = new string[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Result[i, j] = BinaryXOR(HexToBinary(Text[i, j]), HexToBinary(Key[i, j]));
            return Result;
        }
        string[,] ConstructMatrix(string Text)
        {
            string[,] Matrix = new string[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Matrix[j, i] = Text.Substring(0, 2);
                    Text = Text.Remove(0, 2);
                }
            return Matrix;
        }
        void FillDectionary()
        {
            BinaryHex.Add("0000", "0");
            BinaryHex.Add("0001", "1");
            BinaryHex.Add("0010", "2");
            BinaryHex.Add("0011", "3");
            BinaryHex.Add("0100", "4");
            BinaryHex.Add("0101", "5");
            BinaryHex.Add("0110", "6");
            BinaryHex.Add("0111", "7");
            BinaryHex.Add("1000", "8");
            BinaryHex.Add("1001", "9");
            BinaryHex.Add("1010", "A");
            BinaryHex.Add("1011", "B");
            BinaryHex.Add("1100", "C");
            BinaryHex.Add("1101", "D");
            BinaryHex.Add("1110", "E");
            BinaryHex.Add("1111", "F");

            HexBinary.Add("0", "0000");
            HexBinary.Add("1", "0001");
            HexBinary.Add("2", "0010");
            HexBinary.Add("3", "0011");
            HexBinary.Add("4", "0100");
            HexBinary.Add("5", "0101");
            HexBinary.Add("6", "0110");
            HexBinary.Add("7", "0111");
            HexBinary.Add("8", "1000");
            HexBinary.Add("9", "1001");
            HexBinary.Add("A", "1010");
            HexBinary.Add("B", "1011");
            HexBinary.Add("C", "1100");
            HexBinary.Add("D", "1101");
            HexBinary.Add("E", "1110");
            HexBinary.Add("F", "1111");

            HexInt.Add("0", 0);
            HexInt.Add("1", 1);
            HexInt.Add("2", 2);
            HexInt.Add("3", 3);
            HexInt.Add("4", 4);
            HexInt.Add("5", 5);
            HexInt.Add("6", 6);
            HexInt.Add("7", 7);
            HexInt.Add("8", 8);
            HexInt.Add("9", 9);
            HexInt.Add("A", 10);
            HexInt.Add("B", 11);
            HexInt.Add("C", 12);
            HexInt.Add("D", 13);
            HexInt.Add("E", 14);
            HexInt.Add("F", 15);
        }
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
        string BinaryTextToHex(string Text)
        {
            string Hex = "";
            int y = Text.Length;
            while (Text.Length != 0)
            {
                string Temp = Text.Substring(0, 4);
                Text = Text.Remove(0, 4);
                Hex += BinaryHex[Temp];
            }
            y = Hex.Length;
            return Hex;
        }
        void Complete(ref string Text)
        {
            Text = Text.PadLeft(32, '0');
        }
        string HexToBinary(string Text)
        {
            return HexBinary[Text[0].ToString()] + HexBinary[Text[1].ToString()];
        }
        string BinaryXOR(string X, string Y)
        {
            string Result = "";
            for (int i = 0; i < 8; i++)
            {
                if ((X[i] == '0' && Y[i] == '0') || (X[i] == '1' && Y[i] == '1'))
                    Result += "0";
                else
                    Result += "1";
            }
            Result = BinaryTextToHex(Result);
            return Result;
        }
        string[,] MixColumns(string[,] Matrix)
        {
            string[,] Result = new string[4, 4];

            return Result;
        }
        #endregion
    }
}
