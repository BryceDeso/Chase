using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    public bool gameOver = false;

    /// <summary>
    /// A function that will restart the game when the player has died
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// A function that will quit the game when the player wants to stop
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while(!gameOver)
        {

        }
    }
}
