using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester.utils
{
    /// <summary>
    /// Represents a number with a systematic error
    /// </summary>
    class NumberWithSystematic
    {
        private readonly double _number;
        private readonly double _error;

        public double Number { get => _number; }
        public double Error { get => _error; }

        /// <summary>
        /// Initalize with a generic count
        /// </summary>
        /// <param name="num"></param>
        public NumberWithSystematic(int num)
        {
            _number = num;
            _error = Math.Sqrt(num);
        }

        /// <summary>
        /// Explicity initalize
        /// </summary>
        /// <param name="num"></param>
        /// <param name="err"></param>
        public NumberWithSystematic(double num, double err)
        {
            _number = num;
            _error = err;
        }

        /// <summary>
        /// Print out in nice form
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_number} +- {_error}";
        }

        /// <summary>
        /// Override the multiplication operator
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static NumberWithSystematic operator * (NumberWithSystematic n1, NumberWithSystematic n2)
        {
            var newNumber = n1.Number * n2.Number;

            var n1Frac = n1.Error / n1.Number;
            var n2Frac = n2.Error / n2.Number;

            var newFrac = Math.Sqrt(n1Frac * n1Frac + n2Frac * n2Frac);

            return new NumberWithSystematic(newNumber, newFrac * newNumber);
        }

        /// <summary>
        /// Override division
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static NumberWithSystematic operator /(NumberWithSystematic n1, NumberWithSystematic n2)
        {
            var newNumber = n1.Number / n2.Number;

            var n1Frac = n1.Error / n1.Number;
            var n2Frac = n2.Error / n2.Number;

            var newFrac = Math.Sqrt(n1Frac * n1Frac + n2Frac * n2Frac);

            return new NumberWithSystematic(newNumber, newFrac * newNumber);
        }
    }

    static class NumberWithSystematicUtils
    {
        /// <summary>
        /// Easily convert a number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NumberWithSystematic AsSysNum (this int number)
        {
            return new NumberWithSystematic(number);
        }
    }
}
