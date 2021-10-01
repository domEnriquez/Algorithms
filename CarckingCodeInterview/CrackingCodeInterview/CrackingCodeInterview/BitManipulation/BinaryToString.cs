using NUnit.Framework;
using System.Text;

namespace CrackingCodeInterview.BitManipulation
{
    public class BinaryToString
    {
        public string BinaryOfDecimalFraction(double num)
        {
            StringBuilder binaryString = new StringBuilder();
            binaryString.Append("0.");

            while (num > 0)
            {
                if (binaryString.Length >= 32)
                    return "ERROR";

                double r = num * 2;

                if(r >= 1)
                {
                    binaryString.Append(1);
                    num = r - 1;
                } else
                {
                    binaryString.Append(0);
                    num = r;
                }
            }

            return binaryString.ToString();
        }
    }

    [TestFixture]
    public class BinaryToStringTests
    {
        [Test]
        public void canConvertBinaryToString()
        {
            BinaryToString bToS = new BinaryToString();

            Assert.That(bToS.BinaryOfDecimalFraction(0.375), Is.EqualTo("0.011"));
            Assert.That(bToS.BinaryOfDecimalFraction(0.5), Is.EqualTo("0.1"));
            Assert.That(bToS.BinaryOfDecimalFraction(0.83), Is.EqualTo("ERROR"));

        }
    }
}
