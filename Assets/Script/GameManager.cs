using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PathCreation.Examples;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI gameTime;
    float scoreAmount;
    float pointIncreasePerSecond;
    static public int score;
    string scoreText;
    SpwanAgent scriptOfAgent = null;
    SpwanCar scriptOfCar = null;
    SpwanSpaceship scriptOfSpaceship = null;
    public GameObject playTime;
    public GameObject pauseButton;
    public GameObject fastForwardButton;
    static public string sceneName;
    public float wanderingAISpeed;
    public float bubbleSpeed;
    public GameObject winCanvas;
    PickAgent scriptOfPick = null;

    void Awake()
    {
        if (Application.isMobilePlatform)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }

    void Start()
    {
        scoreAmount = 0f;
        pointIncreasePerSecond = 1f;
        Time.timeScale = 1;
        scriptOfAgent = GameObject.FindObjectOfType<SpwanAgent>();
        scriptOfCar = GameObject.FindObjectOfType<SpwanCar>();
        scriptOfSpaceship = GameObject.FindObjectOfType<SpwanSpaceship>();
        sceneName = SceneManager.GetActiveScene().name;
        wanderingAISpeed = 30f;
        bubbleSpeed = 50.0f;
        scriptOfPick = GameObject.FindObjectOfType<PickAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)scoreAmount;

        if (score < 10)
        {
            scoreText = "0000" + score;

        }
        else if (score >= 10 && score < 100)
        {

            scoreText = "000" + score;

            if (sceneName == "Bubble_Level")
            {
                if (score == 99)
                    bubbleSpeed = 100.0f;
            }
        }

        else if (score >= 100 && score < 1000)
        {
            scoreText = "00" + score;
            if (score > 200)
            {
                scriptOfAgent.doubleAgent = true;
                if (sceneName == "Bubble_Level")
                {
                    bubbleSpeed = 200.0f;
                }
            }

            if (score == 300)
            {
                wanderingAISpeed = 45f;
                scriptOfAgent.speed = 6f;
                if (sceneName == "City_Level" || sceneName == "Island_Level")
                    scriptOfCar.speed = 9f;
                else if (sceneName == "Space_Level")
                    scriptOfSpaceship.speed = 9f;
            }

            if (score == 500)
            {
                wanderingAISpeed = 60f;
                scriptOfAgent.speed = 8f;
                if (sceneName == "City_Level" || sceneName == "Island_Level")
                    scriptOfCar.speed = 12f;
                else if (sceneName == "Space_Level")
                    scriptOfSpaceship.speed = 12f;
            }
        }

        else if (score >= 1000 && score < 10000)
        {
            scoreText = "0" + score;
            if (sceneName == "Bubble_Level")
            {
                if (score == 1001)
                    bubbleSpeed = 500.0f;
            }

            if (score == 1001)
            {
                wanderingAISpeed = 75f;
                scriptOfAgent.speed = 10f;
                if (sceneName == "City_Level" || sceneName == "Island_Level")
                    scriptOfCar.speed = 15f;
                else if (sceneName == "Space_Level")
                    scriptOfSpaceship.speed = 15f;
            }


            if (score == 9999)
            {
                wanderingAISpeed = 90f;
                scriptOfAgent.speed = 12f;
                if (sceneName == "City_Level" || sceneName == "Island_Level")
                    scriptOfCar.speed = 18f;
                else if (sceneName == "Space_Level")
                    scriptOfSpaceship.speed = 18f;
            }
        }

        else if (score < 100000)
        {
            scoreText = score.ToString();
            if (sceneName == "Bubble_Level")
            {
                if (score == 100001)
                    bubbleSpeed = 800.0f;
            }
        }

        else if (score >= 100000)
        {
            scoreText = "99999";
            StartCoroutine(Win());

        }

        gameTime.SetText(scoreText);
        scoreAmount += pointIncreasePerSecond * Time.deltaTime;

    }

    public void GameOver()
    {
        SceneManager.LoadScene("ScoreMenu");
    }

    public IEnumerator Win()
    {
        Time.timeScale = 0;

        scriptOfPick.selected = true;

        winCanvas.SetActive(true);
        pauseButton.SetActive(false);
        playTime.SetActive(false);
        fastForwardButton.SetActive(false);
        yield return new WaitForSecondsRealtime(2.0f);
        GameOver();
    }
}
