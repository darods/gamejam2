using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    Canvas canvasMenu1;
    Canvas canvasMenu2;

    void Start()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.name == "CanvasMenu")
            {
                canvasMenu1 = canvas;
            }
            else if (canvas.name == "CanvasMenu2")
            {
                canvasMenu2 = canvas;
            }
        }

        canvasMenu2.gameObject.SetActive(false);
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("Level 1 Test");
    }

    public void StartLevel2()
    {

    }

    public void StartLevel3()
    {

    }

    public void ChangeMenu()
    {
        canvasMenu1.gameObject.SetActive(false);
        canvasMenu2.gameObject.SetActive(true);
    }

    public void BackMenu()
    {
        canvasMenu2.gameObject.SetActive(false);
        canvasMenu1.gameObject.SetActive(true);
    }
}
