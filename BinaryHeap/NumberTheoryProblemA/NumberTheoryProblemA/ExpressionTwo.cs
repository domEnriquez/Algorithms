using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheoryProblemA
{
    public class ExpressionTwo : AbstractTwoVarExpression
    {
        public ExpressionTwo(int firstVar, int secVar) : base(firstVar, secVar)
        {
        }

        public override int EvaluateExpression()
        {
            return (3 * (CubeOf(FirstVar))) + (4 * (FourthPowerOf(SecVar)));
        }

        private int FourthPowerOf(int num)
        {
            return num * num * num * num;
        }

        private int CubeOf(int num)
        {
            return num * num * num;
        }

        public override string ToString()
        {
            return string.Format("{0} = 3({1}^3) + 4({2}^4)", Result, FirstVar, SecVar);
        }
    }
}
