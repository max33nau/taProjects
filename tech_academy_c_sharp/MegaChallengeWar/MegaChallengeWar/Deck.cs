using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck
    {


        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = loadDeck();
        }

        private static List<Card> loadDeck()
        {
          List<Suite> _suites = new List<Suite>()
            { new Suite("Hearts"), new Suite("Spades"),
              new Suite("Diamonds"), new Suite("Clubs")
          };
            List<Card> cards = new List<Card>();
            foreach(Suite suite in _suites)
                foreach (Card card in suite.Cards)
                    cards.Add(card);
            return cards;
        }
    }

}