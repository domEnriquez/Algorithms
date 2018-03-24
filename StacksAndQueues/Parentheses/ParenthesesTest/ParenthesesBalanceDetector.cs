using GenericStack;
using System;
using System.Collections.Generic;

namespace ParenthesesTest
{
    public class ParenthesesBalanceDetector
    {
        Dictionary<char, char> parenthesesPair = new Dictionary<char, char>()
        {
            { ')' , '(' },
            { ']' , '[' },
            { '}' , '{' }
        };

        public bool Balanced(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
                return false;

            ResizingArrayStack<char> stack = new ResizingArrayStack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (openingParenthesis(input[i]))
                    stack.Push(input[i]);

                if (closingParenthesis(input[i]) && !hasMatchingOpeningParenthesis(input[i], stack))
                        return false;
            }

            return stack.IsEmpty();
        }
        
        private bool openingParenthesis(char c)
        {
            return parenthesesPair.ContainsValue(c);
        }

        private bool closingParenthesis(char c)
        {
            return parenthesesPair.ContainsKey(c);
        }

        private bool hasMatchingOpeningParenthesis(char openParen, ResizingArrayStack<char> stack)
        {
            return !stack.IsEmpty() && stack.Pop() == parenthesesPair[openParen];
        }


    }
}