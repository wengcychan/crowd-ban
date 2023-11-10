using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public int music;

    void Awake()
	{
        if (instance == null)
            instance = this;
        else
		{
            Destroy(gameObject);
            return;
		}
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
		{
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        music = PlayerPrefs.GetInt("Music", 0);
    }

    void Start()
	{
        if (music == 0)
            Play("Theme");
	}

    public void StopPlay(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Stop();
    }

    public void Play (string name)
	{
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
	}

    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.PlayOneShot(s.clip);
    }
}
