using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeFocus : MonoBehaviour
{
    public bool isUsed = false;
    public PositionManager master;
    public PlayerController playerController;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if ((col.CompareTag("Enemy") || col.CompareTag("Player")) && !isUsed)
        {
            isUsed = true;
            master.currentPoint++;
            playerController.lastSafePosition = transform.position;
        }
    }
}
