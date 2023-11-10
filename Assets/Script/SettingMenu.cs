using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public GameObject musicButtonOn;
    public GameObject musicButtonOff;
    public GameObject soundButtonOn;
    public GameObject soundButtonOff;
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

    public void Help()
	{
        SceneManager.LoadScene("Help-1");
    }
}
