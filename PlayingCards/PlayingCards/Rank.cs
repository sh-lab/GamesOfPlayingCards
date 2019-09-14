using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards
{
    /// <summary>
    /// カードのRank
    /// A:1(0x01) ～ K:13(0x0D)
    /// ジョーカーは None(0x00)
    /// </summary>
    public enum Rank
    {
        None = 0x00,
        Ace = 0x01,
        Two = 0x02,
        Three = 0x03,
        Four = 0x04,
        Five = 0x05,
        Six = 0x06,
        Seven = 0x07,
        Eight = 0x08,
        Nine = 0x09,
        Ten = 0x0A,
        Jack = 0x0B,
        Queen = 0x0C,
        King = 0x0D
    }
}
