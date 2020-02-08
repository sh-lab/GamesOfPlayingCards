using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Pyramid
{
    public class Pyramid : ReadOnlyDictionary<Card, IPosition>
    {

        public Pyramid(IDictionary<Card, IPosition> dictionary) : base(dictionary)
        {

            // ジョーカーの位置を取得
            var positionList = dictionary.Where(pair => pair.Key.IsJoker)
                .Select(pair => pair.Value).ToList();

            // Jokerはフリースペースが除去済みでなければいけない。
            if (positionList.Any()　&& !positionList.All(e => e is Outside || e is FreeSpace))
            {
                throw new ArgumentException();
            }

            var handCards = dictionary.Where(pair => pair.Value is Hand).Select(pair => pair.Key);

            //手札は一枚以下
            if (handCards.Count() == 1)
            {
                // NOP
            }
            else if (handCards.Count() > 1)
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// リムーブ可否 引数のカードを「OutSide」に移動できるか。
        /// </summary>
        /// <param name="card">リムーブするカード</param>
        /// <returns>リムーブ可否</returns>
        public bool CanRemove(Card card)
        {
            // 一枚で除去できるのはKing(13)のみ
            if (card.Rank != Rank.King)
            {
                return false;
            }

            return CanSelectForRemove(card);
        }

        /// <summary>
        /// 引数のカードがリムーブ対象として選択可能か？
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CanSelectForRemove(Card card)
        {
            var cardPosition = Dictionary[card];

            // 除去済みは無理
            if (cardPosition is Outside)
            {
                return false;
            }

            // 手札・フリースぺースは除去可能
            if (cardPosition is Hand || cardPosition is FreeSpace)
            {
                return true;
            }

            // 捨て札の一番上も可能
            if (cardPosition is Discard discard)
            {
                return Dictionary.Any(pair =>
                pair.Value is Discard otherDiscard
                && otherDiscard.Number <= discard.Number);
            }

            // 場札は上にカードがない場合
            if (cardPosition is Field field)
            {
                return !Dictionary.Any(pair =>
                pair.Value is Field otherField
                && otherField.Row == field.Row + 1
                && (otherField.Number == field.Number
                || otherField.Number == field.Number + 1));
            }

            return false;
        }

        /// <summary>
        /// リムーブ 引数のカードを「OutSide」に移動する。
        /// </summary>
        /// <param name="card">リムーブするカード</param>
        public void Remove(Card card)
        {
            if (!CanRemove(card))
            {
                throw new InvalidOperationException();
            }

            Dictionary[card] = new Outside();

            
        }

        /// <summary>
        /// 引数の2枚のカードをリムーブ（「OutSide」に移動）できるか？
        /// </summary>
        /// <param name="firstCard"></param>
        /// <param name="secondCard"></param>
        /// <returns></returns>
        public bool CanRemove(Card firstCard, Card secondCard)
        {
            if (!firstCard.IsJoker
                && !secondCard.IsJoker
                && ((int)firstCard.Rank + (int)secondCard.Rank != 13))
            {
                return false;
            }

            return CanSelectForRemove(firstCard)
                && CanSelectForRemove(secondCard);
        }

        /// <summary>
        /// リムーブ可否 引数の2枚のカードを「OutSide」に移動できるか。
        /// </summary>
        /// <param name="firstCard"></param>
        /// <param name="secondCard"></param>
        public void Remove(Card firstCard, Card secondCard)
        {
            if (!CanRemove(firstCard, secondCard))
            {
                throw new InvalidOperationException();
            }

            Dictionary[firstCard] = new Outside();
            Dictionary[secondCard] = new Outside();
        }

        /// <summary>
        /// リディール可能か？
        /// </summary>
        /// <returns></returns>
        public bool CanRedeal()
        {
            // 山札が一枚もなければOK
            return !Dictionary.Any(pair => pair.Value is Deck);
        }

        /// <summary>
        /// リディール
        /// </summary>
        public void Redeal()
        {
            if (!CanRedeal())
            {
                throw new InvalidOperationException();
            }


            int deckCount = 0;

            Dictionary.
                Where(pair => pair.Value is Discard).
                OrderByDescending(pair => ((Discard)pair.Value).Number).
                Select(pair => pair.Key).
                ToList().ForEach(card =>
                {
                    Dictionary[card] = new Deck(deckCount++);
                });
        }

        /// <summary>
        /// 山札から引数のカードを手札に移動できるか？
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CanDraw(Card card)
        {
            return this[card] is Deck deck
                && deck.Number ==
                    Dictionary.Values.OfType<Deck>().OrderByDescending(e => e.Number).First().Number;
        }

        /// <summary>
        /// 山札から引数のカードを手札に移動
        /// </summary>
        /// <param name="card"></param>
        public void Draw(Card card)
        {
            if (!CanDraw(card))
            {
                throw new InvalidOperationException();
            }

            // 現在の手札を取得。
            var handCard = Dictionary.Where(pair => pair.Value is Hand).Select(pair => pair.Key).Cast<Card?>().FirstOrDefault();

            // 手札を捨て札の一番上に移動
            if (handCard.HasValue)
            {
                Dictionary[handCard.Value] = new Discard(this.Count(pair => pair.Value is Discard));
            }

            Dictionary[card] = new Hand();


        }
    }
}
