using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    /// <summary>
    /// タブロー
    /// </summary>
    public class Tableau : IPosition
    {
        /// <summary>
        /// 列
        /// </summary>
        public Column Column
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
        /// カードが表か？
        /// </summary>
        public bool Open
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
        public Tableau(Column column, int number, bool open)
        {
            Column = column;
            Number = number;
            Open = open;
        }

    }
}
