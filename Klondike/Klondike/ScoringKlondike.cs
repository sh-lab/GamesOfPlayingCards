using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Klondike
{
    /// <summary>
    /// 得点機能付クロンダイク
    /// </summary>
    public class ScoringKlondike : Klondike
    {
        public int Score;

        public ScoringKlondike(IDictionary<Card, IPosition> dictionary, int score = 0) : base(dictionary)
        {
            Score = score;
        }

        public new void Open(Card card)
        {

            base.Open(card);

            Score += 5;

        }

        public new void MoveFundation(Card card)
        {

            base.MoveFundation(card);

            Score += 10;

        }

        public new void MoveTableau(Card card, Column column)
        {
            var pos = this[card];

            base.MoveTableau(card, column);

            if (pos is Foundation)
            {
                Score -= 20;
            }
            else if (pos is WastePile)
            {
                Score += 5;
            }
        }

        public new void Redeal()
        {
            base.Redeal();

            Score -= 20;

            if (Score < 0)
            {
                Score = 0;
            }
        }

    }
}
