using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoin : ItemCollectibleBase
{
    #region Variables
    [Header("ItemCollectibleCoinEspecial variables")]
    public SOInt coinValue;
    #endregion

    #region Methods

    // *ItemCollectibleCoin explanation*
    // The ideia is that the ItemCollectibleCoin script will inherit the ItemCollectibleBase and override it's methods to their own need.
    // In this case we just use the 3 methods to track the coins
    // The method AddCoins from the ItemCollectibleBase with the SO parameter.
    // The method UpdateCoinsText from the UIInGameManager to update the text in the screen.
    // The method PlayCoinSound from the AudioManager to play the coin sound.

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(coinValue.value);
        UIInGameManager.Instance.UpdateCoinsText();
        AudioManager.Instance.PlayCoinSound();
    }
    #endregion
}
