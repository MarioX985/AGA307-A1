using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public GameState gameState;
    public Difficulty difficulty;
    int scoreMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        difficulty = Difficulty.Easy;

        Setup();
    }

    void Setup()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplier = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
        }
    }
}
