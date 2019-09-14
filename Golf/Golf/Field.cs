

namespace Net.Sh_Lab.PlayingCards.Golf
{
    /// <summary>
    /// 場札 7列5枚の位置を表す。
    /// </summary>
    public struct Field :IPosition
    {
        /// <summary>
        /// 列
        /// </summary>
        public Lane Lane
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

        public Field(Lane lane, int number)
        {
            Lane = lane;
            Number = number;
        }
    }
}
