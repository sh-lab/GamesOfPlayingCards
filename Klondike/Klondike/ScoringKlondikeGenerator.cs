using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    public static class ScoringKlondikeGenerator
    {
        public static ScoringKlondike Generate()
        {
            return new ScoringKlondike(new Dictionary<Card, IPosition>(KlondikeGenerator.Generate()));
        }
    }
}
