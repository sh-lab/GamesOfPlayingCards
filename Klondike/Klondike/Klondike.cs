using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    /// <summary>
    /// クロンダイク
    /// </summary>
    public class Klondike : ReadOnlyDictionary<Card, IPosition>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dictionary">カードとその位置</param>
        public Klondike(IDictionary<Card, IPosition> dictionary) : base(dictionary)
        {

        }

        /// <summary>
        /// カードが表にできるか？
        /// カードがタブローにありかつ一番上かつ裏
        /// </summary>
        /// <param name="card">表にするカード</param>
        /// <returns>可否</returns>
        public bool CanOpen(Card card) => this[card] is Tableau tableau
                                            && !tableau.Open
                                            && tableau.Number == Values.OfType<Tableau>().Where(e => e.Column == tableau.Column).Max(e => e.Number);


        /// <summary>
        /// カードを表にする。
        /// </summary>
        /// <param name="card">表にするカード</param>
        public void Open(Card card)
        {
            if (!CanOpen(card))
            {
                throw new InvalidOperationException();
            }

            var tableau = (Tableau)this[card];

            Dictionary[card] = new Tableau(tableau.Column, tableau.Number, true);

        }

        /// <summary>
        /// カードを山札からめくることができるか？
        /// 山札の一番上なら可
        /// </summary>
        /// <param name="card">めくるカード</param>
        /// <returns>可否</returns>
        public bool CanDraw(Card card) => this[card] is Stock stock
                                        && stock.Number == Values.OfType<Stock>().Max(e => e.Number);

        /// <summary>
        /// カードを山札からめくる。
        /// </summary>
        /// <param name="card">めくるカード</param>
        public void Draw(Card card)
        {
            if (!CanDraw(card))
            {
                throw new InvalidOperationException();
            }

            Dictionary[card] = new WastePile(Dictionary.Values.OfType<WastePile>().Count());
        }

        /// <summary>
        /// カードが組札に移動可能か？
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <returns>可否</returns>
        public bool CanMoveFundation(Card card)
        {
            // カードがA以外の場合は一つ前のカードが組札に存在すること
            if (card.Rank != Rank.Ace && !(this[card.Down().Value] is Foundation))
            {
                return false;
            }

            // 捨て札の一番上またはタブローの一番上で表のカード
            return (this[card] is WastePile wastePile
                    && wastePile.Number == Values.OfType<WastePile>().Max(e => e.Number))
                    || (this[card] is Tableau tableau
                    && tableau.Open && tableau.Number == Values.OfType<Tableau>().Where(e => e.Column == tableau.Column).Max(e => e.Number));

        }

        /// <summary>
        /// カードを組札に移動する。
        /// </summary>
        /// <param name="card">移動するカード</param>
        public void MoveFundation(Card card)
        {

            if (!CanMoveFundation(card))
            {
                throw new InvalidOperationException();
            }

            Dictionary[card] = new Foundation();
        }

        /// <summary>
        /// リディール可能か？
        /// </summary>
        /// <returns></returns>
        public bool CanRedeal()
        {
            // 山札が一枚もなくWastePileに一枚以上あればOK
            return !Values.Any(e => e is Stock) && Values.Any(e => e is WastePile);
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
                Where(pair => pair.Value is WastePile).
                OrderByDescending(pair => ((WastePile)pair.Value).Number).
                Select(pair => pair.Key).
                ToList().ForEach(card =>
                {
                    Dictionary[card] = new Stock(deckCount++);
                });
        }

        /// <summary>
        /// カードが引数で指定した列のタブローに移動可能か？
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先のタブローの列</param>
        /// <returns>可否</returns>
        public bool CanMoveTableau(Card card, Column column)
        {
            

            if (this[card] is Stock
                || (!(this[card] is WastePile wastePile
                        && wastePile.Number == Dictionary.Values.OfType<WastePile>().Max(e => e.Number))
                    && !(this[card] is Foundation
                        && card.Rank != Rank.King
                        && !(this[card.Up().Value] is Foundation))
                    && !(this[card] is Tableau tableau
                        && tableau.Open
                        && tableau.Column != column
                        && CheckSequenceForTableau(card))))
            {
                return false;
            }



            if (Values.OfType<Tableau>().Any(e => e.Column == column))
            {

                var tableauTop = this.First(pair => pair.Value == Values.OfType<Tableau>().Where(e => e.Column == column).OrderByDescending(e => e.Number).First());

                if(tableauTop.Value is Tableau tab && !tab.Open)
                {
                    return false;
                }

                var tableauTopCard = tableauTop.Key;

                return CheckSequence(card, tableauTopCard);
            }


            return card.Rank == Rank.King;
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
        /// 引数のカードがタブローにありその下のカードが色違いで順番に並んでいるか？
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private bool CheckSequenceForTableau(Card card)
        {

            var targetCardTableau = (Tableau)this[card];

            var targetCard = card;

            foreach (var currentCard in
                this.Where(e => e.Value is Tableau tableau
                            && tableau.Column == targetCardTableau.Column
                            && tableau.Number > targetCardTableau.Number)
                    .OrderBy(e => ((Tableau)e.Value).Number)
                    .Select(e => e.Key))
            {
                if (!CheckSequence(currentCard, targetCard))
                {
                    return false;
                }

                targetCard = currentCard;
            }

            return true;
        }

        /// <summary>
        /// 引数のカードを引数の列のタブローに移動する。
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先のタブローの列</param>
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
                Dictionary[currentCard] = new Tableau(column, Values.Count(e => e is Tableau tableau && tableau.Column == column), true);
            }

        }

        /// <summary>
        /// タブローの一番上のカードを取得する。
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private Card? TableauTopCard(Column column)
        {
            var cardEnumerable = this.Where(e => e.Value is Tableau tableau && tableau.Column == column)
                .OrderByDescending(e => ((Tableau)e.Value).Number)
                .Select(e => e.Key);

            return cardEnumerable.Count() == 0 ? null : (Card?)cardEnumerable.First();

        }
    }
}
