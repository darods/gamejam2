using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {

        // string sceneName = SceneManager.GetActiveScene().name;

        // switch (sceneName)
        // {
        //     case NAME_SCENE_1:
        //         PlayMusic("Chunky_Monkey");
        //         break;
        //     case NAME_SCENE_2:
        //         PlayMusic("InfiniteDoors");
        //         break;
        //     case NAME_SCENE_3:
        //         PlayMusic("Tiny_Blocks");
        //         break;
        //     default:
        //         PlayMusic("Chunky_Monkey");
        //         break;
        // }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s == null)
        {
            Debug.Log("music not found");
        }
        else
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
        }
    }

    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("music not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.audioClip);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void changeSfcVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
