using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    #region Variables
    [Header("Movement")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;

    [Header("Jump")]
    public float forceJump = 2;

    [Header("Jump Animation")]
    public float jumpScaleY = 1f;
    public float jumpAnimationDuration = 0.5f;
    public Ease ease = Ease.OutBack;

    [Header("Run Animation")]
    public string boolRun = "Run";
    public float playerSwipeDuration = .1f;

    [Header("Death Animation")]
    public string triggerDeath = "Death";
    #endregion
}
