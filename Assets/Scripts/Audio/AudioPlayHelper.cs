using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
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
