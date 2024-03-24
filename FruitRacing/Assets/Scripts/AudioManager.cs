using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSourcePlayer;
    public AudioSource audioSourceMusic;

    public AudioClip musicAudio;
    public AudioClip cocoAudio;
    private Slider sliderMusica, sliderSonido;
    public Slider[] sliders;
    GameObject panelPause;
    Canvas canvasMenuPause;

    private const string VOLUME_MUSIC_KEY = "VolumeMusic";
    private const string VOLUME_SOUND_KEY = "VolumeSound";
    // Start is called before the first frame update
    void Awake()
    {
        // Configura la instancia singleton del SoundManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        audioSourceMusic = gameObject.AddComponent<AudioSource>();
        audioSourceMusic.clip = musicAudio;
        audioSourceMusic.playOnAwake = true;
        audioSourceMusic.Play();
        // Crea un AudioSource para reproducir los efectos de sonido
        audioSourcePlayer = gameObject.AddComponent<AudioSource>();
        audioSourcePlayer.playOnAwake = false;
        canvasMenuPause = FindObjectOfType<Canvas>();
        InitializeVolume();


    }

    void Start()
    {
   

    }

    public void ChangeMusicVolum()
    {
        audioSourceMusic.volume = sliderMusica.value;
        PlayerPrefs.SetFloat(VOLUME_MUSIC_KEY, sliderMusica.value);
        PlayerPrefs.Save();
    }

    public void ChangeSoundVolum()
    {
        audioSourcePlayer.volume = sliderSonido.value;
        PlayerPrefs.SetFloat(VOLUME_SOUND_KEY, sliderSonido.value);
        PlayerPrefs.Save();
    }

    private void InitializeVolume()
    {
  
        panelPause = canvasMenuPause.transform.Find("MenuPausa").gameObject;
        sliders = panelPause.GetComponentsInChildren<Slider>();

        foreach (Slider slider in sliders)
        {
            if (slider.name == "SliderMusica")
            {
                sliderMusica = slider;
            }
            else
            {
                sliderSonido = slider;
            }
        }
        // sliderMusica = pauseManager.sliderMusica;
        // sliderSonido = pauseManager.sliderSonido;
        float volumeMusic = PlayerPrefs.GetFloat(VOLUME_MUSIC_KEY, 1.0f);
        sliderMusica.value = volumeMusic;
        float volumeSound = PlayerPrefs.GetFloat(VOLUME_SOUND_KEY, 1.0f);
        sliderSonido.value = volumeSound;
    }
}
