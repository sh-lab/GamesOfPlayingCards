namespace Net.Sh_Lab.PlayingCards
{
    /// <summary>
    /// トランプの絵柄
    /// スペード(0x10)～ハート～ダイア～クラブ(0x40)
    /// ジョーカーは None(0x00)
    /// </summary>
    public enum Suit
    {
        None = 0x00,
        Spades = 0x10,
        Hearts = 0x20,
        Diamonds = 0x30,
        Clubs = 0x40

    }
}
