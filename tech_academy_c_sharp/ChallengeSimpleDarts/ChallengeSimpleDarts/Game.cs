using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        Random _random = new Random();

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
            
        }

        public string Play()
        {
            while (_player1.Score < 300 && _player2.Score < 300)
            {
                takeTurn(_player1);
                takeTurn(_player2);
            }

            return getResult();
        }

        private void takeTurn(Player player)
        {   
            for( int i = 0; i < 2; i++)
            {
                Darts.Dart dart = new Darts.Dart(_random);
                dart.Throw();
                if (dart.bullseye.inner) { player.Score += 50; }
                else if (dart.bullseye.outer) { player.Score += 25; }
                else if (dart.band.inner) { player.Score += dart.Score * 3; }
                else if (dart.band.outer) { player.Score += dart.Score * 2; }
                else { player.Score += dart.Score;  }
            }
        }

        private string getResult()
        {
            string result = "";
            result += String.Format("{0} scored {1} points <br />", _player1.Name, _player1.Score);
            result += String.Format("{0} scored {1} points <br /> <br />", _player2.Name, _player2.Score);
            Player winner;
            if (_player1.Score > _player2.Score) { winner = _player1; }
            else { winner = _player2; }
            result += String.Format("And the winner is <strong> {0} </strong>", winner.Name);
            return result;
        }
    }
}