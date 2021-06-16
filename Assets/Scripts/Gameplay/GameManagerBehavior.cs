using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    //A reference to the lifes variable in PlayerBehaviour
    public PlayerBehavior lifesRef;
    private PlayerBehavior PlayerRef;
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
        while(!gameOver)
        {
            lifesRef.lifes = 3;


            if(lifesRef.lifes == 0 && PlayerRef == null)
            {
                gameOver = true;
                RestartGame();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
