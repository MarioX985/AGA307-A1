using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : Singleton<GameManager>
{

    public GameState gameState;
    public Difficulty difficulty;
    int scoreMultiplier = 1;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        difficulty = Difficulty.Easy;

        Setup();

        GameEvents.EnemyHit += OnEnemyHit;
    }

    private void OnDestroy()
    {
        GameEvents.EnemyHit -= OnEnemyHit;
    }

    void OnEnemyHit(Enemy e)
    {
        AddScore(10);
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

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd * scoreMultiplier;
    }
}
