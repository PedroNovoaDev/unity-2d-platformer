using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    #region Variables
    [Header("FlashColor variables")]
    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private Tween _currentTween;
    #endregion

    #region Methods

    // *FlashColor explanation*
    // The ideia is to have a script that will give the player a feedback about the damage he took.
    // For that we get all the sprite renderers from the player game object and animate their color to flash.

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();

        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {

        if (_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach (var s in spriteRenderers)
        {
            _currentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
    #endregion
}
