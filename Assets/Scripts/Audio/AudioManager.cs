using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class AudioManager : Singleton<AudioManager>
{
    #region Variables
    [Header("Variables")]
    public AudioSource coinAudioSource;
    public AudioSource playerDeathAudioSource;
    #endregion

    #region Methods

    // *AudioManager explanation*
    // We use the AudioManager to control the audios of the game.
    // This way is easier in cases where we need to destroy or deactivate the game object and play a sound, for example the coin item.

    public void PlayCoinSound()
    {
        coinAudioSource.Play();
    }

    public void PlayPlayerDeathSound()
    {
        playerDeathAudioSource.Play();
    }
    #endregion
}
