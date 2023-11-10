using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Bubble : MonoBehaviour
{
    public void GetStarted()
    {
        SceneManager.LoadScene("Bubble_Level");
        PlayerPrefs.SetInt("BubbleTutorialFinished", 1);

    }
}
