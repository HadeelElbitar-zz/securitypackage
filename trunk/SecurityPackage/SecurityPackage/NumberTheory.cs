using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SecurityPackage
{
    class NumberTheory
    {
        #region Constructor
        public NumberTheory() { }
        #endregion

        #region Calculate Big Powers
        public BigInteger BigPower(BigInteger Base, BigInteger Power, BigInteger Mod)
        {
            return BigInteger.ModPow(Base, Power, Mod);
        }
        public BigInteger BigPower(BigInteger Base, int Power)
        {
            return BigInteger.Pow(Base, Power);
        }
        #endregion

        #region Number "N" Multiplicative Inverse under Base "B"
        public int MultiplicativeInverse(int Number, int Base)
        {
            int MI = int.MinValue;
            List<int[]> Table = new List<int[]>(); //Q A1 A2 A3 B1 B2 B3
            int[] Row = new int[7];
            int[] TempRow;
            Row[1] = 1;
            Row[2] = 0;
            Row[3] = Base;
            Row[4] = 0;
            Row[5] = 1;
            Row[6] = Number;
            Table.Add(Row);
            while (Table[Table.Count - 1][6] != 1 && Table[Table.Count - 1][6] != 0)
            {
                int index = Table.Count - 1;
                TempRow = new int[7];
                TempRow[0] = Table[index][3] / Table[index][6];
                TempRow[6] = Table[index][3] % Table[index][6];
                TempRow[1] = Table[index][4];
                TempRow[2] = Table[index][5];
                TempRow[3] = Table[index][6];
                TempRow[4] = Table[index][1] - (TempRow[0] * Table[index][4]);
                TempRow[5] = Table[index][2] - (TempRow[0] * Table[index][5]);
                Table.Add(TempRow);
            }
            if (Table[Table.Count - 1][6] == 1)
            {
                MI = Table[Table.Count - 1][5];
                if (MI < 0)
                    MI = Base - ((MI * -1) % Base);
            }
            return MI;
        }
        #endregion

        #region Greatest Common Divisor (GCD)
        public int GCD(int n, int m)
        {
            if (m == 0)
                return n;
            return GCD(m, n % m);
        }
        #endregion
    }
}
