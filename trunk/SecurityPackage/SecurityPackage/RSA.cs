using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SecurityPackage
{
    class RSA
    {
        public RSA() { }

        #region Encrypt/Decrypt
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
    }
}