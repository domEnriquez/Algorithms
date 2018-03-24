using PriorityQueues;
using System;

namespace NumberTheoryProblemA
{
    public class EquationSolution
    {
        BinaryHeapMinPQ<ExpressionOne> expOneBh;
        BinaryHeapMinPQ<ExpressionTwo> expTwoBh;

        public EquationSolution()
        {
            expOneBh = new BinaryHeapMinPQ<ExpressionOne>();
            expTwoBh = new BinaryHeapMinPQ<ExpressionTwo>();
        }

        public void FindSolution(int numLimit)
        {
            for (int i = 0; i <= numLimit; i++)
            {
                expOneBh.Insert(new ExpressionOne(i, 0));
                expTwoBh.Insert(new ExpressionTwo(i, 0));
            }

            while(!expOneBh.IsEmpty() && !expTwoBh.IsEmpty())
            {
                AbstractTwoVarExpression exp = null;
                AbstractTwoVarExpression expOneTop = expOneBh.PeekTop();
                AbstractTwoVarExpression expTwoTop = expTwoBh.PeekTop();

                if(expOneTop.CompareTo(expTwoTop) <= 0)
                {
                    if (expOneTop.CompareTo(expTwoTop) == 0)
                        showExpressions(expOneTop, expTwoTop);

                    exp = expOneBh.DeleteTop();
                    if(exp.SecVar < numLimit)
                        expOneBh.Insert(new ExpressionOne(exp.FirstVar, exp.SecVar + 1));
                } 
                else
                {
                    exp = expTwoBh.DeleteTop();
                    if (exp.SecVar < numLimit)
                        expTwoBh.Insert(new ExpressionTwo(exp.FirstVar, exp.SecVar + 1));
                }
            }
        }

        private static void showExpressions(AbstractTwoVarExpression expOneTop, AbstractTwoVarExpression expTwoTop)
        {
            Console.WriteLine(expOneTop);
            Console.WriteLine(expTwoTop);
        }
    }
}