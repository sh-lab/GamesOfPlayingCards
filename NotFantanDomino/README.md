# NotFantanDomino(七並べない)
Unity 1週間ゲームジャム お題「逆」に投稿したNotFantanDomino(七並べない)のライブラリです。

# ルール
* ジョーカーを抜いた52枚のトランプを用いて4人で遊ぶゲームです。
* ダイヤの7(♢7)を持っているプレーヤーから順番にカードを出していきます。
* 場に出ているカードの隣の番号のカードは出すことができません。
    * 連続している番号のカードはまとめてだすことができます。
* 全てのプレーヤーがカードを出せないとゲーム終了です。
* 最も手札の枚数が少ないプレーヤーが勝者です。
    * 手札の枚数が同じ場合、手札の合計値が少ないプレーヤーが勝者です。

# Usage(使い方)

```C#
	var notFantanDomino = NotFantanDominoGenerator.Generate();

    while (!notFantanDomino.IsEnd())
    {
        IList<Card> cards = PlayerSelected();

        if (notFantanDomino.CanRelease(cards))
        {
            notFantanDomino.Release(cards);
        }

    }
```

# その他
投稿したゲームはこちら

https://unityroom.com/games/notfantandomino