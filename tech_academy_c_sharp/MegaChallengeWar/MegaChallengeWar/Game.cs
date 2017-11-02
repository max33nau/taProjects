using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game
    {
        private Random _random;

        public Game(Random random)
        {
            _random = random;
        }

        public string dealCards(Player player1, Player player2)
        {
            string dealingResult = "<h5> Dealing cards.... <br /> <br />";
            Deck deck = new Deck();
            int cardsDealt = 0;
            int totalAmountOfCards = deck.Cards.Count();
            while (cardsDealt != totalAmountOfCards)
            {
                Player playerToDealTo = (cardsDealt % 2 == 0) ? player1 : player2;
                int totalCardsLeft = deck.Cards.Count();
                int randomCardNumber = _random.Next(totalCardsLeft);
                Card card = deck.Cards.ElementAt(randomCardNumber);
                playerToDealTo.Cards.Add(card);
                deck.Cards.RemoveAt(randomCardNumber);
                dealingResult += String.Format("{0} was dealt a {1} of {2} <br />", playerToDealTo.Name, card.Name, card.Suite);
                cardsDealt++;
            }
            return dealingResult;
        }
    }
}