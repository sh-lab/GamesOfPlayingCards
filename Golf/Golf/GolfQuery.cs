using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Golf
{
    /// <summary>
    /// Golfのクエリ
    /// Golfから得たい情報がある場合はこのクラスに実装する。
    /// </summary>
    public static class GolfQuery
    {
        /// <summary>
        /// 残りの山札の数
        /// </summary>
        /// <param name="golf"></param>
        /// <returns></returns>
        public static int DeckCount(this Golf golf) => golf.Count(pair => pair.Value is Deck);

        /// <summary>
        /// ゲームに勝利したか？
        /// </summary>
        /// <param name="golf"></param>
        /// <returns></returns>
        public static bool IsWin(this Golf golf) => golf.Count(pair => pair.Value is Field) == 0;


        /// <summary>
        /// ゲームに敗北したか？
        /// </summary>
        /// <param name="golf"></param>
        /// <returns></returns>
        public static bool IsLose(this Golf golf) => golf.Count(pair => golf.CanMoveToHand(pair.Key)) == 0 && !golf.IsWin();

    }
}
