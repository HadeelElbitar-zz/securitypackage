using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SecurityPackage
{
    class EllipticCurveHelpingFunctions
    {
        public EllipticCurveHelpingFunctions() { }
        #region Elliptic Curve Helping Functions
        public Point ResidueClassMultiplyPoint(int Number, Point P, int Base, int a)
        {
            Point Result = ResidueClassAddPoints(P, P, Base, a);
            for (int i = 0; i < Number - 2; i++)
                Result = ResidueClassAddPoints(P, Result, Base, a);
            return Result;
        }
        public Point GaloisFieldMultiplyPoint(int Number, Point P, int Base, int a)
        {
            Point Result = GaloisFieldAddPoints(P, P, Base, a);
            for (int i = 0; i < Number - 2; i++)
                Result = GaloisFieldAddPoints(P, Result, Base, a);
            return Result;
        }
        public Point ResidueClassAddPoints(Point P, Point Q, int Base, int a)
        {
            NumberTheory Operations = new NumberTheory();
            Point Result = new Point();
            Point QCheck = new Point(-1 * Q.X, -1 * Q.Y);
            double LambdaDenominator, LambdaDividend;
            int Lambda, Temp;
            #region Lambda Equal Points Case
            if (P == Q || P == QCheck)
            {
                LambdaDividend = (3.0 * Math.Pow(P.X, 2)) + (double)a;
                LambdaDenominator = 2.0 * (double)P.Y;
                double MI = Operations.MultiplicativeInverse((int)LambdaDenominator, Base);
                if (MI < 0)
                    MI = Base - MI;
                Lambda = (int)LambdaDividend * (int)MI;
                if (Lambda < 0)
                {
                    Temp = -1 * Lambda;
                    Temp %= Base;
                    Lambda = Base - Temp;
                }
                else
                    Lambda %= Base;
            }
            #endregion
            #region Lambda NOT Equal Points Case
            else
            {
                LambdaDividend = Q.Y - P.Y;
                LambdaDenominator = Q.X - P.X;
                double MI = Operations.MultiplicativeInverse((int)LambdaDenominator, Base);
                if (MI < 0)
                    MI = Base - MI;
                Lambda = (int)LambdaDividend * (int)MI;
                if (Lambda < 0)
                {
                    Temp = -1 * Lambda;
                    Temp %= Base;
                    Lambda = Base - Temp;
                }
                else
                    Lambda %= Base;
            }
            #endregion
            #region Calculate X,Y
            Result.X = ((int)Math.Pow(Lambda, 2) - P.X - Q.X);
            if (Result.X < 0)
            {
                Temp = -1 * Result.X;
                Temp %= Base;
                Result.X = Base - Temp;
            }
            else
                Result.X %= Base;
            Result.Y = (Lambda * (P.X - Result.X)) - P.Y;
            if (Result.Y < 0)
            {
                Temp = -1 * Result.Y;
                Temp %= Base;
                Result.Y = Base - Temp;
            }
            else
                Result.Y %= Base;
            #endregion
            return Result;
        }
        public Point GaloisFieldAddPoints(Point P, Point Q, int Base, int a)
        {
            NumberTheory Operations = new NumberTheory();
            Point Result = new Point();
            Point QCheck = new Point(-1 * Q.X, -1 * Q.Y);
            double LambdaDenominator, LambdaDividend;
            int Lambda, Temp;
            #region Lambda Equal Points Case
            if (P == Q || P == QCheck)
            {
                LambdaDividend = Math.Pow(P.X, 2) + P.Y;
                LambdaDenominator = P.X;
                double MI = Operations.MultiplicativeInverse((int)LambdaDenominator, Base);
                if (MI < 0)
                    MI = Base - MI;
                Lambda = (int)LambdaDividend * (int)MI;
                if (Lambda < 0)
                {
                    Temp = -1 * Lambda;
                    Temp %= Base;
                    Lambda = Base - Temp;
                }
                else
                    Lambda %= Base;
                #region Calculate X,Y
                Result.X = (int)Math.Pow(Lambda, 2) + Lambda + a;
                Result.Y = (int)Math.Pow(P.X, 2) + ((Lambda + 1) * Result.X);
                #endregion
            }
            #endregion
            #region Lambda NOT Equal Points Case
            else
            {
                LambdaDividend = Q.Y + P.Y;
                LambdaDenominator = Q.X + P.X;
                double MI = Operations.MultiplicativeInverse((int)LambdaDenominator, Base);
                if (MI < 0)
                    MI = Base - MI;
                Lambda = (int)LambdaDividend * (int)MI;
                if (Lambda < 0)
                {
                    Temp = -1 * Lambda;
                    Temp %= Base;
                    Lambda = Base - Temp;
                }
                else
                    Lambda %= Base;
                #region Calculate X,Y
                Result.X = (int)Math.Pow(Lambda, 2) + Lambda + a + P.X + Q.X;
                Result.Y = (Lambda * (P.X + Result.X)) + Result.X + P.Y;
                #endregion
            }
            #endregion
            return Result;
        }
        public Point ResidueClassNegativePoint(Point P)
        {
            return new Point(P.X, -1 * P.Y);
        }
        public Point GaloisFieldNegativePoint(Point P)
        {
            return new Point(P.X, P.X + P.Y);
        }
        #endregion
    }
}
