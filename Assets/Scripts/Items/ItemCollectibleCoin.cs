using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoin : ItemCollectibleBase
{

    #region Methods

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
    #endregion
}
