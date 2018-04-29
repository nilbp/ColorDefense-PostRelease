using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {

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
    }

	void Start()
	{
		Play("Tema1");
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Can't find the sound");
            return;
        }
        s.source.Play();
    }
	public void Stop(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.Log("Can't find the sound");
			return;
		}
		s.source.Stop();
	}

    /*public void PlayDelayTub(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Can't find the sound");
            return;
        }
        s.source.PlayDelayed(0.888f);
    }

    public void PlayDelaySpray(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Can't find the sound");
            return;
        }
        s.source.PlayDelayed(0.313f);
    }*/

    //On vulguis cridar l'audio: FindObjectOfType<AudioManager>().Play("Com es digui el audio");
}
