using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityPackage
{
    class Polynomial
    {
        #region Costructor and Variables
        public string Variable; // Polynomial Variable
        public SortedSet<int> _Terms;  //List of int Powers.
        /// <summary>
        /// Create an object of Polynomial class.
        /// </summary>
        public Polynomial()
        {
            _Terms = new SortedSet<int>();
        }
        #endregion

        #region Initialization of Polynomial
        /// <summary>
        /// Initialize the terms of the polynomial
        /// </summary>
        /// <param name="Powers">integer array with the values of the powers</param>
        public void InitializePolynomial(string _Variable, int[] Powers)
        {
            Variable = _Variable;
            int length = Powers.Length;
            for (int i = 0; i < length; i++)
                _Terms.Add(Powers[i]);
        }
        /// <summary>
        /// Initialize the terms of the polynomial
        /// </summary>
        /// <param name="Terms">Sorted Set of powers</param>
        public void InitializePolynomial(SortedSet<int> Terms)
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
            foreach (int item1 in First._Terms)
                foreach (int item2 in Second._Terms)
                {
                    if (Result._Terms.Contains(item1 + item2))
                        Result._Terms.Remove(item1 + item2);
                    else
                        Result._Terms.Add(item1 + item2);
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
            double Temp = Second, Value;
            foreach (int item in First._Terms)
            {
                if (Temp < 0)
                {
                    Value = (-1 * Temp) % 2;
                    Value = 2 - Value;
                }
                else
                    Value = Temp % 2;
                if (Value != 0)
                    Result._Terms.Add(item);
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
            int NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1) - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1);
            while (NewPower >= 0)
            {
                Quotient._Terms.Add(NewPower);
                Remainder = AddPolynomials(MultiplyPolynomials(Quotient, Dividend), Divisor);
                if (Remainder._Terms.Count == 0)
                    return;
                NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1) - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1);
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
            int NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1) - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1);
            while (NewPower >= 0)
            {
                Quotient._Terms.Add(NewPower);
                Remainder = AddPolynomials(MultiplyPolynomials(Quotient, Dividend), Divisor);
                if (Remainder._Terms.Count == 0)
                    return Remainder;
                NewPower = Remainder._Terms.ElementAt(Remainder._Terms.Count - 1) - Dividend._Terms.ElementAt(Dividend._Terms.Count - 1);
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
            foreach (int item1 in First._Terms)
            {
                if (!Result._Terms.Contains(item1))
                    Result._Terms.Add(item1);
            }
            foreach (int item2 in Second._Terms)
            {
                if (!Result._Terms.Contains(item2))
                    Result._Terms.Add(item2);
                else
                    Result._Terms.Remove(item2);
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
                if (Second._Terms.ElementAt(i) != First._Terms.ElementAt(i))
                    return false;
            }
            return true;
        }
        #endregion
    }
}
