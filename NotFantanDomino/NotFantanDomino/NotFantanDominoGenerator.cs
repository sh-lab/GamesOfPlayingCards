using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.NotFantanDomino
{
    public static class NotFantanDominoGenerator
    {



        public static NotFantanDomino Generate()
        {
            var cardList = CardListGenerator.GenerateNoJokerShuffledCardList();
            
            var dictionary = new Dictionary<Card, Position>();

            while(cardList.Count() > 0)
            {
                foreach(var playerNumber in Enum.GetValues(typeof(PlayerNumber)))
                {
                    dictionary.Add(cardList.Dequeue(), (Position)playerNumber);

                    if(cardList.Count() <= 0)
                    {
                        break;
                    }
                }

                
            }


            return new NotFantanDomino(dictionary);
        }

        /// <summary>
        /// 先頭にあるオブジェクトを削除し、返します
        /// </summary>
        private static T Dequeue<T>(this IList<T> self)
        {
            var result = self[0];
            self.RemoveAt(0);
            return result;
        }
    }
}
