using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Island : MonoBehaviour
{
    public void GetStarted()
    {
        SceneManager.LoadScene("Island_Level");
        PlayerPrefs.SetInt("IslandTutorialFinished", 1);

    }
}
