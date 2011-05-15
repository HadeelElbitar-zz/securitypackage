using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class DiffieHellman
    {
        #region Variables and Constructor
        int _PrimeBase, _PrimitiveRoot, _Xa, _Xb;
        double _Ya, _Yb, _SharedKey;
        Random rand;
        public DiffieHellman(int PrimeBase, int PrimitiveRoot)
        {
            rand = new Random();
            _PrimeBase = PrimeBase;
            _PrimitiveRoot = PrimitiveRoot;
        } 
        #endregion

        #region Calculate Shared Key
        public int GetSharedKey(int Xa , int Xb)
        {
            _Xa = Xa;
            _Xb = Xb;
            _Ya = BigPower(_PrimitiveRoot, _Xa, _PrimeBase);
            _Yb = BigPower(_PrimitiveRoot, _Xb, _PrimeBase);
            _SharedKey = BigPower((int)_Ya, _Xb, _PrimeBase);
            return (int)_SharedKey;
        }
        public int GetSharedKey()
        {
            _Xa = rand.Next(1, _PrimeBase);
            _Xb = rand.Next(1, _PrimeBase);
            _Ya = BigPower(_PrimitiveRoot, _Xa, _PrimeBase);
            _Yb = BigPower(_PrimitiveRoot, _Xb, _PrimeBase);
            _SharedKey = BigPower((int)_Ya, _Xb, _PrimeBase);
            return (int)_SharedKey;
        }
        double BigPower(int Base, int Power, int Mod)
        {
            double Result = 1.0;
            for (int i = 0; i < Power; i++)
                Result *= (Base % Mod);
            Result %= Mod;
            return Result;
        }
        #endregion

        #region Get Public Number
        int GetPublicNumber(int X)
        {
            int Y;
            Y = (int)BigPower(_PrimitiveRoot, X, _PrimeBase);
            return Y;
        }
        #endregion

        #region Get and Set
        public double Ya
        {
            get
            {
                return _Ya;
            }
        }
        public double Yb
        {
            get
            {
                return _Yb;
            }
        }
        #endregion
    }
}
