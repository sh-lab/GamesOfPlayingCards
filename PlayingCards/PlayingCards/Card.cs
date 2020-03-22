using System;

namespace Net.Sh_Lab.PlayingCards
{
    /// <summary>
    /// カード
    /// </summary>
    public struct Card : IComparable<Card>
    {

        private int _value;

        /// <summary>
        /// Id
        /// </summary>
        public CardId Id => (CardId)_value;

        /// <summary>
        /// ランク
        /// </summary>
        public Rank Rank => IsJoker ? Rank.None : (Rank)(_value & 0x0F);

        /// <summary>
        /// 絵柄
        /// </summary>
        public Suit Suit => IsJoker ? Suit.None : (Suit)(_value & 0xF0);


        // カードがJokerかどうか
        public bool IsJoker => Id == CardId.Joker || Id == CardId.ExtraJoker;

        private Card(CardId id)
        {
            _value = (int)id;
        }


        // 各カードの定義
        public static readonly Card Joker = new Card(CardId.Joker);
        public static readonly Card ExtraJoker = new Card(CardId.ExtraJoker);

        public static readonly Card AceOfSpades = new Card(CardId.AceOfSpades);
        public static readonly Card TwoOfSpades = new Card(CardId.TwoOfSpades);
        public static readonly Card ThreeOfSpades = new Card(CardId.ThreeOfSpades);
        public static readonly Card FourOfSpades = new Card(CardId.FourOfSpades);
        public static readonly Card FiveOfSpades = new Card(CardId.FiveOfSpades);
        public static readonly Card SixOfSpades = new Card(CardId.SixOfSpades);
        public static readonly Card SevenOfSpades = new Card(CardId.SevenOfSpades);
        public static readonly Card EightOfSpades = new Card(CardId.EightOfSpades);
        public static readonly Card NineOfSpades = new Card(CardId.NineOfSpades);
        public static readonly Card TenOfSpades = new Card(CardId.TenOfSpades);
        public static readonly Card JackOfSpades = new Card(CardId.JackOfSpades);
        public static readonly Card QueenOfSpades = new Card(CardId.QueenOfSpades);
        public static readonly Card KingOfSpades = new Card(CardId.KingOfSpades);

        public static readonly Card AceOfHearts = new Card(CardId.AceOfHearts);
        public static readonly Card TwoOfHearts = new Card(CardId.TwoOfHearts);
        public static readonly Card ThreeOfHearts = new Card(CardId.ThreeOfHearts);
        public static readonly Card FourOfHearts = new Card(CardId.FourOfHearts);
        public static readonly Card FiveOfHearts = new Card(CardId.FiveOfHearts);
        public static readonly Card SixOfHearts = new Card(CardId.SixOfHearts);
        public static readonly Card SevenOfHearts = new Card(CardId.SevenOfHearts);
        public static readonly Card EightOfHearts = new Card(CardId.EightOfHearts);
        public static readonly Card NineOfHearts = new Card(CardId.NineOfHearts);
        public static readonly Card TenOfHearts = new Card(CardId.TenOfHearts);
        public static readonly Card JackOfHearts = new Card(CardId.JackOfHearts);
        public static readonly Card QueenOfHearts = new Card(CardId.QueenOfHearts);
        public static readonly Card KingOfHearts = new Card(CardId.KingOfHearts);

        public static readonly Card AceOfDiamonds = new Card(CardId.AceOfDiamonds);
        public static readonly Card TwoOfDiamonds = new Card(CardId.TwoOfDiamonds);
        public static readonly Card ThreeOfDiamonds = new Card(CardId.ThreeOfDiamonds);
        public static readonly Card FourOfDiamonds = new Card(CardId.FourOfDiamonds);
        public static readonly Card FiveOfDiamonds = new Card(CardId.FiveOfDiamonds);
        public static readonly Card SixOfDiamonds = new Card(CardId.SixOfDiamonds);
        public static readonly Card SevenOfDiamonds = new Card(CardId.SevenOfDiamonds);
        public static readonly Card EightOfDiamonds = new Card(CardId.EightOfDiamonds);
        public static readonly Card NineOfDiamonds = new Card(CardId.NineOfDiamonds);
        public static readonly Card TenOfDiamonds = new Card(CardId.TenOfDiamonds);
        public static readonly Card JackOfDiamonds = new Card(CardId.JackOfDiamonds);
        public static readonly Card QueenOfDiamonds = new Card(CardId.QueenOfDiamonds);
        public static readonly Card KingOfDiamonds = new Card(CardId.KingOfDiamonds);

        public static readonly Card AceOfClubs = new Card(CardId.AceOfClubs);
        public static readonly Card TwoOfClubs = new Card(CardId.TwoOfClubs);
        public static readonly Card ThreeOfClubs = new Card(CardId.ThreeOfClubs);
        public static readonly Card FourOfClubs = new Card(CardId.FourOfClubs);
        public static readonly Card FiveOfClubs = new Card(CardId.FiveOfClubs);
        public static readonly Card SixOfClubs = new Card(CardId.SixOfClubs);
        public static readonly Card SevenOfClubs = new Card(CardId.SevenOfClubs);
        public static readonly Card EightOfClubs = new Card(CardId.EightOfClubs);
        public static readonly Card NineOfClubs = new Card(CardId.NineOfClubs);
        public static readonly Card TenOfClubs = new Card(CardId.TenOfClubs);
        public static readonly Card JackOfClubs = new Card(CardId.JackOfClubs);
        public static readonly Card QueenOfClubs = new Card(CardId.QueenOfClubs);
        public static readonly Card KingOfClubs = new Card(CardId.KingOfClubs);

        public int CompareTo(Card other)
        {
            return Id - other.Id;
        }
    }
}