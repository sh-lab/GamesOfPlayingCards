using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    public class WastePile : IPosition
    {
        /// <summary>
        /// 位置　大きいほうが上
        /// </summary>
        public int Number
        {
            get;
            private set;
        }

        public WastePile(int number)
        {
            Number = number;
        }
    }
}
