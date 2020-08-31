using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    public static class KlondikeQuery
    {
        /// <summary>
        /// 残り山札枚数
        /// </summary>
        /// <param name="klondike"></param>
        /// <returns></returns>
        public static int StockCount(this Klondike klondike) => klondike.Count(pair => pair.Value is Stock);

        /// <summary>
        /// *勝利* 組札に全て移動した
        /// </summary>
        /// <param name="klondike"></param>
        /// <returns></returns>
        public static bool IsWin(this Klondike klondike) => klondike.All(pair => pair.Value is Foundation);

        /// <summary>
        /// 勝利目前 全てのカードが組札か、タブローで表
        /// </summary>
        /// <param name="klondike"></param>
        /// <returns></returns>
        public static bool IsPreWin(this Klondike klondike) => klondike.All(pair => pair.Value is Foundation || (pair.Value is Tableau tableau && tableau.Open));
    }
}
