using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParenthesesTest
{
    [TestFixture]
    public class ParenthesesTest
    {
        ParenthesesBalanceDetector pbd;

        [SetUp]
        public void givenAParenthesesBalanceDetector()
        {
            pbd = new ParenthesesBalanceDetector();
        }

        [Test]
        public void whenInputIsEmpty_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced(string.Empty));
        }

        [Test]
        public void whenInputIsNull_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced(null));
        }

        [Test]
        public void whenOpeningParenthesisOnly_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced("("), "parenthesis");
            Assert.IsFalse(pbd.Balanced("["), "brackets");
            Assert.IsFalse(pbd.Balanced("{"), "braces");
        }

        [Test]
        public void whenParenthesisPair_thenReturnTrue()
        {
            Assert.IsTrue(pbd.Balanced("()"), "parenthesis");
            Assert.IsTrue(pbd.Balanced("[]"), "brackets");
            Assert.IsTrue(pbd.Balanced("{}"), "braces");
        }

        [Test]
        public void whenTwoOpeningParenthesesOnly_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced("(("), "parentheses");
            Assert.IsFalse(pbd.Balanced("[["), "brackets");
            Assert.IsFalse(pbd.Balanced("{{"), "braces");
        }

        [Test]
        public void whenTwoClosingParenthesesOnly_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced("))"), "parentheses");
            Assert.IsFalse(pbd.Balanced("]]"), "brackets");
            Assert.IsFalse(pbd.Balanced("}}"), "braces");
        }

        [Test]
        public void whenClosingFirstBeforeOpeningParentheses_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced(")("), "parentheses");
            Assert.IsFalse(pbd.Balanced("]["), "brackets");
            Assert.IsFalse(pbd.Balanced("}{"), "brackets");
        }

        [Test]
        public void whenConsecutiveParenthesesPairs_thenReturnTrue()
        {
            Assert.IsTrue(pbd.Balanced("()()"), "parentheses");
            Assert.IsTrue(pbd.Balanced("[][]"), "brackets");
            Assert.IsTrue(pbd.Balanced("{}{}"), "braces");
        }

        [Test]
        public void whenMismatchConsecutiveParenthesesPairs_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced("()("), "parentheses");
            Assert.IsFalse(pbd.Balanced("[]["), "brackets");
            Assert.IsFalse(pbd.Balanced("{}{"), "braces");
        }

        [Test]
        public void whenMismatchInnerAndOuterParenthesesPairs_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced("((())"), "parentheses");
            Assert.IsFalse(pbd.Balanced("[[[]]"), "brackets");
            Assert.IsFalse(pbd.Balanced("{{{}}"), "braces");
        }

        [Test]
        public void whenMatchingInnerAndOuterParenthesesPairs_thenReturnTrue()
        {
            Assert.IsTrue(pbd.Balanced("(())"), "parentheses");
            Assert.IsTrue(pbd.Balanced("[[]]"), "brackets");
            Assert.IsTrue(pbd.Balanced("{{}}"), "braces");
        }

        [Test]
        public void whenInnerConsecutiveParenthesesPairs_thenReturnTrue()
        {
            Assert.IsTrue(pbd.Balanced("((()()()))"), "parentheses");
            Assert.IsTrue(pbd.Balanced("[[[][]]]"), "brackets");
            Assert.IsTrue(pbd.Balanced("{{{}{}}}"), "braces");
        }

        [Test]
        public void whenMismatchInnerConsecutiveParenthesesPairs_thenReturnFalse()
        {
            Assert.IsFalse(pbd.Balanced("((()(()))"), "parentheses");
            Assert.IsFalse(pbd.Balanced("[[[][[]]]"), "brackets");
            Assert.IsFalse(pbd.Balanced("{{{}{{}}}"), "braces");
        }

        [Test]
        public void whenParenthesisPairsWithSpaces_thenReturnTrue()
        {
            Assert.IsTrue(pbd.Balanced(" (   )  "), "parentheses");
            Assert.IsTrue(pbd.Balanced(" [   ]  "), "brackets");
            Assert.IsTrue(pbd.Balanced(" {   }  "), "braces");
        }

        [Test]
        public void integration()
        {
            Assert.IsTrue(pbd.Balanced("()[()]([]){()}[{}][]{}"));
            Assert.IsFalse(pbd.Balanced("(][)}{"));
        }
    }
}
