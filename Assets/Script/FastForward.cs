using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FastForward : MonoBehaviour
{
    public TextMeshProUGUI twoTimes;

    void Start()
    {
        PlayerPrefs.SetInt("Fastforward", 0);
        Time.timeScale = 1f;
    }

    public void ClickFastForward()
    {
        if(PlayerPrefs.GetInt("Fastforward", 0) == 0)
		{
            Time.timeScale = 2f;
            twoTimes.enabled = true;
            PlayerPrefs.SetInt("Fastforward", 1);
        }

        else if (PlayerPrefs.GetInt("Fastforward", 0) == 1)
        {
            Time.timeScale = 1f;
            twoTimes.enabled = false;
            PlayerPrefs.SetInt("Fastforward", 0);
        }
    }
}
