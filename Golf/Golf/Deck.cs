using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Golf
{
    /// <summary>
    /// 山札
    /// </summary>
    public class Deck : IPosition
    {
        public int Number
        {
            get;
            private set;
        }

        public Deck(int number)
        {
            Number = number;
        }
    }
}
