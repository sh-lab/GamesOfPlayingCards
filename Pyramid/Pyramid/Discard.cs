using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Pyramid
{
    /// <summary>
    /// 捨て札
    /// </summary>
    public class Discard : IPosition
    {
        public int Number
        {
            get;
            private set;
        }

        public Discard(int number)
        {
            Number = number;
        }
    }
}
