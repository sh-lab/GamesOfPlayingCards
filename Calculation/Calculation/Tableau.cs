using System;
namespace Net.Sh_Lab.PlayingCards.Calculation
{
    /// <summary>
    /// 場札
    /// </summary>
    public class Tableau : IPosition
    {
        /// <summary>
        /// 列
        /// </summary>
        public TableaColumn Column
        {
            get;
            private set;
        }

        /// <summary>
        /// 列上の位置　大きいほうが上
        /// </summary>
        public int Number
        {
            get;
            private set;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="number">列上の位置　大きいほうが上</param>
        /// <param name="open">カードの表裏</param>
        public Tableau(TableaColumn column, int number)
        {
            Column = column;
            Number = number;
        }
    }
}
