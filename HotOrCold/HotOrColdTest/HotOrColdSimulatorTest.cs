using HotOrCold;
using NUnit.Framework;

namespace HotOrColdTest
{
    [TestFixture]
    class HotOrColdSimulatorTest
    {
        private const int setSize = 50;
        private const int secretNumber = 6;

        [Test]
        public void simulateFindingSecretNumber()
        {
            GameSimulator gs = new GameSimulator(setSize, secretNumber);
            gs.FindSecretNumber();
            Assert.IsTrue(gs.Game.SecretNumberFound());
            Assert.AreEqual("Number found after 14 guess/es", gs.Game.ShowStatus());
        }

        [Test]
        public void simulateImprovedFindingSecretNumber()
        {
            GameSimulator gs = new GameSimulator(setSize, secretNumber);
            gs.ImprovedFindSecretNumber();
            Assert.IsTrue(gs.Game.SecretNumberFound());
            Assert.AreEqual("Number found after 8 guess/es", gs.Game.ShowStatus());
        }



    }
}
