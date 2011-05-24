using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Numerics;

namespace SecurityPackage
{
    class DiffieHellman
    {
        #region Variables and Constructor
        NumberTheory NumberTheoryOperations;
        Random rand;
        public DiffieHellman()
        {
            rand = new Random();
            NumberTheoryOperations = new NumberTheory();
        }
        #endregion

        #region Diffie-Hellman Calculate Shared Key
        public BigInteger DiffieHellmanGetSharedKey(int PrimeBase, int PrimitiveRoot, int Xa, int Xb)
        {
            int _Xa, _Xb;
            BigInteger _Ya, _Yb, SharedKey;
            _Xa = Xa;
            _Xb = Xb;
            _Ya = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xa, PrimeBase);
            _Yb = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xb, PrimeBase);
            SharedKey = NumberTheoryOperations.BigPower(_Ya, _Xb, PrimeBase);
            return SharedKey;
        }
        public BigInteger DiffieHellmanGetSharedKey(int PrimeBase, int PrimitiveRoot)
        {
            int _Xa, _Xb;
            BigInteger _Ya, _Yb, SharedKey;
            _Xa = rand.Next(1, PrimeBase);
            _Xb = rand.Next(1, PrimeBase);
            _Ya = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xa, PrimeBase);
            _Yb = NumberTheoryOperations.BigPower(PrimitiveRoot, _Xb, PrimeBase);
            SharedKey = NumberTheoryOperations.BigPower((int)_Ya, _Xb, PrimeBase);
            return SharedKey;
        }
        #endregion

        #region Diffie-Hellman Get Public Number
        public BigInteger DiffieHellmanGetPublicKey(int PrimeBase, int PrimitiveRoot, int PrivateKey)
        {
            BigInteger Y = NumberTheoryOperations.BigPower(PrimitiveRoot, PrivateKey, PrimeBase);
            return Y;
        }
        #endregion
    }
}
