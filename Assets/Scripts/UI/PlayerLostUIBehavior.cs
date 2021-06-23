using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerLostUIBehavior : MonoBehaviour
{
    [HideInInspector]
    public bool playerLost = false;

    [SerializeField]
    private PlayerBehavior _player;

    [SerializeField]
    private Text scoreText;

    [Tooltip("Refernce to the lose menu")]
    [SerializeField]
    private Canvas loseMenu;

    public GameObject FirstSelected;
    private bool _selected = true;

    // Update is called once per frame
    private void Update()
    {
        FirstButtonSelected();
        LoseGame();
        ActiveText();
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
        SceneManager.LoadScene(1);
        playerLost = false;
    }

    //If the player lost and the Exit button was pressed, it will take the player back to the start menu.
    public void GoBackToMenu()
    {
        if (playerLost == true)
        {
            SceneManager.LoadScene(0);
            playerLost = false;
        }
    }
       
    private void ActiveText()
    {
        scoreText.text = "Score: " + _player.score.ToString();
    }

    private void FirstButtonSelected()
    {
        int timesSelected = 1;
        for(int i = 0; i < timesSelected; i++)
        {
            if(_selected == true && playerLost == true)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(FirstSelected);
                _selected = false;
            }
        }
    }
}
