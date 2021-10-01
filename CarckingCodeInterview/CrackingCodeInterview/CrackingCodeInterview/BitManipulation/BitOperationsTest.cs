using NUnit.Framework;

namespace CrackingCodeInterview.BitManipulation
{
    [TestFixture]
    public class BitOperationsTest
    {
        BitOperations bitOperations;

        [SetUp]
        public void SetUp()
        {
            bitOperations = new BitOperations();
        }

        [Test]
        public void canGetBit()
        {
            Assert.That(bitOperations.GetBit(2, 0), Is.EqualTo(false));
            Assert.That(bitOperations.GetBit(2, 1), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(2, 2), Is.EqualTo(false));
            Assert.That(bitOperations.GetBit(2, 3), Is.EqualTo(false));

            Assert.That(bitOperations.GetBit(3, 0), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(3, 1), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(3, 2), Is.EqualTo(false));
            Assert.That(bitOperations.GetBit(3, 3), Is.EqualTo(false));

            Assert.That(bitOperations.GetBit(4, 0), Is.EqualTo(false));
            Assert.That(bitOperations.GetBit(4, 1), Is.EqualTo(false));
            Assert.That(bitOperations.GetBit(4, 2), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(4, 3), Is.EqualTo(false));

            Assert.That(bitOperations.GetBit(15, 0), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(15, 1), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(15, 2), Is.EqualTo(true));
            Assert.That(bitOperations.GetBit(15, 3), Is.EqualTo(true));

        }

        [Test]
        public void canSetBit()
        {
            Assert.That(bitOperations.SetBit(0, 0), Is.EqualTo(1));
            Assert.That(bitOperations.SetBit(0, 1), Is.EqualTo(2));
            Assert.That(bitOperations.SetBit(0, 2), Is.EqualTo(4));
            Assert.That(bitOperations.SetBit(0, 3), Is.EqualTo(8));
        }

        [Test]
        public void canClearBit()
        {
            Assert.That(bitOperations.ClearBit(15, 0), Is.EqualTo(14));
            Assert.That(bitOperations.ClearBit(15, 1), Is.EqualTo(13));
        }

        [Test]
        public void canUpdateBit()
        {
            Assert.That(bitOperations.UpdateBit(0, 2, true), Is.EqualTo(4));
        }

    }
}
