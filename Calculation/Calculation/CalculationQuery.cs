using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Calculation
{
    /// <summary>
    /// Calculationのクエリ
    /// </summary>
    public static class CalculationQuery
    {
        /// <summary>
        /// 残り山札枚数
        /// </summary>
        /// <param name="klondike"></param>
        /// <returns></returns>
        public static int StockCount(this Calculation calculation) => calculation.Count(pair => pair.Value is Stock);



        /// <summary>
        /// *勝利* 組札に全て移動した
        /// </summary>
        /// <param name="klondike"></param>
        /// <returns></returns>
        public static bool IsWin(this Calculation calculation) => calculation.All(pair => pair.Value is Foundation);
    }
}
