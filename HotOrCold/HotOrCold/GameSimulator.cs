using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotOrCold
{
    public class GameSimulator
    {
        public Game Game { get; set; }
        int maxNum;

        public GameSimulator(int maxNum, int secretNum)
        {
            this.maxNum = maxNum;
            Game = new Game(maxNum, secretNum);
        }

        public void FindSecretNumber()
        {
            int low = 1;
            int high = maxNum;

            while (!Game.SecretNumberFound())
            {
                int mid = low + (high - low) / 2;
                Game.Guess(low);
                if (Game.Guess(high) == "Colder")
                    high = mid;
                else
                    low = mid;
            }
        }

        public void ImprovedFindSecretNumber()
        {
            int a = 1, b = maxNum, c = 1, prev = 1;
            Game.Guess(c);

            while (b - a > 1)
            {
                int mid = a + (b - a) / 2;
                c = a + b - c;

                if (Game.Guess(c) == "Colder")
                {
                    if (guessingFromRightHalf(c, prev))
                        b = mid;
                    else
                        a = mid;
                }
                else
                {
                    if (guessingFromRightHalf(c, prev))
                        a = mid;
                    else
                        b = mid;
                }

                prev = c;
            }

            Game.Guess(a);
            Game.Guess(b);
        }

        private bool guessingFromRightHalf(int c, int prev)
        {
            return c > prev;
        }
    }
}
