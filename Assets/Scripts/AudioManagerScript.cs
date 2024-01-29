using System;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManagerScript instance;
    public int musicSelection = 1;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
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
        Play("ElectronicMusic");
        musicSelection = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            musicSelection++;
            if (musicSelection == 4)
            {
                musicSelection = 1;
            }
            UpdateMusic();
        }
    }

    void UpdateMusic()
    {
        if (musicSelection == 1)
        {
            StopOldMusic("ElectronicMusic3");
            Play("ElectronicMusic");
        }
        else if (musicSelection == 2)
        {
            StopOldMusic("ElectronicMusic");
            Play("ElectronicMusic2");
        }
        else if (musicSelection == 3)
        {
            StopOldMusic("ElectronicMusic2");
            Play("ElectronicMusic3");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void StopOldMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
