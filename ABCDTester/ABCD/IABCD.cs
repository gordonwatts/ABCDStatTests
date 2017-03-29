using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester.ABCD
{
    /// <summary>
    /// Implement an ABCD method
    /// </summary>
    interface IABCD
    {
        /// <summary>
        /// Automatically accumulate points
        /// </summary>
        /// <param name="pointSequence"></param>
        void AccumulatePoints(IEnumerable<(double x, double y)> pointSequence);
    }

    static class IABCDHelpers
    {
        /// <summary>
        /// Helper function to make it easy to accumulate points.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pointSequence"></param>
        /// <param name="accumulator"></param>
        /// <returns></returns>
        public static T AccumulatePoints<T>(this IEnumerable<(double x, double y)> pointSequence, T accumulator)
            where T : IABCD
        {
            accumulator.AccumulatePoints(pointSequence);
            return accumulator;
        }
    }
}
