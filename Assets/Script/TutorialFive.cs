using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFive : MonoBehaviour
{
    // Start is called before the first frame update
    public void GetStarted()
    {
        SceneManager.LoadScene("City_Level");
        PlayerPrefs.SetInt("CityTutorialFinished", 1);

    }

}
