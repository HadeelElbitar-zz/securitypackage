using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SecurityPackage
{
    class InputOutputConversion
    {
        #region Point

        /// <summary>
        /// Converts string to point
        /// For example, it converts string "(1,1)" to new Point (1,1)
        /// </summary>
        /// <param name="point">The string to convert</param>
        /// <returns>The point</returns>
        public Point StringToPoint(string point)
        {
            point = point.Replace(" ", "");
            int Index = point.IndexOf(",");
            return new Point(int.Parse(point.Substring(1, Index - 1)), int.Parse(point.Substring(Index + 1, point.Length - Index - 2)));
        }

        /// <summary>
        /// Converts point to string
        /// For example, it converts Point (1,1) to string "(1,1)"
        /// </summary>
        /// <param name="point">The point to convert</param>
        /// <returns>The string</returns>
        public string PointToString(Point point)
        {
            return ("(" + point.X + " , " + point.Y + ")");
        }

        #endregion

        #region Polynomial

        /// <summary>
        /// Converts string into polynomial data type
        /// For example, it converts string "X^2 + X + 1" to a polynomial data type
        /// The resulting polynomial must be under GF(2), so one and zero are the only valid coefficients..
        /// </summary>
        /// <param name="polynomialString">The string to convert</param>
        /// <returns>The polynomial</returns>
        public Polynomial StringToPolynomial(string polynomialString)
        {
            Polynomial polynomial = new Polynomial();
            string[] Terms = polynomialString.Split(new char[] { '+' });
            int length = Terms.Length;
            int[] Powers = new int[length];
            if (length >= 1)
            {
                int Index = Terms[0].IndexOf("^");
                string Variable = "";
                if (Index != -1)
                    Variable = Terms[0].Substring(0, Index).Trim();

                for (int i = 0; i < length; i++)
                {
                    Index = Terms[i].IndexOf("^");
                    if (Index != -1)
                        Powers[i] = int.Parse(Terms[i].Substring(Index + 1));
                    else
                    {
                        if (Terms[i].Trim() == Variable)
                            Powers[i] = 1;
                        else
                            Powers[i] = 0;
                    }

                }

                polynomial.InitializePolynomial(Variable, Powers);
            }
            return polynomial;
        }

        /// <summary>
        /// Converts polynomial data type to string
        /// For example, it converts a polynomial to string "X^2 + X + 1"
        /// The polynomial must be under GF(2), so one and zero are the only valid coefficients..
        /// </summary>
        /// <param name="polynomialString">The polynomial to convert</param>
        /// <returns>The string</returns>
        public string PolynomialToString(Polynomial polynomial)
        {
            if (polynomial == null)
                return "There is no multiplicative inverse..";
            if (polynomial._Terms.Count == 0)
                return "0";
            string polynomialString = "";
            int length = polynomial._Terms.Count;
            string Variable = polynomial.Variable;
            foreach (int item in polynomial._Terms)
            {
                if (item == 0)
                    polynomialString += " + 1";
                else if (item == 1)
                    polynomialString += (" + " + Variable);
                else
                    polynomialString += (" + " + Variable + "^" + item);
            }
            return polynomialString.Remove(0, 3);
        }

        #endregion
    }
}
