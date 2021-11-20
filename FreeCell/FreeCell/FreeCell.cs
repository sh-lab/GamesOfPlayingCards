using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.FreeCell
{
    public class FreeCell : ReadOnlyDictionary<Card, IPosition>
    {
        public FreeCell(IDictionary<Card, IPosition> dictionary) : base(dictionary)
        {
        }

        /// <summary>
        /// セルに移動可能か
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <returns>可否</returns>
        public bool CanMoveCell(Card card)
        {
            //　カードが場札にあり、かつ一番上か
            if (!(this[card] is Tableau tableau
                && tableau.Number == Values.OfType<Tableau>().Where(e => e.Column == tableau.Column).Max(e => e.Number)))
            {
                return false;
            }

            // 空のセルがあるか
            foreach (var cell in Cell.Cells)
            {
                if (!Values.Contains(cell))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// セルに移動
        /// </summary>
        /// <param name="card">移動するカード</param>
        public void MoveCell(Card card)
        {
            if (!CanMoveCell(card))
            {
                throw new InvalidOperationException();
            }

            foreach (var cell in Cell.Cells)
            {
                if (!Values.Contains(cell))
                {
                    Dictionary[card] = cell;
                    return;
                }
            }

        }

        /// <summary>
        /// 組札に移動可能か
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <returns>可否</returns>
        public bool CanMoveFoundation(Card card)
        {

            if (card.Rank != Rank.Ace && !(this[card.Down().Value] is Foundation))
            {
                return false;
            }


            return this[card] is Cell
                || (this[card] is Tableau tableau
                    && tableau.Number == Values.OfType<Tableau>().Where(e => e.Column == tableau.Column).Max(e => e.Number));
        }

        /// <summary>
        /// 組札に移動
        /// </summary>
        /// <param name="card">移動するカード</param>
        public void MoveFoundation(Card card)
        {
            if (!CanMoveFoundation(card))
            {
                throw new InvalidOperationException();
            }

            Dictionary[card] = new Foundation();
        }

        /// <summary>
        /// 場札に移動可能か
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先の場札の列</param>
        /// <returns>可否</returns>
        public bool CanMoveTableau(Card card, Column column)
        {
            if (!(this[card] is Cell || CheckCanMoveTableauToTableau(card, column)))
            {
                return false;
            }

            if (Values.OfType<Tableau>().Any(e => e.Column == column))
            {

                var tableauTop = this.First(pair => pair.Value == Values.OfType<Tableau>().Where(e => e.Column == column).OrderByDescending(e => e.Number).First());


                var tableauTopCard = tableauTop.Key;

                return CheckSequence(card, tableauTopCard);
            }

            return true;
        }


        /// <summary>
        /// 場札に移動
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先の場札の列</param>
        public void MoveTableau(Card card, Column column)
        {
            if (!CanMoveTableau(card, column))
            {
                throw new InvalidOperationException();
            }

            var moveCards = new List<Card>() { card };

            if (this[card] is Tableau targetCardTableau)
            {
                moveCards.AddRange(this.Where(e => e.Value is Tableau tableau
                && tableau.Column == targetCardTableau.Column
                && tableau.Number > targetCardTableau.Number)
                .OrderBy(e => ((Tableau)e.Value).Number)
                .Select(e => e.Key).ToList());
            }

            foreach (var currentCard in moveCards)
            {
                Dictionary[currentCard] = new Tableau(column, Values.Count(e => e is Tableau tableau && tableau.Column == column));
            }
        }


        /// <summary>
        /// 比較元のカードが比較先のカードと色違いで一つ下か？
        /// </summary>
        /// <param name="srcCard">比較元のカード</param>
        /// <param name="destCard">比較先のカード</param>
        /// <returns>判定結果</returns>
        private bool CheckSequence(Card srcCard, Card destCard)
        {
            return (((srcCard.Suit == Suit.Spades || srcCard.Suit == Suit.Clubs) && (destCard.Suit == Suit.Hearts || destCard.Suit == Suit.Diamonds))
                    || ((srcCard.Suit == Suit.Hearts || srcCard.Suit == Suit.Diamonds) && (destCard.Suit == Suit.Spades || destCard.Suit == Suit.Clubs)))
                    && srcCard.Rank.Up() == destCard.Rank;
        }


        /// <summary>
        /// 場札から場札へ移動可能かの判定（CanMoveTableauの処理の一部を抜き出し）
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先の場札の列</param>
        /// <returns></returns>
        private bool CheckCanMoveTableauToTableau(Card card, Column column)
        {

            // カードが場札にあるか
            if (this[card] is Tableau targetCardTableau)
            {
                // 移動元と移動先が同じ列でないこと
                if(targetCardTableau.Column == column)
                {
                    return false;
                }

                // 移動するカードの下のカードを取得
                var cards = this.Where(e => e.Value is Tableau tableau
                                && tableau.Column == targetCardTableau.Column
                                && tableau.Number > targetCardTableau.Number)
                        .OrderBy(e => ((Tableau)e.Value).Number)
                        .Select(e => e.Key);

                // 下にカードがなければOK
                if (cards.Count() == 0)
                {
                    return true;
                }


                // 下にあるカードが色違いで順番に並んでいるか
                var targetCard = card;

                foreach (var currentCard in cards)
                {
                    if (!CheckSequence(currentCard, targetCard))
                    {
                        return false;
                    }

                    targetCard = currentCard;
                }

                //カードのない場札の数
                var emptyTableauCount = Enum.GetValues(typeof(Column)).OfType<Column>()
                    .Count(column2 => column != column2 && !Values.Any(e => e is Tableau tableau && tableau.Column == column2));

                // 移動するカードの枚数が（カードの無い場札の数+空のセル)以下なら移動可能
                return cards.Count() <=
                    (Cell.Cells.Length - Values.Count(e => e is Cell)
                    + emptyTableauCount);

            }

            return false;
        }

    }
}
