using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialOne : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("Tutorial-2");

    }

}
