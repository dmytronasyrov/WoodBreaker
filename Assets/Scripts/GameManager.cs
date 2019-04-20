using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int points;

    public static void GameOver()
    {
        Application.LoadLevel("Game");
    }

    void Start()
    {
        points = 0;
    }


    void Update()
    {
        
    }
}
