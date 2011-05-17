using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SecurityPackage
{
    class KeyExchange
    {
        #region Variables and Constructor
        NumberTheory NumberTheoryOperations;
        Random rand;
        public KeyExchange()
        {
            rand = new Random();
            NumberTheoryOperations = new NumberTheory();
        }
        #endregion

        #region Diffie-Hellman Calculate Shared Key
        public int DiffieHellmanGetSharedKey(int PrimeBase, int PrimitiveRoot, int Xa, int Xb)
        {
            int _Xa, _Xb;
            double _Ya, _Yb, SharedKey;
            _Xa = Xa;
            _Xb = Xb;
            _Ya = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xa, PrimeBase);
            _Yb = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xb, PrimeBase);
            SharedKey = NumberTheoryOperations.BigPower((int)_Ya, _Xb, PrimeBase);
            return (int)SharedKey;
        }
        public int DiffieHellmanGetSharedKey(int PrimeBase, int PrimitiveRoot)
        {
            int _Xa, _Xb;
            double _Ya, _Yb, SharedKey;
            _Xa = rand.Next(1, PrimeBase);
            _Xb = rand.Next(1, PrimeBase);
            _Ya = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xa, PrimeBase);
            _Yb = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xb, PrimeBase);
            SharedKey = NumberTheoryOperations.BigPower((int)_Ya, _Xb, PrimeBase);
            return (int)SharedKey;
        }
        #endregion

        #region Diffie-Hellman Get Public Number
        public double DiffieHellmanGetPublicKey(int PrimeBase, int PrimitiveRoot, int PrivateKey)
        {
            double Y;
            Y = NumberTheoryOperations.BigPower(PrimitiveRoot, PrivateKey, PrimeBase);
            return Y;
        }
        #endregion

        #region Elliptic Curve Shared Key
        public Point EllipticCurveGetSharedKeyUsingResidueClass(int a, int b, int Base, Point G, int n, int PrivateKeyA, int PrivateKeyB)
        {
            Point SharedKey = new Point();
            //Point PublicA = ResidueClassMultiplyPoint(nA, G);
            Point PublicB = ResidueClassMultiplyPoint(PrivateKeyB, G);
            SharedKey = ResidueClassMultiplyPoint(PrivateKeyA, PublicB);
            return SharedKey;
        }
        public Point EllipticCurveGetSharedKeyUsingResidueClass(int a, int b, int Base, Point G, int n)
        {
            int nA = rand.Next(1, n);
            int nB = rand.Next(1, n);
            return EllipticCurveGetSharedKeyUsingResidueClass(a, b, Base, G, n, nA, nB);
        }
        public Point EllipticCurveGetSharedKeyUsingGaloisField(int a, int b, int Base, Point G, int n, int nA, int nB)
        {
            Point SharedKey = new Point();
            //Point PublicA = GaloisFieldMultiplyPoint(nA, G);
            Point PublicB = GaloisFieldMultiplyPoint(nB, G);
            SharedKey = GaloisFieldMultiplyPoint(nA, PublicB);
            return SharedKey;
        }
        public Point EllipticCurveGetSharedKeyUsingGaloisField(int a, int b, int Base, Point G, int n)
        {
            int nA = rand.Next(1, n);
            int nB = rand.Next(1, n);
            return EllipticCurveGetSharedKeyUsingGaloisField(a, b, Base, G, n, nA, nB);
        }
        #endregion

        #region Elliptic Curve Helping Functions
        Point ResidueClassMultiplyPoint(int Number, Point P)
        {
            Point Result = new Point();
            return Result;
        }
        Point GaloisFieldMultiplyPoint(int Number, Point P)
        {
            Point Result = new Point();
            return Result;
        }
        #endregion

        #region Elliptic Curve Get Public Key

        #endregion
    }
}
