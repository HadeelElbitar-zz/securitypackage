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
        EllipticCurveHelpingFunctions EllipticFunctions;
        Random rand;
        public KeyExchange()
        {
            rand = new Random();
            NumberTheoryOperations = new NumberTheory();
            EllipticFunctions = new EllipticCurveHelpingFunctions();
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
        public Point EllipticCurveGetSharedKeyUsingResidueClass(int a, int Base, Point G, int PrivateKeyA, int PrivateKeyB)
        {
            Point SharedKey = new Point();
            Point PublicB = EllipticFunctions.ResidueClassMultiplyPoint(PrivateKeyB, G, Base, a);
            SharedKey = EllipticFunctions.ResidueClassMultiplyPoint(PrivateKeyA, PublicB, Base, a);
            return SharedKey;
        }
        public Point EllipticCurveGetSharedKeyUsingResidueClass(int a, int Base, Point G, int n)
        {
            int nA = rand.Next(1, n);
            int nB = rand.Next(1, n);
            return EllipticCurveGetSharedKeyUsingResidueClass(a, Base, G, nA, nB);
        }
        public Point EllipticCurveGetSharedKeyUsingGaloisField(int a, int Base, Point G, int PrivateKeyA, int PrivateKeyB)
        {
            Point SharedKey = new Point();
            Point PublicB = EllipticFunctions.GaloisFieldMultiplyPoint(PrivateKeyB, G, Base, a);
            SharedKey = EllipticFunctions.GaloisFieldMultiplyPoint(PrivateKeyA, PublicB, Base, a);
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
        public Point EllipticCurveGetPublicKeyGaloisField(int a, int Base, Point G, int PrivateKey)
        {
            return EllipticFunctions.GaloisFieldMultiplyPoint(PrivateKey, G, Base, a);
        }
        public Point EllipticCurveGetPublicKeyResidueClass(int a, int Base, Point G, int PrivateKey)
        {
            return EllipticFunctions.ResidueClassMultiplyPoint(PrivateKey, G, Base, a);
        }
        #endregion
    }
}
