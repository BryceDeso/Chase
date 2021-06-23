using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuBehavior : MonoBehaviour
{
    [HideInInspector]
    public bool gamePaused;

    [Tooltip("Refernce to the pause menu")]
    [SerializeField]
    private Canvas pauseMenu;

    public GameObject FirstSelected;
    private bool _selected = true;

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        var keyboard = Keyboard.current;
        var gamePad = Gamepad.current;

        /// If the game is not in a paused state, and the player hits the escape key, it will set gamePaused to true and
        /// enable the pause menu UI.
        if (keyboard.escapeKey.wasPressedThisFrame || gamePad.startButton.wasPressedThisFrame && gamePaused == false)
        {
            pauseMenu.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(FirstSelected);
            gamePaused = true;
        }
    }

    public void UnPauseGame()
    {
        /// If the game is in a paused state, and the player hits the Resume button, it will set gamePaused to false and
        /// disable the pause menu UI.
        if (gamePaused == true)
        {
            pauseMenu.gameObject.SetActive(false);
            gamePaused = false;
        }
    }

    //If the game is paused and the Exit button was pressed, it will take the player back to the start menu.
    public void GoBackToMenu()
    {
        if(gamePaused == true)
        {
            SceneManager.LoadScene("StartMenu");
            gamePaused = false;
        }
    }

    private void FirstButtonSelected()
    {
        int timesSelected = 1;
        for (int i = 0; i < timesSelected; i++)
        {
            if (_selected == true)
            {
                _selected = false;
            }
        }
    }
}
