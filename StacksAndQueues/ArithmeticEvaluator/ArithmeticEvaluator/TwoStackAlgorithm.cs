using GenericStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticEvaluator
{
    public class TwoStackAlgorithm
    {
        public double Evaluate(string expression)
        {
            ResizingArrayStack<char> ops = new ResizingArrayStack<char>();
            ResizingArrayStack<double> vals = new ResizingArrayStack<double>();

            for(int i = 0; i < expression.Length; i++)
            {
                char currChar = expression[i];
                if (currChar == '(') ;
                else if (currChar == '+') ops.Push(expression[i]);
                else if (currChar == '*') ops.Push(expression[i]);
                else if (currChar == ')')
                {
                    char op = ops.Pop();
                    if (op == '+')
                        vals.Push(vals.Pop() + vals.Pop());
                    else if (op == '*')
                        vals.Push(vals.Pop() * vals.Pop());
                }
                else vals.Push(Char.GetNumericValue(currChar));
            }

            return vals.Pop();
        }
    }
}
