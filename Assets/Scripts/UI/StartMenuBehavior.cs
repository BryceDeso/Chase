using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartMenuBehavior : MonoBehaviour
{
    private void Update()
    {
        StartGame();
        ExitGame();
    }

    //If space is pressed start game.
    public void StartGame()
    {
        var keyboard = Keyboard.current;

        if(keyboard.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("BryceTest");
        }
    }

    //If escape key is press quit game.
    public void ExitGame()
    {
        var keyboard = Keyboard.current;

        if(keyboard.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}