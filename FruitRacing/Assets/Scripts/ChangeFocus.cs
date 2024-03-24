using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeFocus : MonoBehaviour
{
    public bool isUsed = false;
    public PositionManager master;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy") && !isUsed || col.CompareTag("Player") && !isUsed)
        {
            isUsed = true;
            master.currentPoint++;
        }
    }
}
