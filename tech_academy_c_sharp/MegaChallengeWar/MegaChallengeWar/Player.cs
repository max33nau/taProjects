using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Card> Cards { get; set; }

        public Player(string name, string color)
        {
            Name = name;
            Color = color;
            Cards = new List<Card>();

        }

        public Card getTopCard() { return Cards.ElementAt(0); }

        public void removeTopCard() { Cards.RemoveAt(0); }

    }
}