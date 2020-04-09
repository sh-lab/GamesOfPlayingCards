using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.NotFantanDomino
{
    public static class NotFantanDominoQuery
    {
        public static bool IsEnd(this NotFantanDomino notFantanDomino) => 
            !notFantanDomino.Where(pair => pair.Value != Position.Field)
            .Select(pair => new List<Card>() { pair.Key })
            .Any(card => notFantanDomino.CanRelease(card));

        public static IDictionary<PlayerNumber, (int, int)> ScoreDictionary(this NotFantanDomino notFantanDomino)
        {
            var scoreDictionary = new Dictionary<PlayerNumber, (int, int)>();

            foreach(PlayerNumber playerNumber in Enum.GetValues(typeof(PlayerNumber)))
            {
                var cards = notFantanDomino.Where(pair => (PlayerNumber)pair.Value == playerNumber).Select(pair => pair.Key);

                scoreDictionary.Add(playerNumber, (cards.Count(), cards.Sum(card => (int)card.Rank)));
            }

            return scoreDictionary;
        }
    }
}
