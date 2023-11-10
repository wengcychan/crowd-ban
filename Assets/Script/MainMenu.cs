using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int coin;
    string coinText;
    public TextMeshProUGUI coinValue;
    // public GameObject islandLock;
    // public GameObject spaceLock;
    // public GameObject bubbleLock;
    // public GameObject islandUnlockMenu;
    // public GameObject spaceUnlockMenu;
    // public GameObject bubbleUnlockMenu;

    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);

        if (coin < 10)
        {
            coinText = "000000" + coin;
        }

        else if (coin >= 10 && coin < 100)
        {
            coinText = "00000" + coin;
        }

        else if (coin >= 100 && coin < 1000)
        {
            coinText = "0000" + coin;
        }

        else if (coin >= 1000 && coin < 10000)
        {
            coinText = "000" + coin;
        }


        else if (coin >= 10000 && coin < 100000)
        {
            coinText = "00" + coin;
        }

        else if (coin >= 100000 && coin < 1000000)
        {
            coinText = "0" + coin;
        }

        else if (coin < 10000000)
        {
            coinText = coin.ToString();
        }

        else if (coin >= 10000000)
        {
            coinText = "9999999";
        }

        coinValue.SetText(coinText);

        // if (PlayerPrefs.GetInt("IslandLevelOpen", 0) == 1)
		// {
        //     islandLock.SetActive(false);
        // }

        // if (PlayerPrefs.GetInt("SapceLevelOpen", 0) == 1)
        // {
        //     spaceLock.SetActive(false);
        // }

        // if (PlayerPrefs.GetInt("BubbleLevelOpen", 0) == 1)
        // {
        //     bubbleLock.SetActive(false);
        // }
    }

    public void CityLevel()
	{
        int cityTutorialFinishedFlag = PlayerPrefs.GetInt("CityTutorialFinished", 0);

        if (cityTutorialFinishedFlag == 0)
        {
            SceneManager.LoadScene("Tutorial-1");
        }
        else
        {
            SceneManager.LoadScene("City_Level");
        }
	}

    public void IslandLevel()
    {
        int islandTutorialFinishedFlag = PlayerPrefs.GetInt("IslandTutorialFinished", 0);
        // int islandOpenFlag = PlayerPrefs.GetInt("IslandLevelOpen", 0);

        // if (islandOpenFlag == 0)
        // {
        //     islandUnlockMenu.SetActive(true);
        // }
        // else if (islandOpenFlag == 1)
		// {
            if (islandTutorialFinishedFlag == 0)
            {
                SceneManager.LoadScene("Tutorial_Island");
            }
            else
            {
                SceneManager.LoadScene("Island_Level");
            }
        // }
    }

    public void SpaceLevel()
    {
        int spaceTutorialFinishedFlag = PlayerPrefs.GetInt("SpaceTutorialFinished", 0);
        // int spaceOpenFlag = PlayerPrefs.GetInt("SapceLevelOpen", 0);

        // if (spaceOpenFlag == 0)
        // {
        //     spaceUnlockMenu.SetActive(true);
        // }
        // else if (spaceOpenFlag == 1)
        // {
            if (spaceTutorialFinishedFlag == 0)
            {
                SceneManager.LoadScene("Tutorial_Space");
            }
            else
            {
                SceneManager.LoadScene("Space_Level");
            }
        // }
    }

    public void BubbleLevel()
    {
        int bubbleTutorialFinishedFlag = PlayerPrefs.GetInt("BubbleTutorialFinished", 0);
        // int bubbleOpenFlag = PlayerPrefs.GetInt("BubbleLevelOpen", 0);

        // if (bubbleOpenFlag == 0)
        // {
        //     bubbleUnlockMenu.SetActive(true);
        // }
        // else if (bubbleOpenFlag == 1)
        // {
            if (bubbleTutorialFinishedFlag == 0)
            {
                SceneManager.LoadScene("Tutorial_Bubble");
            }
            else
            {
                SceneManager.LoadScene("Bubble_Level");
            }
        // }
    }
}
