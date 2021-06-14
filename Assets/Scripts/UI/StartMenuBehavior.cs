using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartMenuBehavior : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BryceTest");
    }

    //If escape key is press quit game.
    public void ExitGame()
    {
        Application.Quit();
    }
}