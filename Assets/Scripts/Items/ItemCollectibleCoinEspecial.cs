using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoinEspecial : ItemCollectibleBase
{
    #region Variables
    [Header("Variables")]
    public SOInt coins;
    public int especialCoin = 3;
    #endregion

    #region Methods

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(especialCoin);
    }
    #endregion
}
