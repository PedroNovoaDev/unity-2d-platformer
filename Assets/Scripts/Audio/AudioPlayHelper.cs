using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    #region Variables
    public KeyCode keyCode = KeyCode.P;
    public AudioSource audioSource;
    #endregion

    #region Methods

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
            Play();
    }

    private void Play()
    {
        audioSource.Play();
    }
    #endregion
}
