using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehavior : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BryceTest");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}