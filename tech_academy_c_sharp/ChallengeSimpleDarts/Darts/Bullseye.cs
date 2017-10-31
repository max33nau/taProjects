using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Bullseye
    {
        private Random _random { get; set; }
        public bool outer { get; private set; }
        public bool inner { get; private set; }

        public Bullseye(Random random)
        {
            _random = random;
        }

        public void checkIfHit(int number)
        {
            if (isBullseye(number))
            {
                int multiplier = _random.Next(1, 101);
                outer = isOuter(multiplier);
                inner = isInner(multiplier);
            }
            else
            {
                outer = false;
                inner = false;
            }
        }

        private static bool isBullseye(int number) {
            return (number == 0) ? true : false;
        }

        private static bool isOuter(int number) {
            return (number <= 5) ? true : false;
        }

        private static bool isInner(int number) {
            return (number > 95) ? true : false;
        }
    }
}
