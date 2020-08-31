using System;
namespace Net.Sh_Lab.PlayingCards.Calculation
{
    /// <summary>
    /// 組札
    /// </summary>
    public class Foundation : IPosition
    {
        /// <summary>
        /// 列
        /// </summary>
        public FoundationColumn Column
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        public Foundation(FoundationColumn column)
        {
            Column = column;
        }

    }

}
