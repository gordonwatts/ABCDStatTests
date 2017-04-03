using ABCDTester.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCDTester.ABCD
{
    /// <summary>
    /// Implement a basic ABCD method.
    /// =========
    /// | A | B |
    /// =========
    /// | C | D |
    /// =========
    /// Where the lower left hand corner is (0,0) and the upper right hand corner is (1,1)
    /// </summary>
    class ABCDBasic : IABCD
    {
        /// <summary>
        /// Hold onto the xCut.
        /// </summary>
        private readonly double _xCut;

        /// <summary>
        /// Hold onto the yCut.
        /// </summary>
        private readonly double _yCut;

        /// <summary>
        /// Initialize the ABCD cut.
        /// </summary>
        /// <param name="xCut"></param>
        /// <param name="yCut"></param>
        public ABCDBasic(double xCut, double yCut)
        {
            _xCut = xCut;
            _yCut = yCut;
        }

        /// <summary>
        /// Return the total number of points we've accumulated
        /// </summary>
        public int TotalPoints => _A + _B + _C + _D;

        /// <summary>
        /// The 4 regions
        /// </summary>
        private int _A = 0, _B = 0, _C = 0, _D = 0;

        /// <summary>
        /// Accumulate the points
        /// </summary>
        /// <param name="pointSequence"></param>
        public void AccumulatePoints (IEnumerable<(double x, double y)> pointSequence)
        {
            foreach (var p in pointSequence)
            {
                AccumlatePoint(p);
            }
        }

        /// <summary>
        /// Accumulate the point into the proper region.
        /// </summary>
        /// <param name="p"></param>
        private void AccumlatePoint((double x, double y) p)
        {
            if (p.x > _xCut)
            {
                if (p.y > _yCut)
                {
                    _B++;
                } else
                {
                    _D++;
                }
            } else
            {
                if (p.y> _yCut)
                {
                    _A++;
                } else
                {
                    _C++;
                }
            }
        }

        /// <summary>
        /// Return true if anyone's error is larger than the given error. Do it as error squared in order
        /// to make it efficient.
        /// </summary>
        /// <param name="error2"></param>
        /// <returns></returns>
        public bool CheckMaxError (double error2)
        {
            return 1.0/_A > error2
                || 1.0 / _B > error2
                || 1.0 / _C > error2
                || 1.0 / _D > error2;
        }

        /// <summary>
        /// Calculate all needed info for the ABCD method and return it.
        /// </summary>
        /// <returns></returns>
        public ABCDInfo GetABCDCalculation()
        {
            return new ABCDInfo()
            {
                A = _A,
                B = _B,
                C = _C,
                D = _D,
                CalculatedA = _B.AsSysNum() * _C.AsSysNum() / _D.AsSysNum()
            };
        }
    }
}
