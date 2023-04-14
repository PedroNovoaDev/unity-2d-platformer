using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class AudioManager : Singleton<AudioManager>
{
    #region Variables
    [Header("Variables")]
    public AudioSource coinAudioSource;
    #endregion

    #region Methods

    public void PlayCoinSound()
    {
        coinAudioSource.Play();
    }
    #endregion
}
