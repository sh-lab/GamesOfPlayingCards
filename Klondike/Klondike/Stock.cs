using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    /// <summary>
    /// 山札
    /// </summary>
    public class Stock : IPosition
    {
        public int Number
        {
            get;
            private set;
        }

        public Stock(int number)
        {
            Number = number;
        }
    }
}
