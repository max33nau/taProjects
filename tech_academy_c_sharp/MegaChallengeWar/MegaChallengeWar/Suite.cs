using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Suite
    {
        public List<Card> Cards { get; private set; }

        public Suite(string name)
        {
            Cards = new List<Card>()
            {
                new Card() { Name = "2", Value = 1 },
                new Card() { Name = "3", Value = 2 },
                new Card() { Name = "4", Value = 3 },
                new Card() { Name = "5", Value = 4 },
                new Card() { Name = "6", Value = 5 },
                new Card() { Name = "7", Value = 6 },
                new Card() { Name = "8", Value = 7 },
                new Card() { Name = "9", Value = 8 },
                new Card() { Name = "10", Value = 9 },
                new Card() { Name = "Jack", Value = 10 },
                new Card() { Name = "Queen", Value = 11 },
                new Card() { Name = "King", Value = 12 },
                new Card() { Name = "Ace", Value = 13 }
            };
            Cards.ForEach(card => card.Suite = name);
        }

    }
}