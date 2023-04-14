using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class AudioManager : Singleton<AudioManager>
{
    #region Variables
    [Header("Variables")]
    public AudioSource coinAudioSource;
    public AudioSource footstepAudioSource;
    #endregion

    #region Methods

    public void PlayCoinSound()
    {
        coinAudioSource.Play();
    }

    public void PlayFootstepSound()
    {
        footstepAudioSource.Play();
    }
    #endregion
}
