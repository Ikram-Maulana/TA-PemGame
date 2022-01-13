using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    InGame,
    GameOver,
    Resume
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManager GetInstance()
    {
        return sharedInstance;
    }

    public void StartGame()
    {
      PlayerController.GetInstance().StartGame();
      ChangeGameState(GameState.InGame);
    }
  
    // Start is called before the first frame update
    private void Start()
    {
      // StartGame();
      currentGameState = GameState.Menu;
    }

    private void Update()
    {
        if (currentGameState != GameState.InGame && Input.GetKeyDown("s"))
        {
            ChangeGameState(GameState.InGame);
            StartGame();
        }
    }

    // Update is called once per frame
    public void GameOver()
    {
      ChangeGameState(GameState.GameOver);
    }

    public void BackToMainMenu()
    {
      ChangeGameState(GameState.Menu);
    }

    void ChangeGameState(GameState newGameState)
    {
      switch (newGameState)
        {
            case GameState.Menu:
                // Lets Load main menu scene
                // mainMenu.enabled = true;
                // GameMenu.enabled = false;
                // GameOverMenu.enabled = false;
                break;
            case GameState.InGame:
                // Unity Scene must show the Real Game
                // mainMenu.enabled = false;
                // GameMenu.enabled = true;
                // GameOverMenu.enabled = false;
                break;
            case GameState.GameOver:
                // Lets load end of the game scene
                // mainMenu.enabled = false;
                // GameMenu.enabled = false;
                // GameOverMenu.enabled = true;
                break;
            default:
                // currentGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
