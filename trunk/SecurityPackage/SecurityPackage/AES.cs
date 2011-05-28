using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SecurityPackage
{
    class AES
    {
        #region Variables
        List<string[,]> Keys;
        string PlainText, Key, BinaryText, HexText;
        Dictionary<string, string> BinaryHex;
        Dictionary<string, string> HexBinary;
        Dictionary<string, int> HexInt;
        #region SBox
        string[,] SBox = {{"63","7C","77","7B","F2","6B","6F","C5","30","01","67","2B","FE","D7","AB","76"},
                         {"CA","82","C9","7D","FA","59","47","F0","AD","D4","A2","AF","9C","A4","72","C0"},
                         {"B7","FD","93","26","36","3F","F7","CC","34","A5","E5","F1","71","D8","31","15"},
                         {"04","C7","23","C3","18","96","05","9A","07","12","80","E2","EB","27","B2","75"},
                         {"09","83","2C","1A","1B","6E","5A","A0","52","3B","D6","B3","29","E3","2F","84"},
                         {"53","D1","00","ED","20","FC","B1","5B","6A","CB","BE","39","4A","4C","58","CF"},
                         {"D0","EF","AA","FB","43","4D","33","85","45","F9","02","7F","50","3C","9F","A8"},
                         {"51","A3","40","8F","92","9D","38","F5","BC","B6","DA","21","10","FF","F3","D2"},
                         {"CD","0C","13","EC","5F","97","44","17","C4","A7","7E","3D","64","5D","19","73"},
                         {"60","81","4F","DC","22","2A","90","88","46","EE","B8","14","DE","5E","0B","DB"},
                         {"E0","32","3A","0A","49","06","24","5C","C2","D3","AC","62","91","95","E4","79"},
                         {"E7","C8","37","6D","8D","D5","4E","A9","6C","56","F4","EA","65","7A","AE","08"},
                         {"BA","78","25","2E","1C","A6","B4","C6","E8","DD","74","1F","4B","BD","8B","8A"},
                         {"70","3E","B5","66","48","03","F6","0E","61","35","57","B9","86","C1","1D","9E"},
                         {"E1","F8","98","11","69","D9","8E","94","9B","1E","87","E9","CE","55","28","DF"},
                         {"8C","A1","89","0D","BF","E6","42","68","41","99","2D","0F","B0","54","BB","16"},};
        #endregion
        #region Inverse SBox
        string[,] InverseSBox = {{"52","09","6A","D5","30","36","A5","38","BF","40","A3","9E","81","F3","D7","FB"},
                                 {"7C","E3","39","82","9B","2F","FF","87","34","8E","43","44","C4","DE","E9","CB"},
                                 {"54","7B","94","32","A6","C2","23","3D","EE","4C","95","0B","42","FA","C3","4E"},
                                 {"08","2E","A1","66","28","D9","24","B2","76","5B","A2","49","6D","8B","D1","25"},
                                 {"72","F8","F6","64","86","68","98","16","D4","A4","5C","CC","5D","65","B6","92"},
                                 {"6C","70","48","50","FD","ED","B9","DA","5E","15","46","57","A7","8D","9D","84"},
                                 {"90","D8","AB","00","8C","BC","D3","0A","F7","E4","58","05","B8","B3","45","06"},
                                 {"D0","2C","1E","8F","CA","3F","0F","02","C1","AF","BD","03","01","13","8A","6B"},
                                 {"3A","91","11","41","4F","67","DC","EA","97","F2","CF","CE","F0","B4","E6","73"},
                                 {"96","AC","74","22","E7","AD","35","85","E2","F9","37","E8","1C","75","DF","6E"},
                                 {"47","F1","1A","71","1D","29","C5","89","6F","B7","62","0E","AA","18","BE","1B"},
                                 {"FC","56","3E","4B","C6","D2","79","20","9A","DB","C0","FE","78","CD","5A","F4"},
                                 {"1F","DD","A8","33","88","07","C7","31","B1","12","10","59","27","80","EC","5F"},
                                 {"60","51","7F","A9","19","B5","4A","0D","2D","E5","7A","9F","93","C9","9C","EF"},
                                 {"A0","E0","3B","4D","AE","2A","F5","B0","C8","EB","BB","3C","83","53","99","61"},
                                 {"17","2B","04","7E","BA","77","D6","26","E1","69","14","63","55","21","0C","7D"},};
        #endregion
        string[] RoundConstant = { "01 00 00 00", "02 00 00 00", "04 00 00 00", "08 00 00 00", "10 00 00 00", "20 00 00 00", "40 00 00 00", "80 00 00 00", "1B 00 00 00", "36 00 00 00", };
        string[,] MixColumnsMatrix = { { "02", "03", "01", "01" }, { "01", "02", "03", "01" }, { "01", "01", "02", "03" }, { "03", "01", "01", "02" } };
        #endregion

        #region Constructors
        /// <summary>
        /// Creates an object of Advanced Encryption Standard Cipher (AES)
        /// </summary>
        public AES() { }
        #endregion

        #region Encryption
        /// <summary>
        /// Encrypt the given text using the given hexadecimal key.
        /// </summary>
        /// <param name="Text">The text to be encrypted</param>
        /// <param name="HexaKey">The hexadecimal key to be used in the encryption</param>
        /// <returns>It returns a string contains the encrypted text.</returns>
        public string Encrypt(string Text, string HexaKey)
        {
            ClearFields();
            FillDectionary();
            PlainText = Text.Replace(" ", "");
            Key = HexaKey.Replace(" ", "").ToUpper();
            if (Key.Length != 32)
                Complete(ref Key);
            //Key = "0F1571C947D9E8590CB7ADD6AF7F6798";
            BinaryText = TextToBinary(PlainText);
            HexText = BinaryTextToHex(BinaryText);
            //HexText = "0123456789ABCDEFFEDCBA9876543210";
            if (HexText.Length < 32)
                Complete(ref HexText);
            string CipherText = "", SubText;
            string[,] PlainTextMatrix, KeyMatrix, StepResults;
            KeyMatrix = ConstructMatrix(Key);
            Keys.Clear();
            Keys.Add(KeyMatrix);
            for (int i = 0; i < 10; i++)
                Keys.Add(ExpandKey(Keys[Keys.Count - 1], i));
            while (HexText.Length != 0)
            {
                if (HexText.Length < 32)
                    Complete(ref HexText);
                SubText = HexText.Substring(0, 32);
                HexText = HexText.Remove(0, 32);
                PlainTextMatrix = ConstructMatrix(SubText);
                StepResults = AddRoundKey(PlainTextMatrix, Keys[0]);
                for (int i = 0; i < 9; i++)
                {
                    SubstituteByte(ref StepResults);
                    StepResults = ShiftRows(StepResults);
                    StepResults = MixColumns(StepResults);
                    StepResults = AddRoundKey(StepResults, Keys[i + 1]);
                }
                SubstituteByte(ref StepResults);
                StepResults = ShiftRows(StepResults);
                StepResults = AddRoundKey(StepResults, Keys[10]);
                CipherText += GetTextFromMatrix(StepResults);
            }
            return CipherText;
        }
        #endregion

        #region Decryption
        /// <summary>
        /// Decrypt the given text using the given hexadecimal key.
        /// </summary>
        /// <param name="Text">The text to be decrypted</param>
        /// <param name="HexaKey">The hexadecimal key to be used in the decryption</param>
        /// <returns>It returns a string contains the decrypted text.</returns>
        public string Decrypt(string Text, string HexaKey)
        {
            ClearFields();
            FillDectionary();
            PlainText = Text.Replace(" ", "");
            Key = HexaKey.Replace(" ", "").ToUpper();
            if (Key.Length != 32)
                Complete(ref Key);
            //Key = "0F1571C947D9E8590CB7ADD6AF7F6798";
            BinaryText = TextToBinary(PlainText);
            HexText = BinaryTextToHex(BinaryText);
            //HexText = PlainText;
            //HexText = "0123456789ABCDEFFEDCBA9876543210";
            if (HexText.Length < 32)
                Complete(ref HexText);
            string PT = "", SubText, CipherText = HexText;
            //CipherText = "FF0B844A0853BF7C6934AB4364148FB9";
            string[,] CipherTextMatrix, KeyMatrix, StepResults;
            KeyMatrix = ConstructMatrix(Key);
            Keys.Clear();
            Keys.Add(KeyMatrix);
            for (int i = 0; i < 10; i++)
                Keys.Add(ExpandKey(Keys[Keys.Count - 1], i));
            while (CipherText.Length != 0)
            {
                if (CipherText.Length < 32)
                    Complete(ref HexText);
                SubText = CipherText.Substring(0, 32);
                CipherText = CipherText.Remove(0, 32);
                CipherTextMatrix = ConstructMatrix(SubText);
                StepResults = AddRoundKey(CipherTextMatrix, Keys[10]);
                for (int i = 0; i < 9; i++)
                {
                    StepResults = InverseShiftRows(StepResults);
                    InverseSubstituteByte(ref StepResults);
                    StepResults = AddRoundKey(StepResults, Keys[9 - i]);
                    StepResults = InverseMixColumns(StepResults);
                }
                StepResults = InverseShiftRows(StepResults);
                InverseSubstituteByte(ref StepResults);
                StepResults = AddRoundKey(StepResults, Keys[0]);
                PT += GetTextFromMatrix(StepResults);
            }
            return PT;
        }
        #endregion

        #region Helping Functions
        void ClearFields()
        {
            Keys = new List<string[,]>();
            BinaryHex = new Dictionary<string, string>();
            HexBinary = new Dictionary<string, string>();
            HexInt = new Dictionary<string, int>();
        }
        string[,] InverseMixColumns(string[,] Matrix)
        {
            string[,] Result = new string[4, 4];
            #region First Row
            Result[0, 0] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[0, 0]), InverseMulHex("0B", Matrix[1, 0]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[2, 0]), InverseMulHex("09", Matrix[3, 0]))));

            Result[0, 1] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[0, 1]), InverseMulHex("0B", Matrix[1, 1]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[2, 1]), InverseMulHex("09", Matrix[3, 1]))));

            Result[0, 2] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[0, 2]), InverseMulHex("0B", Matrix[1, 2]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[2, 2]), InverseMulHex("09", Matrix[3, 2]))));

            Result[0, 3] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[0, 3]), InverseMulHex("0B", Matrix[1, 3]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[2, 3]), InverseMulHex("09", Matrix[3, 3]))));
            #endregion
            #region Second Row
            Result[1, 0] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[0, 0]), InverseMulHex("0E", Matrix[1, 0]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[2, 0]), InverseMulHex("0D", Matrix[3, 0]))));

            Result[1, 1] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[0, 1]), InverseMulHex("0E", Matrix[1, 1]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[2, 1]), InverseMulHex("0D", Matrix[3, 1]))));

            Result[1, 2] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[0, 2]), InverseMulHex("0E", Matrix[1, 2]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[2, 2]), InverseMulHex("0D", Matrix[3, 2]))));

            Result[1, 3] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[0, 3]), InverseMulHex("0E", Matrix[1, 3]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[2, 3]), InverseMulHex("0D", Matrix[3, 3]))));
            #endregion
            #region Third Row
            Result[2, 0] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[0, 0]), InverseMulHex("09", Matrix[1, 0]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[2, 0]), InverseMulHex("0B", Matrix[3, 0]))));

            Result[2, 1] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[0, 1]), InverseMulHex("09", Matrix[1, 1]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[2, 1]), InverseMulHex("0B", Matrix[3, 1]))));

            Result[2, 2] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[0, 2]), InverseMulHex("09", Matrix[1, 2]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[2, 2]), InverseMulHex("0B", Matrix[3, 2]))));

            Result[2, 3] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0D", Matrix[0, 3]), InverseMulHex("09", Matrix[1, 3]))),
                           HexToBinary(BinaryXOR(InverseMulHex("0E", Matrix[2, 3]), InverseMulHex("0B", Matrix[3, 3]))));
            #endregion
            #region Fourth Row
            Result[3, 0] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[0, 0]), InverseMulHex("0D", Matrix[1, 0]))),
                           HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[2, 0]), InverseMulHex("0E", Matrix[3, 0]))));

            Result[3, 1] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[0, 1]), InverseMulHex("0D", Matrix[1, 1]))),
                           HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[2, 1]), InverseMulHex("0E", Matrix[3, 1]))));

            Result[3, 2] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[0, 2]), InverseMulHex("0D", Matrix[1, 2]))),
                           HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[2, 2]), InverseMulHex("0E", Matrix[3, 2]))));

            Result[3, 3] = BinaryXOR(HexToBinary(BinaryXOR(InverseMulHex("0B", Matrix[0, 3]), InverseMulHex("0D", Matrix[1, 3]))),
                           HexToBinary(BinaryXOR(InverseMulHex("09", Matrix[2, 3]), InverseMulHex("0E", Matrix[3, 3]))));
            #endregion
            return Result;
        }
        string[,] InverseShiftRows(string[,] Matrix)
        {
            string[,] Result = new string[4, 4];
            Result[0, 0] = Matrix[0, 0];
            Result[0, 1] = Matrix[0, 1];
            Result[0, 2] = Matrix[0, 2];
            Result[0, 3] = Matrix[0, 3];
            Result[1, 0] = Matrix[1, 3];
            Result[1, 1] = Matrix[1, 0];
            Result[1, 2] = Matrix[1, 1];
            Result[1, 3] = Matrix[1, 2];
            Result[2, 0] = Matrix[2, 2];
            Result[2, 1] = Matrix[2, 3];
            Result[2, 2] = Matrix[2, 0];
            Result[2, 3] = Matrix[2, 1];
            Result[3, 0] = Matrix[3, 1];
            Result[3, 1] = Matrix[3, 2];
            Result[3, 2] = Matrix[3, 3];
            Result[3, 3] = Matrix[3, 0];
            return Result;
        }
        void InverseSubstituteByte(ref string[,] Matrix)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Matrix[i, j] = InverseSBox[HexInt[Matrix[i, j][0].ToString()], HexInt[Matrix[i, j][1].ToString()]];
        }
        string GetTextFromMatrix(string[,] Matrix)
        {
            string Result = "";
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Result += Matrix[j, i];
            return Result;
        }
        string[,] ExpandKey(string[,] PreviousKey, int Round)
        {
            string[,] NewKey = new string[4, 4];
            string[] LastColumn = { PreviousKey[1, 3], PreviousKey[2, 3], PreviousKey[3, 3], PreviousKey[0, 3] };
            for (int i = 0; i < 4; i++)
                LastColumn[i] = SBox[HexInt[LastColumn[i][0].ToString()], HexInt[LastColumn[i][1].ToString()]];
            string[] Rconstant = RoundConstant[Round].Split(' ');
            for (int i = 0; i < 4; i++)
                NewKey[i, 0] = BinaryXOR(HexToBinary(BinaryXOR(HexToBinary(LastColumn[i]), HexToBinary(Rconstant[i]))), HexToBinary(PreviousKey[i, 0]));
            //NewKey[i, 0] = BinaryXOR(HexToBinary(LastColumn[i]), HexToBinary(Rconstant[i]));
            for (int i = 1; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    NewKey[j, i] = BinaryXOR(HexToBinary(NewKey[j, i - 1]), HexToBinary(PreviousKey[j, i]));
            return NewKey;
        }
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
                for (int j = 0; j < 4; j++)
                    Matrix[i, j] = SBox[HexInt[Matrix[i, j][0].ToString()], HexInt[Matrix[i, j][1].ToString()]];
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
            //int Size = Math.Min(X.Length, Y.Length);
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
            #region First Row
            Result[0, 0] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[0, 0]), MulHex("03", Matrix[1, 0])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[2, 0]), HexToBinary(Matrix[3, 0])))));

            Result[0, 1] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[0, 1]), MulHex("03", Matrix[1, 1])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[2, 1]), HexToBinary(Matrix[3, 1])))));

            Result[0, 2] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[0, 2]), MulHex("03", Matrix[1, 2])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[2, 2]), HexToBinary(Matrix[3, 2])))));

            Result[0, 3] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[0, 3]), MulHex("03", Matrix[1, 3])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[2, 3]), HexToBinary(Matrix[3, 3])))));
            #endregion
            #region Second Row
            Result[1, 0] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[1, 0]), MulHex("03", Matrix[2, 0])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[3, 0]), HexToBinary(Matrix[0, 0])))));

            Result[1, 1] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[1, 1]), MulHex("03", Matrix[2, 1])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[3, 1]), HexToBinary(Matrix[0, 1])))));

            Result[1, 2] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[1, 2]), MulHex("03", Matrix[2, 2])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[3, 2]), HexToBinary(Matrix[0, 2])))));

            Result[1, 3] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[1, 3]), MulHex("03", Matrix[2, 3])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[3, 3]), HexToBinary(Matrix[0, 3])))));
            #endregion
            #region Third Row
            Result[2, 0] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[2, 0]), MulHex("03", Matrix[3, 0])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 0]), HexToBinary(Matrix[0, 0])))));

            Result[2, 1] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[2, 1]), MulHex("03", Matrix[3, 1])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 1]), HexToBinary(Matrix[0, 1])))));

            Result[2, 2] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[2, 2]), MulHex("03", Matrix[3, 2])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 2]), HexToBinary(Matrix[0, 2])))));

            Result[2, 3] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[2, 3]), MulHex("03", Matrix[3, 3])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 3]), HexToBinary(Matrix[0, 3])))));
            #endregion
            #region Fourth Row
            Result[3, 0] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[3, 0]), MulHex("03", Matrix[0, 0])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 0]), HexToBinary(Matrix[2, 0])))));

            Result[3, 1] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[3, 1]), MulHex("03", Matrix[0, 1])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 1]), HexToBinary(Matrix[2, 1])))));

            Result[3, 2] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[3, 2]), MulHex("03", Matrix[0, 2])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 2]), HexToBinary(Matrix[2, 2])))));

            Result[3, 3] = BinaryXOR(HexToBinary((BinaryXOR(MulHex("02", Matrix[3, 3]), MulHex("03", Matrix[0, 3])))),
            HexToBinary((BinaryXOR(HexToBinary(Matrix[1, 3]), HexToBinary(Matrix[2, 3])))));
            #endregion
            return Result;
        }
        string MulHex(string X, string Y)
        {
            char[] Result = { '0', '0', '0', '0', '0', '0', '0', '0', '0' };
            X = HexToBinary(X); // from mix column matrix
            Y = HexToBinary(Y); // from the matrix it self
            char[] Temp = X.ToCharArray();
            Array.Reverse(Temp);
            X = new string(Temp);
            Temp = Y.ToCharArray();
            Array.Reverse(Temp);
            Y = new string(Temp);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 8; j++)
                    if (X[i] == '1' && Y[j] == '1')
                    {
                        if (Result[j + i] == '1')
                            Result[j + i] = '0';
                        else
                            Result[j + i] = '1';
                    }
            #region Mod if exist!
            if (Result[8] == '1')
            {
                //da msh sa7 lazm a2sem :S bs ha2agelo now 3ashan msh 3arfa a3melo ezaii!!
                //XOR Result with 1 0001 1011
                //char[] Irriversable = { '1', '1', '0', '1', '1', '0', '0', '0', '1' };
                string Irriversable = "110110001";
                string Res = new string(Result);
                Res = BinaryXOR(Irriversable, Res);
                Res = HexToBinary(Res);
                Result = Res.ToCharArray();
                //Array.Reverse(Temp);
                //Res = new string(Temp);
                //Result[8] = '0';
            }
            #endregion

            string MulRes = new string(Result).TrimEnd('0');
            Result = MulRes.ToCharArray();
            Array.Reverse(Result);
            MulRes = new string(Result);
            if (MulRes.Length < 8)
                MulRes = MulRes.PadLeft(8, '0');
            //MulRes = BinaryTextToHex(MulRes);
            return MulRes;
        }
        string InverseBinaryXOR(string X, string Y)
        {
            string Result = "";
            //int Size = Math.Min(X.Length, Y.Length);
            for (int i = 0; i < 11; i++)
            {
                if ((X[i] == '0' && Y[i] == '0') || (X[i] == '1' && Y[i] == '1'))
                    Result += "0";
                else
                    Result += "1";
            }
            return Result;
        }
        string InverseMulHex(string X, string Y)
        {
            char[] Result = { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' };
            X = HexToBinary(X); // from mix column matrix
            Y = HexToBinary(Y); // from the matrix it self
            char[] Temp = X.ToCharArray();
            Array.Reverse(Temp);
            X = new string(Temp);
            Temp = Y.ToCharArray();
            Array.Reverse(Temp);
            Y = new string(Temp);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                    if (X[i] == '1' && Y[j] == '1')
                    {
                        if (Result[j + i] == '1')
                            Result[j + i] = '0';
                        else
                            Result[j + i] = '1';
                    }
            #region Mod if exist!
            string MulRes;
            if (Result[10] == '1')
            {
                string Irriversable = "00110110001";
                string Res = new string(Result);
                Res = InverseBinaryXOR(Irriversable, Res);
                Result = Res.ToCharArray();
            }
            if (Result[9] == '1')
            {
                string Irriversable = "01101100010";
                string Res = new string(Result);
                Res = InverseBinaryXOR(Irriversable, Res);
                Result = Res.ToCharArray();
            }
            if (Result[8] == '1') //x^8
            {
                string Irriversable = "11011000100";
                string Res = new string(Result);
                Res = InverseBinaryXOR(Irriversable, Res);
                Result = Res.ToCharArray();
            }
            #endregion

            MulRes = new string(Result).TrimEnd('0');
            Result = MulRes.ToCharArray();
            Array.Reverse(Result);
            MulRes = new string(Result);
            if (MulRes.Length < 8)
                MulRes = MulRes.PadLeft(8, '0');
            //MulRes = BinaryTextToHex(MulRes);
            return MulRes;
        }
        #endregion
    }
}
