using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Pyramid
{
    public static class PyramidGenerator
    {
        public static Pyramid GeneratePyramid()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            var cardList = CardListGenerator.GenerateNoJokerShuffledCardList();

            var cardListIndex = 0;

            for(int row = Field.RowMin; row < Field.RowMaxCount; row++)
            {
                for( int number =0; number <= row; number++)
                {
                    dictionary.Add(cardList[cardListIndex++], new Field(row, number));
                }
            }

            // 残りは山札
            for (int i = 0; cardListIndex < cardList.Count; i++)
            {
                dictionary.Add(cardList[cardListIndex++], new Deck(i));
            }

            // ジョーカー2枚はフリースペースに
            dictionary.Add(Card.Joker, new FreeSpace(0));
            dictionary.Add(Card.ExtraJoker, new FreeSpace(1));
            
            return new Pyramid(dictionary);


        }
    }
}
