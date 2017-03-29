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

            var seqOfResults = Enumerable.Range(0, 1000)
                .Select(_ => g.GetPointSequence()
                .Take(100000)
                .AccumulatePoints(new ABCDBasic(0.5, 0.5))
                .GetABCDCalculation());

            foreach (var rv in seqOfResults)
            {
                Console.WriteLine($"{rv.A}, {rv.B}, {rv.C}, {rv.D}, {rv.CalculatedA}");
            }
        }
    }
}
