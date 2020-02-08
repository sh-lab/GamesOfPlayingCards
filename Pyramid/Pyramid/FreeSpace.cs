using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Pyramid
{
    /// <summary>
    /// 自由置き場（ジョーカーを置く）
    /// </summary>
    public class FreeSpace : IPosition
    {
        public int Number
        {
            get;
            private set;
        }

        public FreeSpace(int number)
        {
            Number = number;
        }
    }
}
