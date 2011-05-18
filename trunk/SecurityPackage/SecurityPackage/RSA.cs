﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class RSA
    {
        public RSA() { }

        #region Encrypt/Decrypt
        public string Encrypt(string PlainText, int p, int q)
        {
            int n = p * q;
            int Totient = (p - 1) * (q - 1);
            NumberTheory euclidean = new NumberTheory();
            int e = 2;
            while (true)
            {
                if (euclidean.GCD(Totient, e) == 1)
                    break;
                e++;
            }
            return euclidean.BigPower(int.Parse(PlainText), e, n).ToString();
        }
        public string Decrypt(string CipherText, int p, int q)
        {
            int n = p * q;
            int Totient = (p - 1) * (q - 1);
            NumberTheory euclidean = new NumberTheory();
            int e = 2;
            while (true)
            {
                if (euclidean.GCD(Totient, e) == 1)
                    break;
                e++;
            }
            int d = (euclidean.MultiplicativeInverse(e, Totient)) % Totient;
            return euclidean.BigPower(int.Parse(CipherText), d, n).ToString();
        } 
        #endregion
    }
}