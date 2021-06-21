using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerLostUIBehavior : MonoBehaviour
{
    [HideInInspector]
    public bool playerLost = false;

    [Tooltip("Refernce to the lose menu")]
    [SerializeField]
    private Canvas loseMenu;

    // Update is called once per frame
    void Update()
    {
        LoseGame();
    }

    public void LoseGame()
    {
        if(playerLost == true)
        {
            loseMenu.gameObject.SetActive(true);
        }
    }

    //If the player lost, and the player hits the Restart button, it will restart the game.
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        playerLost = false;

    }

    //If the player lost and the Exit button was pressed, it will take the player back to the start menu.
    public void GoBackToMenu()
    {
        if (playerLost == true)
        {
            SceneManager.LoadScene("StartMenu");
            playerLost = false;
        }
    }
}
