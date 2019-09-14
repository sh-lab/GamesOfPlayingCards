# PlayingCards
GamesOfPlayingCardsが対応している各ゲームで使用するPlayingCards(トランプ)を定義しているライブラリです。

カードを54種類の値を持つバリューオブジェクトとして定義しています。

# Usage(使い方)

```C#
    var cardList = CardListGenerator.GenerateDoubleJokerShuffledCardList();

    if (Card.AceOfSpades.Equals(cardList[0]))
    {
        Console.WriteLine("This Card is Ace of Spades");
    }
    else
    {
        Console.WriteLine("This Card is't Ace of Spades");
    }

```