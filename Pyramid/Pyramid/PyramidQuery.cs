using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Pyramid
{
    /// <summary>
    /// Pyramidのクエリ
    /// Pyramidから得たい情報がある場合はこのクラスに実装する。
    /// </summary>
    public static class PyramidQuery
    {
        /// <summary>
        /// 山札の枚数
        /// </summary>
        /// <param name="pyramid"></param>
        /// <returns></returns>
        public static int DeckCount(this Pyramid pyramid) => pyramid.Count(pair => pair.Value is Deck);

        /// <summary>
        /// ゲームに勝利したか
        /// </summary>
        /// <param name="pyramid"></param>
        /// <returns></returns>
        public static bool IsWin(this Pyramid pyramid) => !pyramid.Any(pair => pair.Value is Field);
    }
}
