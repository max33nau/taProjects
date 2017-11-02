using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {
        private List<Card> _bounty;
        private List<Player> _players;
        private Dictionary<string, Card> _topCards;
        private Dictionary<string, Card> _warCards;
        string _battleType = "normal";
        string battleDetails = "<h3> Begin battle ... </h3>";
        private int _cardsPlayed = 0;

        public Battle(List<Player> Players)
        {
            _bounty = new List<Card>();
            _topCards = new Dictionary<string, Card>();
            _warCards = new Dictionary<string, Card>();
            _players = Players;
        }

        public string beginBattle()
        {
            int totalCards = getTotalAmountOfCards();
            while ( _cardsPlayed < 20 && !playerHasWon(totalCards) )
            { performBattle(); }
            evalFinalScore();
            return battleDetails;
        }

        private int getTotalAmountOfCards()
        {
            int totalCards = 0;
            foreach (Player player in _players)
            { totalCards += player.Cards.Count(); }
            return totalCards;
        }

        private bool playerHasWon(int totalCards)
        {
            foreach (Player player in _players)
            { if (player.Cards.Count() == totalCards) return true;  }
            return false;
        }

        private void performBattle()
        {
            selectTopCards();
            displayBattleCards();
            if (warBattleFound())
            {
                _warCards.Clear();
                addCardsToBounty();
                performWar();
            }
            else
            {
                addCardsToBounty();
                displayBounty();
                evalWinner();
                removeTopCards();
                _bounty.Clear();
                _cardsPlayed++;
                _battleType = "normal";
            }
        }

        private void selectTopCards()
        {
            _topCards.Clear();
            if (_battleType == "war")
            {
                foreach (KeyValuePair<string, Card> entry in _warCards)
                {
                    Player player = _players.First(p => p.Name == entry.Key);
                    if (player.Cards.Count() > 0)
                        _topCards.Add(player.Name, player.getTopCard());
                }
            } else
            {
               foreach (Player player in _players)
               {
                    if (player.Cards.Count() > 0)
                        _topCards.Add(player.Name, player.getTopCard());
                }
            }
        }

        private void removeTopCards()
        {
            if (_battleType == "war")
            {
                foreach (KeyValuePair<string, Card> entry in _warCards)
                {
                    Player player = _players.First(p => p.Name == entry.Key);
                    if (player.Cards.Count() > 0)
                        player.removeTopCard();
                }
            } else
            {
                foreach (Player player in _players)
                {
                    if (player.Cards.Count() > 0)
                        player.removeTopCard();
                }
            }

        }

        private void displayBattleCards()
        {
            battleDetails += "Battle Cards: <br />";
            foreach (KeyValuePair<string, Card> entry in _topCards)
            {
                string playerName = entry.Key;
                Card card = entry.Value;
                battleDetails += String.Format("{0} plays {1} of {2} <br /> ",
                  playerName, card.Name, card.Suite);
            }
        }

        private void addCardsToBounty()
        {
            foreach (KeyValuePair<string, Card> entry in _topCards)
            { _bounty.Add(entry.Value); }
        }

        private void displayBounty()
        {
            battleDetails += "Bounty ... <br />";
            foreach (Card card in _bounty)
            {
                battleDetails += String.Format(
                    "<div style=\"margin-left: 20px;\">{0} of {1} </div>",
                    card.Name, card.Suite);
            }
        }

        private bool warBattleFound()
        {
            for (int i = 0; i < _topCards.Count(); i++)
            {
                Card evalCard = _topCards.ElementAt(i).Value;
                int numberOfOccurences = _topCards.Where(entry => entry.Value.Value == evalCard.Value).Count();
                if (numberOfOccurences > 1) return true;
            }
            return false;
        }

        private void performWar()
        {
            battleDetails += "<h5> **********WAR********** </h5>";
            battleDetails += "War is between: ";
            _battleType = "war";
            for (int i = 0; i < _topCards.Count(); i++)
            {
                Card evalCard = _topCards.ElementAt(i).Value;
                int numberOfOccurences = _topCards.Where(entry => entry.Value.Value == evalCard.Value).Count();
                if (numberOfOccurences > 1)
                {
                    string playerName = _topCards.ElementAt(i).Key;
                    Card playerCard = _topCards.ElementAt(i).Value;
                    _warCards.Add(playerName, playerCard);
                    battleDetails += playerName + " ";
                    if (i < _topCards.Count() - 1) { battleDetails += "and ";  }
                }
            }
            battleDetails += "<br />";
            for (int i = 0; i < (_warCards.Count() - 1) * 3; i++)
            {
                removeTopCards();
                selectTopCards();
                addCardsToBounty();
                _cardsPlayed++;
            }
            removeTopCards();
            performBattle();
        }

        private void evalWinner()
        {
            string winnerName = "";
            for (int i = 0; i < _topCards.Count(); i++)
            {
                Card evalCard = _topCards.ElementAt(i).Value;
                int numberOfOccurences = _topCards.Where(entry => evalCard.Value > entry.Value.Value).Count();
                if (numberOfOccurences == _topCards.Count() - 1)
                { winnerName = _topCards.ElementAt(i).Key; }
            }
            Player winner = _players.First(player => player.Name == winnerName);
            battleDetails += String.Format("<strong style=\"color: {0};\"> {1} wins! </strong> <br /> <br />", winner.Color, winner.Name);
            foreach (Card card in _bounty)
            { winner.Cards.Add(card); }
        }

        private void  evalFinalScore()
        {
            List<Player> finalWinners = new List<Player>();
            foreach (Player player in _players)
            {
                int totalNumber = player.Cards.Count();
                battleDetails += String.Format("<h3 style=\"color: {0};\"> {1} total number of cards is {2} </h3>", player.Color, player.Name, totalNumber);
                int numberOfOccurences = _players.Where(p => totalNumber > p.Cards.Count()).Count();
                if (numberOfOccurences == _players.Count() - 1)
                { finalWinners.Add(player); }
            }
            foreach(Player winner in finalWinners)
            {
                battleDetails += String.Format("<h2 style=\"color: {0};\"> {1} is our final winner. </h2>", winner.Color, winner.Name);
            }
        }


    }
}