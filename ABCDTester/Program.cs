using ABCDTester.ABCD;
using ABCDTester.Generators;
using CommandLine;
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
            // Parse the command line arguments
            var argParseResult = Parser.Default.ParseArguments<Options>(args.Select(a => a.Trim()));
            Options cmdOpts = null;
            argParseResult.MapResult(
                options => {
                    cmdOpts = options;
                    return 0;
                },
                errors => {
                    foreach (var err in errors)
                    {
                        Console.WriteLine($"Error parsing command line: {err.ToString()}");
                    }
                    throw new InvalidOperationException("Command line couldn't be parsed");
                });

            // Now, build the point sequence generator
            var g = new ArbitraryFunctionGenerator(r => r, r => r);

            // Fill the ABCD plane
            var seqOfResults = Enumerable.Range(0, cmdOpts.NTrials).AsParallel()
                .Select(_ => {
                    ABCDBasic abcdAccumulator = new ABCDBasic(cmdOpts.XCut, cmdOpts.YCut);
                    return g.GetPointSequence()
                            .TakeWhile(d => cmdOpts.MinError < 0.01
                                    ? abcdAccumulator.TotalPoints < cmdOpts.NEvents
                                    : abcdAccumulator.CheckMaxError(cmdOpts.MinError))
                            .AccumulatePoints(abcdAccumulator)
                            .GetABCDCalculation();
                    }
                );

            // Dump everything out in a csv format (because everyone knows how to read that!)
            Console.WriteLine("A,B,C,D,CalcA,CalcA StdDev");
            foreach (var rv in seqOfResults)
            {
                Console.WriteLine($"{rv.A}, {rv.B}, {rv.C}, {rv.D}, {rv.CalculatedA.Number}, {rv.CalculatedA.Error}");
            }
        }

        /// <summary>
        /// command line options for the program
        /// </summary>
        class Options
        {
            [Option("NEvents", Default = 100000, HelpText = "Number of background events in the plane")]
            public int NEvents { get; set; }

            [Option("NTrials", Default = 20000, HelpText = "Number of trials to run (how many times to repeat the ABCD plane)")]
            public int NTrials { get; set; }

            [Option("XCut", Default = 0.5, HelpText = "Where to put the cut along the x-axis")]
            public double XCut { get; set; }

            [Option("YCut", Default = 0.5, HelpText = "Where to put the cut along the y-axis")]
            public double YCut { get; set; }

            [Option("MinError", Default = -1.0, HelpText = "Minimum error (fraciton) for each of A, B, C, and D - will keep the trials going until sqrt(N)")]
            public double MinError { get; set; }
        }
    }
}
