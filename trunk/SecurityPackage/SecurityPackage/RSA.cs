using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SecurityPackage
{
    class RSA
    {
        #region Constructor
        /// <summary>
        /// Makes a new instance of RSA class
        /// </summary>
        public RSA() { }
        #endregion

        #region Encryption/Decryption

        #region Encryption

        /// <summary>
        /// Encrypts a plaintext (integer) according to the RSA algorithm
        /// </summary>
        /// <param name="PlainText"> The number to encrypt </param>
        /// <param name="pText"> p: first prime number</param>
        /// <param name="qText">q: second prime number</param>
        /// <param name="eText">e: a number whose GCD with totient of (pxq) = 1</param>
        /// <returns>The encrypted number</returns>
        public string Encrypt(string PlainText, string pText, string qText, string eText)
        {
            BigInteger p = BigInteger.Parse(pText);
            BigInteger q = BigInteger.Parse(qText);
            BigInteger e = BigInteger.Parse(eText);
            BigInteger n = p * q;
            BigInteger Totient = (p - 1) * (q - 1);
            NumberTheory euclidean = new NumberTheory();
            return euclidean.BigPower(BigInteger.Parse(PlainText), e, n).ToString();
        }

        #endregion

        #region Decryption
        /// <summary>
        /// Decrypts a plaintext (integer) according to the RSA algorithm
        /// </summary>
        /// <param name="PlainText"> The number to decrypt </param>
        /// <param name="pText"> p: first prime number</param>
        /// <param name="qText">q: second prime number</param>
        /// <param name="eText">e: a number whose GCD with totient of (pxq) = 1</param>
        /// <returns>The decrypted number</returns>
        public string Decrypt(string CipherText, string pText, string qText, string eText)
        {
            BigInteger p = BigInteger.Parse(pText);
            BigInteger q = BigInteger.Parse(qText);
            BigInteger e = BigInteger.Parse(eText);
            BigInteger n = p * q;
            BigInteger Totient = (p - 1) * (q - 1);
            NumberTheory euclidean = new NumberTheory();
            BigInteger d = (euclidean.MultiplicativeInverse(e, Totient)) % Totient;
            return euclidean.BigPower(BigInteger.Parse(CipherText), d, n).ToString();
        }
        #endregion

        #endregion
    }
}