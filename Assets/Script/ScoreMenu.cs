using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    int coin = 0;
    public GameObject backgroundCity;
    public GameObject backgroundIsland;
    public GameObject backgroundSpace;
    public GameObject backgroundBubble;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.sceneName == "City_Level")
		{
            backgroundCity.SetActive(true);
        }
        else if (GameManager.sceneName == "Island_Level")
        {
            backgroundIsland.SetActive(true);
        }

        else if (GameManager.sceneName == "Space_Level")
        {
            backgroundSpace.SetActive(true);
        }

        else if (GameManager.sceneName == "Bubble_Level")
        {
            backgroundBubble.SetActive(true);
        }
        else
        {
            backgroundCity.SetActive(true);
        }

        score.SetText(GameManager.score.ToString());

        if (GameManager.sceneName == "City_Level")
        {
            highScore.SetText(PlayerPrefs.GetInt("CityHighScore", 0).ToString());
            if (GameManager.score > PlayerPrefs.GetInt("CityHighScore", 0))
            {
                PlayerPrefs.SetInt("CityHighScore", GameManager.score);
                highScore.SetText(GameManager.score.ToString());
            }
        }

        else if (GameManager.sceneName == "Island_Level")
        {
            highScore.SetText(PlayerPrefs.GetInt("IslandHighScore", 0).ToString());
            if (GameManager.score > PlayerPrefs.GetInt("IslandHighScore", 0))
            {
                PlayerPrefs.SetInt("IslandHighScore", GameManager.score);
                highScore.SetText(GameManager.score.ToString());
            }
        }

        else if (GameManager.sceneName == "Space_Level")
        {
            highScore.SetText(PlayerPrefs.GetInt("SpaceHighScore", 0).ToString());
            if (GameManager.score > PlayerPrefs.GetInt("SpaceHighScore", 0))
            {
                PlayerPrefs.SetInt("SpaceHighScore", GameManager.score);
                highScore.SetText(GameManager.score.ToString());
            }
        }

        else if (GameManager.sceneName == "Bubble_Level")
        {
            highScore.SetText(PlayerPrefs.GetInt("BubbleHighScore", 0).ToString());
            if (GameManager.score > PlayerPrefs.GetInt("BubbleHighScore", 0))
            {
                PlayerPrefs.SetInt("BubbleHighScore", GameManager.score);
                highScore.SetText(GameManager.score.ToString());
            }
        }

        else
        {
            highScore.SetText(PlayerPrefs.GetInt("CityHighScore", 0).ToString());
            if (GameManager.score > PlayerPrefs.GetInt("CityHighScore", 0))
            {
                PlayerPrefs.SetInt("CityHighScore", GameManager.score);
                highScore.SetText(GameManager.score.ToString());
            }
        }

        coin = GameManager.score + PlayerPrefs.GetInt("Coin", 0);
        PlayerPrefs.SetInt("Coin", coin);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RetryGame()
    {
        if (GameManager.sceneName == "City_Level")
        {
            SceneManager.LoadScene("City_Level");
        }
        else if (GameManager.sceneName == "Island_Level")
        {
            SceneManager.LoadScene("Island_Level");
        }
        else if (GameManager.sceneName == "Space_Level")
        {
            SceneManager.LoadScene("Space_Level");
        }
        else if (GameManager.sceneName == "Bubble_Level")
        {
            SceneManager.LoadScene("Bubble_Level");
        }
        else
        {
            SceneManager.LoadScene("City_Level");
        }
    }

    public void MainMeun()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
