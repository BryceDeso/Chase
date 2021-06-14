using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
=======
using UnityEngine.SceneManagement;
>>>>>>> JeremyFlowers-branch

public class UIBehavior : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private PlayerBehavior PlayerRef;

    public Text scoreText;
    public Text lifeText;
=======
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
>>>>>>> JeremyFlowers-branch

    // Update is called once per frame
    void Update()
    {
        ActiveText();
    }

    public void ActiveText()
    {
        scoreText.text = "Score: " + PlayerRef.score.ToString();

        lifeText.text = "Lives: " + PlayerRef.lifes.ToString();
    }
}
