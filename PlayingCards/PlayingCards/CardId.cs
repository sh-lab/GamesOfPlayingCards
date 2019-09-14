using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards
{
    /// <summary>
    /// カードを一意に識別するID
    /// </summary>
    public enum CardId
    {
        Joker = 0xFF,
        ExtraJoker = 0xFE,

        AceOfSpades = 0x11,
        TwoOfSpades = 0x12,
        ThreeOfSpades = 0x13,
        FourOfSpades = 0x14,
        FiveOfSpades = 0x15,
        SixOfSpades = 0x16,
        SevenOfSpades = 0x17,
        EightOfSpades = 0x18,
        NineOfSpades = 0x19,
        TenOfSpades = 0x1A,
        JackOfSpades = 0x1B,
        QueenOfSpades = 0x1C,
        KingOfSpades = 0x1D,

        AceOfHearts = 0x21,
        TwoOfHearts = 0x22,
        ThreeOfHearts = 0x23,
        FourOfHearts = 0x24,
        FiveOfHearts = 0x25,
        SixOfHearts = 0x26,
        SevenOfHearts = 0x27,
        EightOfHearts = 0x28,
        NineOfHearts = 0x29,
        TenOfHearts = 0x2A,
        JackOfHearts = 0x2B,
        QueenOfHearts = 0x2C,
        KingOfHearts = 0x2D,

        AceOfDiamonds = 0x31,
        TwoOfDiamonds = 0x32,
        ThreeOfDiamonds = 0x33,
        FourOfDiamonds = 0x34,
        FiveOfDiamonds = 0x35,
        SixOfDiamonds = 0x36,
        SevenOfDiamonds = 0x37,
        EightOfDiamonds = 0x38,
        NineOfDiamonds = 0x39,
        TenOfDiamonds = 0x3A,
        JackOfDiamonds = 0x3B,
        QueenOfDiamonds = 0x3C,
        KingOfDiamonds = 0x3D,

        AceOfClubs = 0x41,
        TwoOfClubs = 0x42,
        ThreeOfClubs = 0x43,
        FourOfClubs = 0x44,
        FiveOfClubs = 0x45,
        SixOfClubs = 0x46,
        SevenOfClubs = 0x47,
        EightOfClubs = 0x48,
        NineOfClubs = 0x49,
        TenOfClubs = 0x4A,
        JackOfClubs = 0x4B,
        QueenOfClubs = 0x4C,
        KingOfClubs = 0x4D,
        
    }
}
