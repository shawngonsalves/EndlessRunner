using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    void Start()
    {
        highscoreText.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString(); 
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
