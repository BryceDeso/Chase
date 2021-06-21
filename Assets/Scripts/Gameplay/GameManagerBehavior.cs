using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    //A reference to the lifes variable in PlayerBehaviour
    [SerializeField]
    private PlayerBehavior _player;
    [SerializeField]
    private PlayerLostUIBehavior _playerLostMenu;
    [SerializeField]
    private WinPlaneBehavior Win;
    public bool gameOver;

    public void RestartGame()
    {
        SceneManager.LoadScene("1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //The main game loop
    public void GameEngine()
    {
        if(!gameOver)
        {
            if(_player.lifes == 0)
            {
                _playerLostMenu.playerLost = true;
                gameOver = true;
            }
            if(Win.CompletedLevel == true)
            {
                Win.CompletedLevel = false;
                _player.score = _player.score + 150;
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
