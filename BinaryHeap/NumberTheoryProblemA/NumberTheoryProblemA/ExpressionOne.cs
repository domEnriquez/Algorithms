using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheoryProblemA
{
    public class ExpressionOne : AbstractTwoVarExpression
    {
        public ExpressionOne(int firstVar, int secVar) : base(firstVar, secVar)
        {
        }

        public override int EvaluateExpression()
        {
            return FirstVar + (2 * (SecVar * SecVar));
        }

        public override string ToString()
        {
            return string.Format("{0} = {1} + 2({2}^2)", Result, FirstVar, SecVar);
        }
    }
}
