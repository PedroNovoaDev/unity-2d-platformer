using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoinEspecial : ItemCollectibleBase
{
    #region Variables
    [Header("ItemCollectibleCoinEspecial variables")]
    public SOInt coinEspecialValue;
    #endregion

    #region Methods

    // *ItemCollectibleCoinEspecial explanation*
    // The ideia is that the ItemCollectibleCoinEspecial script will inherit the ItemCollectibleBase and override it's methods to their own need.
    // Since this is a variant from the normal coin we just pass a different parameter of amount to the method AddCoins from the ItemManager singleton
    // The method AddCoins from the ItemCollectibleBase with the SO parameter.
    // The method UpdateCoinsText from the UIInGameManager to update the text in the screen.
    // The method PlayCoinSound from the AudioManager to play the coin sound.

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(coinEspecialValue.value);
        UIInGameManager.Instance.UpdateCoinsText();
        AudioManager.Instance.PlayCoinSound();
    }
    #endregion
}
