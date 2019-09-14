using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Sh_Lab.PlayingCards.Golf
{
    /// <summary>
    /// 初期配置のGolf生成用のクラス
    /// </summary>
    public static class GolfGenerator
    {
        /// <summary>
        /// ジョーカーなしのGolfを生成
        /// </summary>
        /// <param name="canLoop">AとK(13)の間で行き来できるか。</param>
        /// <returns>生成したGolf</returns>
        public static Golf GenerateNoJokerGolf(bool canLoop)
        {
            return GenerateGolf(CardListGenerator.GenerateNoJokerShuffledCardList(), canLoop);
        }

        /// <summary>
        /// ジョーカー1枚のGolfを生成
        /// </summary>
        /// <param name="canLoop">AとK(13)の間で行き来できるか。</param>
        /// <returns>生成したGolf</returns>
        public static Golf GenerateSingleJokerGolf(bool canLoop)
        {
            return GenerateGolf(CardListGenerator.GenerateSingleJokerShuffledCardList(), canLoop);
        }

        /// <summary>
        /// ジョーカー2枚のGolfを生成
        /// </summary>
        /// <param name="canLoop">AとK(13)の間で行き来できるか。</param>
        /// <returns>生成したGolf</returns>
        public static Golf GenerateDoubleJokerGolf(bool canLoop)
        {
            return GenerateGolf(CardListGenerator.GenerateDoubleJokerShuffledCardList(), canLoop);
        }


        /// <summary>
        /// 引数のカードの順に手札(1枚)⇒場札(7列×5枚)⇒山札(残り)に配置したGolfを生成します。
        /// </summary>
        /// <param name="cardList">カードのリスト</param>
        /// <returns>生成したGolfのオブジェクト</returns>
        private static Golf GenerateGolf(IList<Card> cardList, bool canLoop)
        {
            var dictionary = new Dictionary<Card, IPosition>();

            var cardListIndex = 0;

            // 手札
            dictionary.Add(cardList[cardListIndex++], new Hand(0));

            // 場札
            foreach (Lane lane in Enum.GetValues(typeof(Lane)))
            {

                for (int i = 0; i < 5; i++)
                {
                    dictionary.Add(cardList[cardListIndex++], new Field(lane, i));
                }
            }

            // 残りは山札
            for (int i = 0; cardListIndex < cardList.Count; i++)
            {
                dictionary.Add(cardList[cardListIndex++], new Deck(i));
            }

            return new Golf(dictionary, canLoop);
        }

    }
}
