using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the menu that shows up when the player pauses")]
    [SerializeField]
    private PauseMenuBehavior _pauseMenu;
    [Tooltip("Refernce to the player UI")]
    [SerializeField]
    private PlayerUIBehavior _playerUI;
    [Tooltip("Refernce to the menu that shows up when the player losses")]
    [SerializeField]
    private PlayerLostUIBehavior _playerLoseMenu;
    [Tooltip("Refernce to the player.")]
    [SerializeField]
    private PlayerBehavior _player;
    [Tooltip("Refernce to the plane the player needs to touch to win.")]
    [SerializeField]
    private WinPlaneBehavior Win;
    [Tooltip("Refernce for the item spawners")]
    [SerializeField]
    public GameObject[] _items;
    
    private int current;

    public bool gameOver;

    public void DestroyPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
    }

    public void RestartGame()
    {
        DontDestroyOnLoad(_player);
        SceneManager.LoadScene("MainGameArea");
    }

    public void ResetItems()
    {
        int i = 11;
        while (current != i)
        {
            _items[current].gameObject.SetActive(true);
            ++current;
        }
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

    public void DestroyEnemies()
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
                DestroyPlayer();
                _player.lifes = 0;
                _playerLoseMenu.playerLost = true;
                _playerUI.gameObject.SetActive(false);
                gameOver = true;
                Time.timeScale = 0;
            }
            if(Win.CompletedLevel == true)
            {
                ResetItems();
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
