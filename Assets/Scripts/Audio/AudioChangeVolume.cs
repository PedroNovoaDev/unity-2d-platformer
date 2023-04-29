using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public AudioMixer audioGroup;
    public string floatParam = "MyExposedParam";
    #endregion

    #region Methods

    public void ChangeVolume(float f)
    {
        audioGroup.SetFloat(floatParam, f);
    }
    #endregion
}
