using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Calculation
{
    public class Calculation : ReadOnlyDictionary<Card, IPosition>
    {
        /// <summary>
        /// 台札毎のカードの並び
        /// </summary>
        public static IReadOnlyDictionary<FoundationColumn, IReadOnlyList<Rank>> FoundationSequenceMap =
            new Dictionary<FoundationColumn, IReadOnlyList<Rank>>
            {
                { FoundationColumn.First , new List<Rank>(){
                     Rank.Ace, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven,
                    Rank.Eight, Rank.Nine, Rank.Ten, Rank.Jack, Rank.Queen, Rank.King}.AsReadOnly() },
                { FoundationColumn.Second , new List<Rank>(){
                     Rank.Two, Rank.Four, Rank.Six, Rank.Eight, Rank.Ten, Rank.Queen, Rank.Ace,
                    Rank.Three, Rank.Five, Rank.Seven, Rank.Nine, Rank.Jack, Rank.King}.AsReadOnly() },
                { FoundationColumn.Third , new List<Rank>(){
                     Rank.Three, Rank.Six, Rank.Nine, Rank.Queen, Rank.Two, Rank.Five, Rank.Eight,
                    Rank.Jack, Rank.Ace, Rank.Four, Rank.Seven, Rank.Ten, Rank.King}.AsReadOnly() },
                { FoundationColumn.Fourth , new List<Rank>(){
                     Rank.Four, Rank.Eight, Rank.Queen, Rank.Three, Rank.Seven, Rank.Jack, Rank.Two,
                    Rank.Six, Rank.Ten, Rank.Ace, Rank.Five, Rank.Nine, Rank.King}.AsReadOnly() }
            };

        /// <summary>
        /// 引数の列の台札に次におけるカードのランク。
        /// </summary>
        /// <param name="column">列</param>
        /// <returns>次におけるカードのランク</returns>
        public Rank? NextRank(FoundationColumn column)
        {
            int count = Values.Count(e => e is Foundation f && f.Column == column);

            var FoundationSequence = FoundationSequenceMap[column];

            return count < FoundationSequence.Count ? FoundationSequence[count] : (Rank?)null;
        }
           

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dictionary">初期配置</param>
        public Calculation(IDictionary<Card, IPosition> dictionary) : base(dictionary)
        {
            /// 初期配置に対する制約のチェックは面倒臭いからしない
            /// するなら
            /// ・場札の重複(同じ列の同じ位置)は無いか
            /// ・台札にあるカードは順序を満たしているか
            /// ・手札は一枚以下か
            /// ・山札の重複(同じ列の同じ位置)は無いか
        }


        /// <summary>
        /// 引数のカードが山札から引けるか（山札から手札に移動可能か）
        /// </summary>
        /// <param name="card"></param>
        /// <returns>可否</returns>
        public bool CanDraw(Card card) => !Values.Any(e => e is WastePile)
            && Dictionary[card] is Stock
            && card.Equals(Dictionary.Where(pair => pair.Value is Stock).
                OrderByDescending(pair => ((Stock)pair.Value).Number).
                First().Key);

        /// <summary>
        /// カードを山札からめくる（山札から手札に移動する。）。
        /// </summary>
        /// <param name="card">めくるカード</param>
        public void Draw(Card card)
        {
            if (!CanDraw(card))
            {
                return;
            }

            Dictionary[card] = new WastePile();
        }

        /// <summary>
        /// カードが場札に移動可能か
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <returns>可否</returns>
        public bool CanMoveTableau(Card card)
        {
            return Dictionary[card] is WastePile;
        }

        /// <summary>
        /// カードを場札に移動する。
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先の場札の列</param>
        public void MoveTableau(Card card, TableaColumn column)
        {
            if (!CanMoveTableau(card))
            {
                throw new InvalidOperationException();
            }

            Dictionary[card] = new Tableau(column, Values.Count(e => e is Tableau tableau && tableau.Column == column));

        }

        /// <summary>
        /// カードが場札に移動可能か
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先の場札の列</param>
        /// <returns>可否</returns>
        public bool CanMoveFoundation(Card card, FoundationColumn column)
        {
            if (!(Dictionary[card] is WastePile
                || (Dictionary[card] is Tableau tableau
                    && tableau.Number == Values.OfType<Tableau>().Where(e => e.Column == tableau.Column).Max(e => e.Number))))
            {
                return false;
            }

            return card.Rank == NextRank(column);
        }

        /// <summary>
        /// カードを場札に移動する。
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <param name="column">移動先の場札の列</param>
        public void MoveFoundation(Card card, FoundationColumn column)
        {
            if (!CanMoveFoundation(card, column))
            {
                throw new InvalidOperationException();
            }

            Dictionary[card] = new Foundation(column);


        }
    }
}
