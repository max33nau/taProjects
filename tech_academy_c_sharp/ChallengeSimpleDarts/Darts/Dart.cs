using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Darts
{
    public class Dart
    {
        private Random _random { get; set; }
        private int _maxNumber { get; set; }
        private int _minNumber { get; set; }
        public int Score { get; private set; }

        public Band band { get; set; }
        public Bullseye bullseye { get; set; }

        public Dart(Random random)
        {
            _random = random;
            _maxNumber = 21;
            _minNumber = 0;
            band = new Band(random);
            bullseye = new Bullseye(random);
        }

        public void Throw()
        {
            Score = _random.Next(_minNumber, _maxNumber);
            bullseye.checkIfHit(Score);
            band.checkIfHit(Score);
        }

    }

}
