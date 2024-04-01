using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingManager : MonoBehaviour
{
    public int timesPlayer = 0;
    public int timesEnemy = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timesPlayer >= 1){
            AudioManager.Instance.musicSource.Stop();
            SceneManager.LoadScene("Win");
        }else if(timesEnemy > 3){
            AudioManager.Instance.musicSource.Stop();
            SceneManager.LoadScene("Lose");
        }
    }
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player"))
        {
            timesPlayer++;

        }else if(other.CompareTag("Enemy"))
        {

            timesEnemy++;
        }
    }
}
