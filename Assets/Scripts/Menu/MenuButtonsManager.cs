using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    #region Variables
    [Header("MenuButtonsManager variables")]
    public List<GameObject> buttons;

    [Header("Menu Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;
    #endregion

    #region Methods

    // *MenuButtonsManager explanation*
    // The ideia is that the buttons show one after the other popping in the screen.
    // At first we set the buttons scale to 0 and hide all of them.
    // Then we set one by one to active with the animation of scaling to 1.

    private void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }
    #endregion
}
