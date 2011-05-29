using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class Polynomial
    {
        #region Costructor and Variables
        SortedDictionary<int, double> _Terms; //Dictionary of double Coefficients and int Powers.
        /// <summary>
        /// Create an object of Polynomial class.
        /// </summary>
        public Polynomial()
        {
            _Terms = new SortedDictionary<int, double>();
        }
        #endregion

        #region Initialization of Polynomial
        /// <summary>
        /// Initialize the terms of the polynomial
        /// </summary>
        /// <param name="Powers">integer array with the values of the powers</param>
        /// <param name="Coefficients">double array with the values of coefficients</param>
        /// <returns>returns 0 in success and -1 in fail</returns>
        public int InitializePolynomial(int[] Powers, double[] Coefficients)
        {
            if (Powers.Length != Coefficients.Length)
                return -1;
            int length = Powers.Length;
            for (int i = 0; i < length; i++)
                _Terms.Add(Powers[i], Coefficients[i]);
            return 0;
        }
        /// <summary>
        /// Initialize the terms of the polynomial
        /// </summary>
        /// <param name="Terms">Sprted Dictionary with key = power and value = coefficients</param>
        public void InitializePolynomial(SortedDictionary<int, double> Terms)
        {
            _Terms = Terms;
        }
        #endregion

        #region Multiplication
        /// <summary>
        /// Multiply two polynomials under GF(2)
        /// </summary>
        /// <param name="First">The first polynomial</param>
        /// <param name="Second">The second polynomial</param>
        /// <returns>The result of multiplication</returns>
        static public Polynomial MultiplyPolynomials(Polynomial First, Polynomial Second)
        {
            Polynomial Result = new Polynomial();
            foreach (KeyValuePair<int, double> item1 in First._Terms)
                foreach (KeyValuePair<int, double> item2 in Second._Terms)
                {
                    if (Result._Terms.ContainsKey(item1.Key + item2.Key))
                        Result._Terms.Remove(item1.Key + item2.Key);
                    else
                        Result._Terms.Add(item1.Key + item2.Key, 1);
                }
            return Result;
        }
        /// <summary>
        /// Multiply a polynomial by a number under GF(2)
        /// </summary>
        /// <param name="First">The first polynomial</param>
        /// <param name="Second">The second polynomial</param>
        /// <returns>The result of multiplication</returns>
        static public Polynomial MultiplyPolynomials(Polynomial First, int Second)
        {
            Polynomial Result = new Polynomial();
            double Temp, Value;
            foreach (KeyValuePair<int, double> item in First._Terms)
            {
                Temp = item.Value * Second;
                if (Temp < 0)
                {
                    Value = (-1 * Temp) % 2;
                    Value = 2 - Value;
                }
                else
                    Value = Temp % 2;
                Result._Terms.Add(item.Key, Value);
            }
            return Result;
        }
        #endregion

        #region Division and Modulus
        /// <summary>
        /// Divid two polymonials and get the quotient and remainder
        /// </summary>
        /// <param name="Dividend">Dividend Polynomial</param>
        /// <param name="Divisor">Divisor Polynomial</param>
        /// <param name="Quotient">Output parameter stores the quotient value</param>
        /// <param name="Remainder">Output parameter stores the remainder value</param>
        static public void DividPolynomials(Polynomial Dividend, Polynomial Divisor, ref Polynomial Quotient, ref Polynomial Remainder)
        {
            Quotient = new Polynomial();
            Remainder = Divisor;
            int NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1).Key - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1).Key;
            while (NewPower >= 0)
            {
                Quotient._Terms.Add(NewPower, 1);
                Remainder = AddPolynomials(MultiplyPolynomials(Quotient, Dividend), Divisor);
                if (Remainder._Terms.Count == 0)
                    return;
                NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1).Key - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1).Key;
            }
        }
        /// <summary>
        /// Get the modulus of two polynomials
        /// </summary>
        /// <param name="Dividend">Dividend polynomial of the operation</param>
        /// <param name="Divisor">Divisor polynomial of the operation</param>
        /// <returns>The result of the modulus operation</returns>
        static public Polynomial GetModulus(Polynomial Dividend, Polynomial Divisor)
        {
            Polynomial Quotient = new Polynomial();
            Polynomial Remainder = Divisor;
            int NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1).Key - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1).Key;
            while (NewPower >= 0)
            {
                Quotient._Terms.Add(NewPower, 1);
                Remainder = AddPolynomials(MultiplyPolynomials(Quotient, Dividend), Divisor);
                if (Remainder._Terms.Count == 0)
                    return Remainder;
                NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1).Key - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1).Key;
            }
            return Remainder;
        }
        #endregion

        #region Addition
        /// <summary>
        /// Add two polynomials
        /// </summary>
        /// <param name="First">First Polynomial</param>
        /// <param name="Second">Second Polynomial</param>
        /// <returns>The addition result</returns>
        static public Polynomial AddPolynomials(Polynomial First, Polynomial Second)
        {
            Polynomial Result = new Polynomial();
            foreach (KeyValuePair<int, double> item1 in First._Terms)
            {
                if (!Result._Terms.ContainsKey(item1.Key))
                    Result._Terms.Add(item1.Key, 1);
            }
            foreach (KeyValuePair<int, double> item2 in Second._Terms)
            {
                if (!Result._Terms.ContainsKey(item2.Key))
                    Result._Terms.Add(item2.Key, 1);
                else
                    Result._Terms.Remove(item2.Key);
            }
            return Result;
        }
        #endregion

        #region Comparing
        /// <summary>
        /// Check if two polynomials are equal
        /// </summary>
        /// <param name="First">First polynomial</param>
        /// <param name="Second">Second polynomial</param>
        /// <returns>Returns a boolian value to indicate the equality</returns>
        static public bool isEqual(Polynomial First, Polynomial Second)
        {
            if (Second._Terms.Count != First._Terms.Count)
                return false;
            int length = Second._Terms.Count;
            for (int i = 0; i < length; i++)
            {
                if (Second._Terms.ElementAt(i).Key != First._Terms.ElementAt(i).Key)
                    return false;
            }
            return true;
        }
        #endregion
    }
}
