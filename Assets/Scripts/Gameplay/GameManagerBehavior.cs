using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the menu that shows up when the player pauses")]
    [SerializeField]
    private PauseMenuBehavior _pauseMenu;
    [Tooltip("Refernce to the menu that shows up when the player losses")]
    [SerializeField]
    private PlayerLostUIBehavior _playerLoseMenu;
    [Tooltip("Refernce to the player.")]
    [SerializeField]
    private PlayerBehavior _player;
    [Tooltip("Refernce to the plane the player needs to touch to win.")]
    [SerializeField]
    private WinPlaneBehavior Win;
    public bool gameOver;

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGameArea");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        if(_pauseMenu.gamePaused == false)
        {
            Time.timeScale = 1;
        }
        else if(_pauseMenu.gamePaused == true)
        {
            Time.timeScale = 0;
        }
    }

    public void OnGameWin()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Wander");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }

    //The main game loop
    public void GameEngine()
    {
        if(!gameOver)
        {
            PauseGame();

            if(_player.lifes <= 0)
            {
                _player.lifes = 0;
                _playerLoseMenu.playerLost = true;
                gameOver = true;
                Time.timeScale = 0;
            }
            if(Win.CompletedLevel == true)
            {
                OnGameWin();
                _player.score = _player.score + 150;
                Win.CompletedLevel = false;
                RestartGame();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false; 
    }

    // Update is called once per frame
    void Update()
    {
        GameEngine();
    }
}
