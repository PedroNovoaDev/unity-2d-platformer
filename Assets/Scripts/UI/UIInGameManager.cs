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
    public SOInt playerCoins;
    public GameObject playerDeathScreen;
    public GameObject pauseScreen;
    #endregion

    #region Methods

    // *UIInGameManager explanation*
    // The idea is that the UIInGameManager to be a Singleton.
    // It'll be used to updated the elements of the UI.

    public void UpdateCoinsText()
    {
        Instance.uiCoinsText.text = playerCoins.value.ToString();
    }

    public void TooglePlayerDeathScreen(bool state)
    {
        playerDeathScreen.SetActive(state);
    }

    public void TooglePauseScreen(bool state)
    {
        pauseScreen.SetActive(state);
    }
    #endregion
}
