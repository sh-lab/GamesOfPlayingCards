using System;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.FreeCell
{
    public static class FreeCellQuery
    {
        /// <summary>
        /// *勝利* 組札に全て移動した
        /// </summary>
        /// <param name="freeCell"></param>
        /// <returns></returns>
        public static bool IsWin(this FreeCell freeCell) => freeCell.All(pair => pair.Value is Foundation);


        /// <summary>
        /// 組札に移動しても問題がない（移動するカードより下のランクのカードが全て組札に移動ずみ）か
        /// </summary>
        /// <param name="freeCell"></param>
        /// <param name="card">移動するカード</param>
        /// <returns>問題が無い場合はtrue</returns>
        public static bool IsMovedFoundationNoProblem(this FreeCell freeCell, Card card)
            => freeCell.CanMoveFoundation(card) && (
                card.Rank == Rank.Ace || card.Rank == Rank.Two ||
                freeCell.Where(pair => pair.Key.Rank == card.Rank.Down()).All(pair => pair.Value is Foundation));

    }
}
