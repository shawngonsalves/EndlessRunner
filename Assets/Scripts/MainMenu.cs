﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    AudioSource bgMusic;

    // menu states
    public enum MenuStates { Main, LevelSelect };
    public MenuStates currentstate;
    public GameObject mainMenu;
    public GameObject levelSelect;

    void Start()
    {
        // Always set to Main menu, not level select
        currentstate = MenuStates.Main;
        bgMusic = GetComponent<AudioSource>();
        highscoreText.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    public void PlayGame()
    {
        StartCoroutine(AudioController.FadeOut(bgMusic, 0.75f)); // fade out background song
        SceneManager.LoadScene(1);
    }

    // show level select when this button is pressed.
    public void OnLevelSelect()
    {
        currentstate = MenuStates.LevelSelect;
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    // used on LevelSelect screen for going back to main menu
    public void ToMenu()
    {
        currentstate = MenuStates.Main;
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void Select(string levelName)
    {
        StartCoroutine(AudioController.FadeOut(bgMusic, 0.75f)); // fade out background song
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
    		Application.Quit();
        #endif

}
}
