using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester.Generators
{
    /// <summary>
    /// Given two functions of a number between 0 and 1, generate a result.
    /// </summary>
    class ArbitraryFunctionGenerator : IGenerator
    {
        /// <summary>
        /// Generate the x Value
        /// </summary>
        private readonly Func<double, double> _xGen;

        /// <summary>
        /// Generate the yValue.
        /// </summary>
        private readonly Func<double, double> _yGen;

        /// <summary>
        /// Iniitalize with two functions
        /// </summary>
        /// <param name="xGen"></param>
        /// <param name="yGen"></param>
        public ArbitraryFunctionGenerator (Func<double, double> xGen, Func<double,double> yGen)
        {
            _xGen = xGen;
            _yGen = yGen;
        }

        /// <summary>
        /// Return a data point.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(double x, double y)> GetPointSequence()
        {
            // Initialize with a "random" seed.
            var r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            while(true)
            {
                yield return (_xGen.Invoke(r.NextDouble()), _yGen.Invoke(r.NextDouble()));
            }
        }
    }
}
