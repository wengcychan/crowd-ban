using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpFive : MonoBehaviour
{
    public void GotIt()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
