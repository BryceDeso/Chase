﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    //A reference to the lifes variable in PlayerBehaviour
    public PlayerBehavior lifesRef;
    private PlayerBehavior _player;
    public bool gameOver;

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //The main game loop
    public void GameEngine()
    {
        while(!gameOver)
        {
            lifesRef.lifes = 3;


            if(lifesRef.lifes == 0 || _player == null)
            {
                gameOver = true;
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

    }
}
