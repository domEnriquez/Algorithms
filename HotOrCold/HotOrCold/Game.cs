using System;

namespace HotOrCold
{
    public class Game
    {
        private int maxNum;
        private int secretNumber;
        private int prevDistance = -1;
        private int guessCount;

        public Game(int maxNum, int secretNum)
        {
            this.maxNum = maxNum;
            setSecretNumber(secretNum);
        }

        private void setSecretNumber(int num)
        {
            if (!existsInSet(num))
                throw new ArgumentException();

            secretNumber = num;
        }

        public string Guess(int num)
        {
            if (SecretNumberFound())
                return string.Empty;

            guessCount++;

            int currDistance = distFromTarget(num);
            string result = HotterOrColder(currDistance, prevDistance);
            prevDistance = currDistance;

            return result;
        }

        private string HotterOrColder(int currDist, int prevDist)
        {
            if (firstGuess())
                return string.Empty;

            if (currDist >= prevDist)
                return "Colder";
            else
                return "Hotter";
        }

        private bool firstGuess()
        {
            return prevDistance == -1;
        }

        private bool existsInSet(int num)
        {
            return num >= 1 && num <= maxNum;
        }

        private int distFromTarget(int guess)
        {
            return Math.Abs(guess - secretNumber);
        }

        public string ShowStatus()
        {
            if (SecretNumberFound())
                return "Number found after " + guessCount + " guess/es";
            else
                return "Secret number not yet found";
        }

        public bool SecretNumberFound()
        {
            return prevDistance == 0;
        }

        public class InvalidSetSizeException : ApplicationException
        {
        }
    }
}