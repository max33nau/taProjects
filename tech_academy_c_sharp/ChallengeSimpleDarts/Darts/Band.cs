using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Band
    {
        private Random _random { get; set;  }
        public bool outer { get; private set; }
        public bool inner { get; private set; }

        public Band(Random random)
        {
            _random = random;
        }

        public void checkIfHit(int number)
        {
            if (isNotBullseye(number))
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

        private static bool isNotBullseye(int number)
        {
            return (number != 0) ? true : false;
        }

        private static bool isOuter(int number)
        {
            return (number > 5 && number < 11) ? true : false;
        }

        private static bool isInner(int number)
        {
            return (number > 30 && number < 36) ? true : false;
        }
    }
}
