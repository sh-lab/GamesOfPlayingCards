using System;
using System.Collections.Generic;

namespace Net.Sh_Lab.PlayingCards.FreeCell
{
    public static class FreeCellGenerator
    {
        public static FreeCell Generate()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            var cards = CardListGenerator.GenerateNoJokerShuffledCardList();

            var cardListIndex = 0;

            foreach (Column column in Enum.GetValues(typeof(Column)))
            {


                for (var i = 0; i < (column <= Column.Fourth ? 7 : 6); i++)
                {
                    dictionary.Add(cards[cardListIndex++], new Tableau(column, i));
                }


            }


            return new FreeCell(dictionary);
        }

    }
}
