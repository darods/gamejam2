using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPause = false;
    Canvas canvasMenuPause;
    GameObject panelPause;
    Button pauseButton;
    AudioManager audioManager;
  


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        canvasMenuPause = FindObjectOfType<Canvas>();
        AssignElements();
        panelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        isPause = true;
        SetTimeScale(0f);
        panelPause.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    void AssignElements()
    {
        panelPause = canvasMenuPause.transform.Find("MenuPausa").gameObject;
        pauseButton = canvasMenuPause.GetComponentInChildren<Button>();
        canvasMenuPause = FindObjectOfType<Canvas>();

    }

    public void Play()
    {
        isPause = false;
        SetTimeScale(1.0f);
        pauseButton.gameObject.SetActive(true);
        panelPause.SetActive(false);
    }

    public void GoingToMain()
    {
        SetTimeScale(1.0f);
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SetTimeScale(1.0f);
        SceneManager.LoadScene("Level 1 Test");
    }

    private void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }
}
