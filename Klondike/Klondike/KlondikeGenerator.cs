using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    public static class KlondikeGenerator
    {
        public static Klondike Generate()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            var cards = CardListGenerator.GenerateNoJokerShuffledCardList();

            var cardListIndex = 0;

            foreach (Column column in Enum.GetValues(typeof(Column)))
            {

                for(var i = 0; i < (int)column; i++)
                {
                    dictionary.Add(cards[cardListIndex++], new Tableau(column, i, false));
                }

                dictionary.Add(cards[cardListIndex++], new Tableau(column, (int)column, true));

            }

            for (int i = 0; cardListIndex < cards.Count; i++)
            {
                dictionary.Add(cards[cardListIndex++], new Stock(i));
            }


            return new Klondike(dictionary);
        }
    }
}
