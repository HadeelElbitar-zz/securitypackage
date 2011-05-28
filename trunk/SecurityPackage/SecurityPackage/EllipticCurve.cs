using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SecurityPackage
{
    class EllipticCurve
    {
        #region Vairables and Constructor
        Random rand;
        NumberTheory NumberTheoryOperations;
        /// <summary>
        /// Creates an object of Elliptic Curve Class.
        /// </summary>
        public EllipticCurve()
        {
            rand = new Random();
            NumberTheoryOperations = new NumberTheory();
        }
        #endregion

        #region Key Cryptosystem

        #region Elliptic Curve Shared Key
        /// <summary>
        /// Get shared key using Residue Class with given private keys.
        /// </summary>
        /// <param name="a">The Elliptic Curve Parameter</param>
        /// <param name="Base">The prime base.</param>
        /// <param name="G">A Point on the curve.</param>
        /// <param name="PrivateKeyA">User #1 Private Key</param>
        /// <param name="PrivateKeyB">User #2 Private Key</param>
        /// <returns>Returns the shared key value.</returns>
        public Point EllipticCurveGetSharedKeyUsingResidueClass(int a, int Base, Point G, int PrivateKeyA, int PrivateKeyB)
        {
            Point SharedKey = new Point();
            Point PublicB = ResidueClassMultiplyPoint(PrivateKeyB, G, Base, a);
            SharedKey = ResidueClassMultiplyPoint(PrivateKeyA, PublicB, Base, a);
            return SharedKey;
        }
        /// <summary>
        /// Get shared key using Residue Class.
        /// </summary>
        /// <param name="a">The Elliptic Curve Parameter</param>
        /// <param name="Base">The prime base.</param>
        /// <param name="G">A Point on the curve.</param>
        /// <param name="n">Number (n) known for both sides</param>
        /// <returns>Returns the shared key value.</returns>
        public Point EllipticCurveGetSharedKeyUsingResidueClass(int a, int Base, Point G, int n)
        {
            int nA = rand.Next(1, n);
            int nB = rand.Next(1, n);
            return EllipticCurveGetSharedKeyUsingResidueClass(a, Base, G, nA, nB);
        }
        public Point EllipticCurveGetSharedKeyUsingGaloisField(int a, int Base, Point G, int PrivateKeyA, int PrivateKeyB)
        {
            Point SharedKey = new Point();
            Point PublicB = GaloisFieldMultiplyPoint(PrivateKeyB, G, Base, a);
            SharedKey = GaloisFieldMultiplyPoint(PrivateKeyA, PublicB, Base, a);
            return SharedKey;
        }
        public Point EllipticCurveGetSharedKeyUsingGaloisField(int a, int Base, Point G, int n)
        {
            int nA = rand.Next(1, n);
            int nB = rand.Next(1, n);
            return EllipticCurveGetSharedKeyUsingGaloisField(a, Base, G, nA, nB);
        }
        #endregion

        #region Elliptic Curve Get Public Key
        /// <summary>
        /// Get the public key of a given private key using Galois Field rules.
        /// </summary>
        /// <param name="a">The curve parameter</param>
        /// <param name="Base">The prime base</param>
        /// <param name="G">Point on the curve</param>
        /// <param name="PrivateKey">The private key</param>
        /// <returns>Returns a point represents the public key</returns>
        public Point EllipticCurveGetPublicKeyGaloisField(int a, int Base, Point G, int PrivateKey)
        {
            return GaloisFieldMultiplyPoint(PrivateKey, G, Base, a);
        }
        /// <summary>
        /// Get the public key of a given private key using Residue Class rules.
        /// </summary>
        /// <param name="a">The curve parameter</param>
        /// <param name="Base">The prime base</param>
        /// <param name="G">Point on the curve</param>
        /// <param name="PrivateKey">The private key</param>
        /// <returns>Returns a point represents the public key</returns>
        public Point EllipticCurveGetPublicKeyResidueClass(int a, int Base, Point G, int PrivateKey)
        {
            return ResidueClassMultiplyPoint(PrivateKey, G, Base, a);
        }
        #endregion

        #endregion

        #region Encryption/Decryption

        #region Encryption
        /// <summary>
        /// Encrypts key (Point)
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="Base">The base</param>
        /// <param name="G">The curve point (G)</param>
        /// <param name="PT">The point to encrypt</param>
        /// <param name="BPublicKey">Public key of B</param>
        /// <param name="k">Random number</param>
        /// <returns>The encrypted point (Array of two points)</returns>
        public Point[] Encrypt(int a, int Base, Point G, Point PT, Point BPublicKey, int k)
        {
            Point[] CT = new Point[2];
            CT[0] = ResidueClassMultiplyPoint(k, G, Base, a);
            CT[1] = ResidueClassAddPoints(PT, ResidueClassMultiplyPoint(k, BPublicKey, Base, a), Base, a);
            return CT;
        } 
        #endregion

        #region Decryption
        /// <summary>
        /// Decrypts an array of two points
        /// </summary>
        /// <param name="a"> The curve parameter </param>
        /// <param name="Base">The base</param>
        /// <param name="CT">The array of two points to deecrypt</param>
        /// <param name="nB">n of Public Key of B</param>
        /// <returns></returns>
        public Point Decrypt(int a, int Base, Point[] CT, int nB)
        {
            Point ay7aga = ResidueClassMultiplyPoint(7, new Point(8, 3), 11, 1);
            Point Temp = ResidueClassNegativePoint(ResidueClassMultiplyPoint(nB, CT[0], Base, a));
            return ResidueClassAddPoints(CT[1], Temp, Base, a);
        } 
        #endregion

        #endregion

        #region Elliptic Curve Helping Functions
        /// <summary>
        /// Multiply to Elliptic Curve points using Residue Class rules.
        /// </summary>
        /// <param name="Number">Number to be multiplied</param>
        /// <param name="P">The point to be multiplied</param>
        /// <param name="Base">The prime base</param>
        /// <param name="a">The curve parameter</param>
        /// <returns>Returns the result point of multiplication</returns>
        Point ResidueClassMultiplyPoint(int Number, Point P, int Base, int a)
        {
            Point Result = ResidueClassAddPoints(P, P, Base, a);
            for (int i = 0; i < Number - 2; i++)
                Result = ResidueClassAddPoints(P, Result, Base, a);
            return Result;
        }
        /// <summary>
        /// Multiply to Elliptic Curve points using Galois Field rules.
        /// </summary>
        /// <param name="Number">Number to be multiplied</param>
        /// <param name="P">The point to be multiplied</param>
        /// <param name="Base">The prime base</param>
        /// <param name="a">The curve parameter</param>
        /// <returns>Returns the result point of multiplication</returns>
        Point GaloisFieldMultiplyPoint(int Number, Point P, int Base, int a)
        {
            Point Result = GaloisFieldAddPoints(P, P, Base, a);
            for (int i = 0; i < Number - 2; i++)
                Result = GaloisFieldAddPoints(P, Result, Base, a);
            return Result;
        }
        /// <summary>
        /// Adds to points using Residue Class rules.
        /// </summary>
        /// <param name="P">The first point</param>
        /// <param name="Q">The second point</param>
        /// <param name="Base">The prime base</param>
        /// <param name="a">The curve parameter</param>
        /// <returns>Returns the result point of addition</returns>
        Point ResidueClassAddPoints(Point P, Point Q, int Base, int a)
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
        /// <summary>
        /// Adds to points using Galois Field rules.
        /// </summary>
        /// <param name="P">The first point</param>
        /// <param name="Q">The second point</param>
        /// <param name="Base">The prime base</param>
        /// <param name="a">The curve parameter</param>
        /// <returns>Returns the result point of addition</returns>
        Point GaloisFieldAddPoints(Point P, Point Q, int Base, int a)
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
        /// <summary>
        /// Get the negative of a point using Residue Class rules.
        /// </summary>
        /// <param name="P">The point</param>
        /// <returns>The negative point</returns>
        Point ResidueClassNegativePoint(Point P)
        {
            return new Point(P.X, -1 * P.Y);
        }
        /// <summary>
        /// Get the negative of a point using Galois Field rules.
        /// </summary>
        /// <param name="P">The point</param>
        /// <returns>The negative point</returns>
        Point GaloisFieldNegativePoint(Point P)
        {
            return new Point(P.X, P.X + P.Y);
        }
        #endregion
    }
}