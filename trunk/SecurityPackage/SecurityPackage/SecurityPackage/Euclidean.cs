using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class Euclidean
    {
        public Euclidean() { }
        #region Number "N" Multiplicative Inverse under Base "B"
        int MultiplicativeInverse(int Number, int Base)
        {
            int MI = 0;
            List<int[]> Table = new List<int[]>(); //Q A1 A2 A3 B1 B2 B3
            int[] Row = new int[7];
            int[] TempRow = new int[7];
            Row[1] = 1;
            Row[2] = 0;
            Row[3] = Base;
            Row[4] = 0;
            Row[5] = 1;
            Row[6] = Number;
            Table.Add(Row);
            return MI;
        }
        #endregion
    }
}
