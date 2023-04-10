using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    #region Methods

    // *Load Scene explanation*
    // The ideia is that we can reutilize the script in different ways to load a new scene.
    // To do that we use 2 equal methods that receive different parameters.
    // Like that we can add the script to the button that'll do the action and pass the parameters in Unity inspector.

    private void Load(int i)
    {
        SceneManager.LoadScene(i);
    }

    private void Load(string s)
    {
        SceneManager.LoadScene(s);
    }
    #endregion
}
