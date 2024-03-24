using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    // Start is called before the first frame update
    public void ChangeMusicVolume()
    {
        AudioManager.Instance.ChangeMusicVolume(musicSlider.value);
    }
}
