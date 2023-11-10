using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Space : MonoBehaviour
{
    public void GetStarted()
    {
        SceneManager.LoadScene("Space_Level");
        PlayerPrefs.SetInt("SpaceTutorialFinished", 1);

    }
}
