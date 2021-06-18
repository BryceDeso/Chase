﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    //A reference to the lifes variable in PlayerBehaviour
    public PlayerBehavior lifesRef;
    public bool gameOver;

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    //The main game loop
    public void GameEngine()
    {
        while(!gameOver)
        {
            lifesRef.lifes = 3;

            if(lifesRef.lifes == 0)
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
        lifesRef = GetComponent<PlayerBehavior>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GameEngine();
    }
}
