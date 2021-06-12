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
    }

    public void StartGame()
    {
        var keyboard = Keyboard.current;

        if(keyboard.anyKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("BryceTest");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}