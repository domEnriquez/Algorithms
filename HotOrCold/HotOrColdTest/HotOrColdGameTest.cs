using HotOrCold;
using NUnit.Framework;
using System;

namespace HotOrColdTest
{
    [TestFixture]
    public class HotOrColdGameTest
    {
        private const int setSize = 7;
        private const int secretNumber = 2;
        Game game;

        [SetUp]
        public void givenAGameWithValidSetSizeAndSecretNumber()
        {
            game = new Game(setSize, secretNumber);
        }

        [Test]
        public void whenSecretNumberDoestNotExistsInNumSet_throwInvalidInputException()
        {
            Assert.Throws<ArgumentException>(() => new Game(setSize, setSize + 1));
        }

        [Test]
        public void whenMakingValidInitialGuess_thenReturnEmptyString()
        {
            Assert.AreEqual(string.Empty, game.Guess(3));
        }

        [Test]
        public void whenGuessingForSecretNumberAfterInitialGuess_thenShowIfHotterOrColder()
        {
            game.Guess(5);
            Assert.AreEqual("Colder", game.Guess(7));
            Assert.AreEqual("Hotter", game.Guess(4));
            Assert.AreEqual("Colder", game.Guess(6));
            Assert.AreEqual("Hotter", game.Guess(3));
            Assert.AreEqual("Colder", game.Guess(4));
        }

        [Test]
        public void whenSecretNumberFound_thenSecretNumberFoundShouldReturnTrue()
        {
            game.Guess(2);
            Assert.IsTrue(game.SecretNumberFound());
        }

        [Test]
        public void whenSecretNumberNotYetFound_thenSecretNumberFoundShouldReturnFalse()
        {
            game.Guess(4);
            Assert.IsFalse(game.SecretNumberFound());
        }

        [Test]
        public void whenAskedForStatusWhileSecretNumberIsNotYetFound_thenShowNumberNotYetFound()
        {
            game.Guess(4);
            Assert.AreEqual("Secret number not yet found", game.ShowStatus());
        }

        [Test]
        public void whenAskedForStatusWhileSecretNumberFound_thenShowNumberOfGuessesMade()
        {
            game.Guess(4);
            game.Guess(2);
            Assert.AreEqual("Number found after 2 guess/es", game.ShowStatus());
        }
    }
}
