using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static SoundsManager instance;

    private string currentScene;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
                return;
        }

        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Update()
    {
        if (currentScene != SceneManager.GetActiveScene().name)
        {
            Start();
        }
    }
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (SceneManager.GetActiveScene().name == "mainMenu")
        {
            Play("Menu Music");
        }
        else if(SceneManager.GetActiveScene().name == "endMenu")
        {
            Play("EndLevel Music");
        }
        else
        {
            Play("BG Music");
        }
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) 
        {
            Debug.LogWarning("Sound:" + name + "not found");
            return;
        }
        s.source.Play();
    }
}
