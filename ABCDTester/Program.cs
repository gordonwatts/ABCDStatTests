using ABCDTester.ABCD;
using ABCDTester.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester
{
    class Program
    {
        // Run some simple tests
        static void Main(string[] args)
        {
            var g = new ArbitraryFunctionGenerator(r => r, r => r);

            var abcd = new ABCDBasic(0.5, 0.5);

            var rv = g.GetPointSequence()
                .Take(100000)
                .AccumulatePoints(abcd)
                .GetABCDCalculation();

            Console.WriteLine(rv);
        }
    }
}
