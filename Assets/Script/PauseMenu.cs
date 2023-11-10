using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject musicButtonOn;
    public GameObject musicButtonOff;
    public GameObject soundButtonOn;
    public GameObject soundButtonOff;
    public GameObject pauseMenuUI;
    public int music;
    public int sound;

    void Start()
    {
        music = PlayerPrefs.GetInt("Music", 0);
        sound = PlayerPrefs.GetInt("Sound", 0);

        if (music == 0)
        {
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }

        if (music == 1)
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }

        if (sound == 0)
        {
            soundButtonOn.SetActive(true);
            soundButtonOff.SetActive(false);
        }

        if (sound == 1)
        {
            soundButtonOn.SetActive(false);
            soundButtonOff.SetActive(true);
        }
    }

    public void Resume()
	{
        pauseMenuUI.SetActive(false);
        if (PlayerPrefs.GetInt("Fastforward", 0) == 0)
            Time.timeScale = 1f;
        else if (PlayerPrefs.GetInt("Fastforward", 0) == 1)
            Time.timeScale = 2f;
        StartCoroutine(Tap());
    }

    public void Pause()
	{
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
	}

    public void LoadMenu()
	{
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
	}

    public void MusicOn()
    {
        musicButtonOn.SetActive(true);
        musicButtonOff.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Theme");
        PlayerPrefs.SetInt("Music", 0);
    }

    public void MusicOff()
    {
        musicButtonOn.SetActive(false);
        musicButtonOff.SetActive(true);
        FindObjectOfType<AudioManager>().StopPlay("Theme");
        PlayerPrefs.SetInt("Music", 1);
    }

    public void SoundOn()
    {
        soundButtonOn.SetActive(true);
        soundButtonOff.SetActive(false);
        PlayerPrefs.SetInt("Sound", 0);
    }

    public void SoundOff()
    {
        soundButtonOn.SetActive(false);
        soundButtonOff.SetActive(true);
        PlayerPrefs.SetInt("Sound", 1);
    }

    public IEnumerator Tap()
    {
        yield return new WaitForSeconds(0.0f);
        GameIsPaused = false;
    }
}
