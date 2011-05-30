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
        /// <summary>
        /// Creates an object of Diffie Hellman Key Exchange.
        /// </summary>
        public DiffieHellman()
        {
            rand = new Random();
            NumberTheoryOperations = new NumberTheory();
        }
        #endregion

        #region Diffie-Hellman Calculate Shared Key
        /// <summary>
        /// Get the shared key given the private numbers.
        /// </summary>
        /// <param name="PrimeBase">The prime base.</param>
        /// <param name="PrimitiveRoot">The primitive root.</param>
        /// <param name="Xa">User #1 private key</param>
        /// <param name="Xb">User #2 private key</param>
        /// <returns>The shared key value.</returns>
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
        /// <summary>
        /// Get the shared key using random private numbers.
        /// </summary>
        /// <param name="PrimeBase">The prime base.</param>
        /// <param name="PrimitiveRoot">The primitive root.</param>
        /// <returns>The shared key value.</returns>
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
        /// <summary>
        /// Get the public key of a given private key.
        /// </summary>
        /// <param name="PrimeBase">The prime base.</param>
        /// <param name="PrimitiveRoot">The primitive root.</param>
        /// <param name="PrivateKey">The private key.</param>
        /// <returns>Returns the public key value.</returns>
        public BigInteger DiffieHellmanGetPublicKey(int PrimeBase, int PrimitiveRoot, int PrivateKey)
        {
            BigInteger Y = NumberTheoryOperations.BigPower(PrimitiveRoot, PrivateKey, PrimeBase);
            return Y;
        }
        #endregion
    }
}
