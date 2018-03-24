using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheoryProblemA
{
    public abstract class AbstractTwoVarExpression : IComparable
    {
        public AbstractTwoVarExpression(int firstVar, int secVar)
        {
            FirstVar = firstVar;
            SecVar = secVar;
            Result = EvaluateExpression();
        }
        public int FirstVar { get; set; }
        public int SecVar { get; set; }
        public int Result { get; set; }
        public abstract int EvaluateExpression();

        public int CompareTo(object obj)
        {
            AbstractTwoVarExpression other = (AbstractTwoVarExpression)obj;

            if (Result > other.Result)
                return 1;
            else if (Result < other.Result)
                return -1;
            else
                return 0;
        }
    }
}
