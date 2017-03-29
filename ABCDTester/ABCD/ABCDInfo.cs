using ABCDTester.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester.ABCD
{
    /// <summary>
    /// The info from the ABCD calculation
    /// </summary>
    class ABCDInfo
    {
        /// <summary>
        /// What we determined A to be
        /// </summary>
        public NumberWithSystematic CalculatedA;

        /// <summary>
        /// What we found in each guy
        /// </summary>
        public double A, B, C, D;

        public override string ToString()
        {
            return $"(A={A}, B={B}, C={C}, D={D}, BD/C={CalculatedA})";
        }
    }
}
