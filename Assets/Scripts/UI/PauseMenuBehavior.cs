using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : MonoBehaviour
{
    [HideInInspector]
    public bool gamePaused;

    [Tooltip("Refernce to the pause menu")]
    [SerializeField]
    private Canvas pauseMenu;

    // Update is called once per frame
    void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        ContinueGame();
        GoBackToMenu();
    }

    private void ContinueGame()
    {
        var keyboard = Keyboard.current;

        /// If the game is not in a paused state, and the player hits the escape key, it will set gamePaused to true and
        /// enable the pause menu UI.
        if (keyboard.escapeKey.wasPressedThisFrame && gamePaused == false)
        {
            pauseMenu.gameObject.SetActive(true);
            gamePaused = true;
        }
        /// If the game is in a paused state, and the player hits the escape key, it will set gamePaused to false and
        /// disable the pause menu UI.
        else if (keyboard.escapeKey.wasPressedThisFrame && gamePaused == true)
        {
            pauseMenu.gameObject.SetActive(false);
            gamePaused = false;
        }
    }

    //If the game is paused and the space key was pressed, it will take the player back to the start menu.
    private void GoBackToMenu()
    {
        var keyboard = Keyboard.current;

        if(keyboard.spaceKey.wasPressedThisFrame && gamePaused == true)
        {
            SceneManager.LoadScene("StartMenu");
            gamePaused = false;
        }
    }
}
