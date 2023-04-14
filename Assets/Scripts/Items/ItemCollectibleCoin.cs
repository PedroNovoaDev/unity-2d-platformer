using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoin : ItemCollectibleBase
{
    #region Methods

    // *Coin explanation*
    // The ideia is that the coin script will inherit the ItemCollectibleBase and override it's methods to their own need.
    // In this case we just use the method AddCoins from the ItemManager singleton.

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
    #endregion
}
