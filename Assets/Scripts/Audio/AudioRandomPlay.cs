using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlay : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public List<AudioClip> audioClipsList;
    public AudioSource audioSource;
    #endregion

    #region Methods

    // *AudioRandomPlay explanation*
    // We use the AudioRandomPlay for cases where we want to play random sounds for a list, giving a more natural feel to the game.

    public void PlayRandom()
    {
        audioSource.clip = audioClipsList[Random.Range(0, audioClipsList.Count)];
        audioSource.Play();
    }
    #endregion
}
