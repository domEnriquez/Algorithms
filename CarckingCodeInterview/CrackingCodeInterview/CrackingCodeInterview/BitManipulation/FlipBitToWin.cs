using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.BitManipulation
{
    public class FlipBitToWin
    {
        public int FlipBit(int num)
        {
            string binary = Convert.ToString(num, 2);
            List<int> ones = new List<int>();
            int numOf1s = 0;


            for(int i = 0; i <= binary.Length; i++)
            {

                if(i == binary.Length || binary[i] == '0')
                {
                    ones.Add(numOf1s);
                    numOf1s = 0;
                } else
                {
                    numOf1s++;
                }
            }

            int largest = 0;
            for(int i = 0; i < ones.Count - 1; i++)
            {
                int total = ones[i] + ones[i + 1] + 1;

                if (total > largest)
                    largest = total;
            }

            return largest;
        }

    }

    [TestFixture]
    public class FlipBitToWinTest
    {
        //[Test]
        //public void canFlipBit()
        //{
        //    FlipBitToWin fb = new FlipBitToWin();

        //    Assert.That(fb.FlipBit(5), Is.EqualTo(3));
        //    Assert.That(fb.FlipBit(1775), Is.EqualTo(8));
        //    Assert.That(fb.FlipBit(128495), Is.EqualTo(9));
        //}
    }
}
