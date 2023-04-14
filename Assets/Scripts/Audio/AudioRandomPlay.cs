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

    public void PlayRandom()
    {
        audioSource.clip = audioClipsList[Random.Range(0, audioClipsList.Count)];
        audioSource.Play();
    }
    #endregion
}
