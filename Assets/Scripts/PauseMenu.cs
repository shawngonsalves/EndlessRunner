using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public CameraFollow cameraMusic;
    private AudioSource bgmusic;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        // need to access background music in every scene
        bgmusic = cameraMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the escape key is pressed...
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // and the game is paused, then resume game
            if(isPaused)
                ResumeGame();
            // otherwise pause and show menu
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                bgmusic.Pause();
            }
        }
    }

    // resumes the game and hides menu
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        bgmusic.Play();
    }

    // unpauses game and returns to main menu
    public void ToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
