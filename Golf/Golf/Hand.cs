using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Golf
{
    /// <summary>
    /// 手札
    /// </summary>
    public class Hand : IPosition
    {
        /// <summary>
        /// 位置 数が多きい方が上
        /// </summary>
        public int Number
        {
            get;
            private set;
        }

        public Hand(int number)
        {
            Number = number;
        }
    }
}
