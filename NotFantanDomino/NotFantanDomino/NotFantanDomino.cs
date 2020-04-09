using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.NotFantanDomino
{
    public class NotFantanDomino : ReadOnlyDictionary<Card, Position>
    {
        public PlayerNumber TurnPlayer
        {
            get;
            private set;
        }

        public NotFantanDomino(IDictionary<Card, Position> dictionary) : base(dictionary)
        {
            if (dictionary.Values.Any(pos => pos == Position.Field))
            {
                throw new ArgumentException();
            }

            TurnPlayer = (PlayerNumber)(dictionary[Card.SevenOfDiamonds]);
        }

        public bool CanRelease(IList<Card> cards)
        {

            // 0枚はOK（スキップ扱い）。
            if (cards.Count == 0)
            {
                return true;
            }

            // 既に場にあるカードはだめ
            if (cards.Any(card => Dictionary[card] == Position.Field))
            {
                return false;
            }

            // 番の人の手札じゃないとだめ
            if (!cards.All(card => Dictionary[card] == (Position)TurnPlayer))
            {
                return false;
            }


            // 柄は全て同じ
            var suits = cards.Select(card => card.Suit).Distinct();

            if (suits.Count() != 1)
            {
                return false;
            }

            // 連番チェック
            var ranks = cards.OrderBy(card => card.Rank).Select(card => card.Rank);

            if (ranks.Sum(rank => (int)rank) != ranks.Count() * (2 * (int)ranks.First() + ranks.Count() - 1) / 2)
            {
                return false;
            }

            var minDownCard = cards.Min().Down();

            if (minDownCard.HasValue
                && Dictionary.ContainsKey(minDownCard.Value)
                && Dictionary[minDownCard.Value] == Position.Field)
            {
                return false;
            }

            var maxUpCard = cards.Max().Up();

            if (maxUpCard.HasValue
                 && Dictionary.ContainsKey(maxUpCard.Value)
                 && Dictionary[maxUpCard.Value] == Position.Field)
            {
                return false;
            }

            return true;
        }

        public void Release(IList<Card> cards)
        {
            if (!CanRelease(cards))
            {
                throw new InvalidOperationException();
            }

            foreach (var card in cards)
            {
                Dictionary[card] = Position.Field;
            }

            TurnPlayer = (PlayerNumber)(((int)TurnPlayer + 1) % 4);
        }
    }
}
