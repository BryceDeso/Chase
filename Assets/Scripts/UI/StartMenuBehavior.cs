using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class StartMenuBehavior : MonoBehaviour
{
    public GameObject FirstSelected;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(FirstSelected);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGameArea");
    }

    //If escape key is press quit game.
    public void ExitGame()
    {
        Application.Quit();
    }
}