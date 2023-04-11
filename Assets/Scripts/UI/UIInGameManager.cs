using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    #region Variables
    [Header("Variables")]
    public TextMeshProUGUI uiCoinsText;
    #endregion

    #region Methods

    // *Item Manager explanation*
    // The idea is that the Item Manager to be a Singleton.
    // We'll call it to update all our UI objects, for example the coins.
    // By declaring the method static we eliminate the need to call the Instance in the other class.

    public static void UpdateCoinsText(string s)
    {
        Instance.uiCoinsText.text = s;
    }
    #endregion
}
