using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;
    public static GameManager instance;

    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

    public int collectedCoins = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentGameState = GameState.menu;
    }

    private void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        LevelGenerator.instance.RemoveAllPieces();
        LevelGenerator.instance.GenerateInitialPieces();
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
        LevelGenerator.instance.RemoveAllPieces();
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }

        currentGameState = newGameState;
    }

    public void CollectedCoin()
    {
        collectedCoins++;
    }
}
