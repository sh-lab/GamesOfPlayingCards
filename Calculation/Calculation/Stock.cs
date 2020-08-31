using System;
namespace Net.Sh_Lab.PlayingCards.Calculation
{
    /// <summary>
    /// 山札
    /// </summary>
    public class Stock : IPosition
    {
        /// <summary>
        /// 山札上の位置　大きい方が上
        /// </summary>
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
