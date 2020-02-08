# Pyramid
ピラミッドのライブラリです。

# Usage(使い方)

```C#
	// ゲームの生成
    var pyramid = PyramidGenerator.GeneratePyramid();

	// 選択した2枚のカードをリムーブ
    Card card1 = PlayerSelected();
	Card card2 = PlayerSelected();
	
	if (Pyramid.CanRemove(card1, card2)) 
	{
		Pyramid.Remove(card1,card2)
	}

	// 他は気が向いたら書く。
```