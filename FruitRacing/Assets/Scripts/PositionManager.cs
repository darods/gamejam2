using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private float[] fruits_positions = new float[4];
    public GameObject Player;
    public float playerPosition;
    public GameObject[] AI;
    public int currentPosition;
    public int currentPoint;
    public TextMeshProUGUI positionText;

    // Update is called once per frame
    void Update()
    {
        CalculatePosition();
        positionText.text = "Position: " + currentPosition.ToString() + " / " + fruits_positions.Length;
    }

    void CalculatePosition()
    {
        fruits_positions[0] = Player.GetComponent<PlayerController>().playerDistance;
        fruits_positions[1] = AI[0].GetComponent<MovementOponent>().aiDistance;
        fruits_positions[2] = AI[1].GetComponent<MovementOponent>().aiDistance;
        fruits_positions[3] = AI[2].GetComponent<MovementOponent>().aiDistance;

        playerPosition = Player.GetComponent<PlayerController>().playerDistance;

        Array.Sort(fruits_positions);

        int playerIndex = Array.IndexOf(fruits_positions, playerPosition);

        switch (playerIndex)
        {
            case 0:
                currentPosition = 1;
                break;
            case 1:
                currentPosition = 2;
                break;
            case 2:
                currentPosition = 3;
                break;
            case 3:
                currentPosition = 4;
                break;
        }

    }
}
