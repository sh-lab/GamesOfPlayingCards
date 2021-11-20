using System;
namespace Net.Sh_Lab.PlayingCards.FreeCell
{
    /// <summary>
    /// セル
    /// </summary>
    public class Cell : IPosition
    {

        public static readonly Cell First = new Cell();
        public static readonly Cell Second = new Cell();
        public static readonly Cell Third = new Cell();
        public static readonly Cell Fourth = new Cell();

        /// <summary>
        /// セルの一覧
        /// </summary>
        public static readonly Cell[] Cells =
        {
            First,Second,Third,Fourth
        };

        private Cell()
        {

        }
    }
}
