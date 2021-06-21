﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    //A reference to the lifes variable in PlayerBehaviour
    public PlayerBehavior lifesRef;
    private PlayerBehavior _player;
    [SerializeField]
    private WinPlaneBehavior Win;
    public bool gameOver;

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
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

            if(lifesRef.lifes == 0)
            {
                gameOver = true;
                RestartGame();
            }
            if(Win.CompletedLevel == true)
            {
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
