using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingManager : MonoBehaviour
{
    public int timesPLayer = 0;
    public int timesEnemy = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timesPLayer >= 2){
            SceneManager.LoadScene("Win");
        }else if(timesEnemy > 3){
            SceneManager.LoadScene("Lose");
        }
    }
    
    void OnTriggerEnter(Collider other){
        Debug.Log(other.name);
        if(other.CompareTag("Player"))
        {
            timesPLayer++;

        }else if(other.CompareTag("Enemy"))
        {
            Debug.Log("entre");
            timesEnemy++;
        }
    }
}
