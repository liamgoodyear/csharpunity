using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour {

    public GameState currentGameState = GameState.menu;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // StartGame();
        currentGameState = GameState.menu;
    }

    private void Update()
    {
        if(Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {

        }
        else if(newGameState == GameState.inGame)
        {

        }
        else if(newGameState == GameState.gameOver)
        {

        }

        currentGameState = newGameState;
    }
}
