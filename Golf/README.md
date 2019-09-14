# Golf
ゴルフのライブラリです。

# Usage(使い方)

```C#
    var golf = GolfGenerator.GenerateDoubleJokerGolf(true);

    while (!golf.IsLose())
    {
        Card card = PlayerSelected();

        if (golf.CanMoveToHand(card))
        {
            golf.MoveToHand(card);
        }

        if (golf.IsWin())
        {
            Console.WriteLine("Win");
            return;
        }
    }

    Console.WriteLine("Lose");
```