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
        /// <summary>
        /// Creates an object of Number Theory Class.
        /// </summary>
        public NumberTheory() { }
        #endregion

        #region Calculate Big Powers
        /// <summary>
        /// Calculates (Base^Power) % Mod equation.
        /// </summary>
        /// <param name="Base">The Base value.</param>
        /// <param name="Power">The Power value.</param>
        /// <param name="Mod">The Modulus value</param>
        /// <returns>Returns the result of the equation (Base^Power) % Mod</returns>
        public BigInteger BigPower(BigInteger Base, BigInteger Power, BigInteger Mod)
        {
            return BigInteger.ModPow(Base, Power, Mod);
        }
        /// <summary>
        /// Calculates (Base^Power) equation for numbers that doesn't fit in long datatype.
        /// </summary>
        /// <param name="Base">The Base value.</param>
        /// <param name="Power">The Power value.</param>
        /// <returns>Returns the result of the equation (Base^Power)</returns>
        public BigInteger BigPower(BigInteger Base, int Power)
        {
            return BigInteger.Pow(Base, Power);
        }
        #endregion

        #region Number "N" Multiplicative Inverse under Base "B"
        /// <summary>
        /// Get the Multiplicative Inverse of a number under specific base using Euclid's Algorithm
        /// </summary>
        /// <param name="Number">Number to find MI for</param>
        /// <param name="Base">The base of the operation.</param>
        /// <returns>Returns and integer representes the MI of the number in the base.</returns>
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
        /// <summary>
        /// Get the Multiplicative Inverse of a number under specific base using Euclid's Algorithm
        /// </summary>
        /// <param name="Number">Number to find MI for</param>
        /// <param name="Base">The base of the operation.</param>
        /// <returns>Returns and integer representes the MI of the number in the base.</returns>
        public BigInteger MultiplicativeInverse(BigInteger Number, BigInteger Base)
        {
            BigInteger MI = -1;
            List<BigInteger[]> Table = new List<BigInteger[]>(); //Q A1 A2 A3 B1 B2 B3
            BigInteger[] Row = new BigInteger[7];
            BigInteger[] TempRow;
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
                TempRow = new BigInteger[7];
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
        /// <summary>
        /// Calculates the greatest common divisor of two numbers
        /// </summary>
        /// <param name="n">The first number</param>
        /// <param name="m">The second number</param>
        /// <returns>The greatest common divisor</returns>
        public int GCD(int n, int m)
        {
            if (m == 0)
                return n;
            return GCD(m, n % m);
        }
        #endregion
    }
}