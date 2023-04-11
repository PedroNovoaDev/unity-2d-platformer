using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;
    #endregion

    #region Methods

    private void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    private void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
    #endregion
}
