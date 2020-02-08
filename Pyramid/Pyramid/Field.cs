using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Pyramid
{
    /// <summary>
    /// 場札
    /// </summary>
    public class Field : IPosition
    {

        public static int RowMin => 0;
        public static int RowMaxCount => 7;

        /// <summary>
        ///  列 0から6
        /// </summary>
        public int Row
        {
            get;
            private set;
        }

        /// <summary>
        /// 列の中の位置 0(左)～列の番号(右)
        /// </summary>
        public int Number
        {
            get;
            private set;
        }

        public Field (int row, int number)
        {
            if(row < RowMin && row > RowMaxCount)
            {
                throw new ArgumentException();
            }

            if (number < 0 && number >= row)
            {
                throw new ArgumentException();
            }

            Row = row;
            Number = number;
        }
    }
}
