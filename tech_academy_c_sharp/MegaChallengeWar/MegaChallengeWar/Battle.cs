using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {
        private List<Card> _bounty;
        private Player _player1;
        private Player _player2;
        private Card _player1Card;
        private Card _player2Card;
        string battleDetails = "<h3> Begin battle ... </h3>";
        private int _cardsPlayed = 0;

        public Battle(Player player1, Player player2)
        {
            _bounty = new List<Card>();
            _player1 = player1;
            _player2 = player2;
        }

        public string beginBattle()
        {
            while ( _cardsPlayed < 20 ) { performBattle(); }
            evalFinalScore();
            return battleDetails;
        }

        private void performBattle()
        {
            selectTopCards();
            displayBattleCards();
            if (_player1Card.Value == _player2Card.Value)
            { performWar(); } else
            {
                addCardsToBounty();
                displayBounty();
                evalWinner();
                removeTopCards();
                emptyBounty();
                _cardsPlayed++;
            }
        }

        private void  evalFinalScore()
        {
            battleDetails += String.Format("<h3 style=\"color: {0};\"> {1} total number of cards is {2} </h3>", _player1.Color, _player1.Name, _player1.Cards.Count());
            battleDetails += String.Format("<h3 style=\"color: {0};\"> {1} total number of cards is {2} </h3>", _player2.Color, _player2.Name, _player2.Cards.Count());
            Player winner;
            if (_player1.Cards.Count() > _player2.Cards.Count())
            { winner = _player1; }
            else { winner = _player2; }
            battleDetails += String.Format("<h2 style=\"color: {0};\"> {1} is our final winner. </h2>", winner.Color, winner.Name);
        }

        private void selectTopCards()
        {
            _player1Card = _player1.Cards.ElementAt(0);
            _player2Card = _player2.Cards.ElementAt(0);
        }

        private void removeTopCards()
        {
            _player1.Cards.RemoveAt(0);
            _player2.Cards.RemoveAt(0);
        }

        private void displayBattleCards()
        {
            battleDetails += "Battle Cards: <br />";
            battleDetails += String.Format("{0} plays {1} of {2} <br /> ",
                _player1.Name, _player1Card.Name, _player1Card.Suite);
            battleDetails += String.Format("{0} plays {1} of {2} <br /> ",
                _player2.Name, _player2Card.Name, _player2Card.Suite);
        }

        private void evalWinner()
        {
            Player winner;
            if (_player1Card.Value > _player2Card.Value)
            { winner = _player1; }
            else { winner = _player2; }
            battleDetails += String.Format("<strong style=\"color: {0};\"> {1} wins! </strong> <br /> <br />", winner.Color, winner.Name);
            foreach (Card card in _bounty)
            { winner.Cards.Add(card); }
        }

        private void performWar()
        {
            battleDetails += "<h5> **********WAR********** </h5>";
            for(int i = 0; i < 3; i++)
            {
                removeTopCards();
                selectTopCards();
                addCardsToBounty();
                _cardsPlayed++;
            }
            removeTopCards();
            performBattle();
        }

        private void addCardsToBounty()
        {
            _bounty.Add(_player1Card);
            _bounty.Add(_player2Card);
        }

        private void emptyBounty()
        {
            _bounty.Clear();
        }

        private void displayBounty()
        {
            battleDetails += "Bounty ... <br />";
            foreach(Card card in _bounty)
            {
                battleDetails += String.Format(
                    "<div style=\"margin-left: 20px;\">{0} of {1} </div>",
                    card.Name, card.Suite);
            }
        }
    }
}