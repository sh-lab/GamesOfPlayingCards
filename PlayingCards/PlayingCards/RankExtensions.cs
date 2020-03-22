using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards
{
    public static class RankExtensions
    {
        public static Rank? Up(this Rank rank, bool canLoop = false) => rank == Rank.King ? canLoop ? Rank.Ace : (Rank?)null : rank + 1;

        public static Rank? Down(this Rank rank, bool canLoop = false) => rank == Rank.Ace ? canLoop ? Rank.King : (Rank?)null : rank - 1;

    }
}

