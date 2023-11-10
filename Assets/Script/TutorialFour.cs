using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFour : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("Tutorial-5");

    }
}
