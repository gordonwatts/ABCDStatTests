using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester.Generators
{
    /// <summary>
    /// Generate a sequence of 2D data that can be used in the ABCD metnod.
    /// </summary>
    interface IGenerator
    {
        /// <summary>
        /// Return the next data point from some randomly generated functions
        /// </summary>
        /// <returns></returns>
        IEnumerable<(double x, double y)> GetPointSequence();
    }
}
