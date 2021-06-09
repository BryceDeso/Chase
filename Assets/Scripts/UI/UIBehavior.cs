using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    private void OnPause()
    {
        pauseMenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
