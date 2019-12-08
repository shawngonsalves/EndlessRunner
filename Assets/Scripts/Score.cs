/*
 * Jeff McCluckerson - Score.cs 
 * Scoring system that has a difficulty level and max difficulty.
 * Keeps track of score and increases difficulty (movement speed) based on score.
 * Rate at which score increases is increased at each difficulty level
 * Saves high score if there is one and displays on menu screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text eggText;

    public static float score;
    public static int eggs, eggsToAdd;
    private int difficultyLevel;
    private int maxDifficultyLevel;
    private int scoreToNextLevel;
    private bool isDead;
    public DeathMenu deathMenu;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        score = 0.0f;
        eggs = 0;
        eggsToAdd = 0;
        difficultyLevel = 1;
        maxDifficultyLevel = 6;
        scoreToNextLevel = 15;
        currentScene = SceneManager.GetActiveScene();
        // used to reset my egg count for testing the level unlock
        //PlayerPrefs.SetInt("NumEggs", eggsToAdd);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        if (score >= scoreToNextLevel)
            difficultyUp();
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
        eggText.text = "x " + eggs.ToString();
    }

    void difficultyUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        if(currentScene.name == "Level3")
            GetComponent<ChickenControllerSpace>().SetSpeed(difficultyLevel);
        else
            GetComponent<ChickenControllerCC>().SetSpeed(difficultyLevel);
        difficultyLevel++;
    }

    public void OnDeath()
    {
        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore" + currentScene.name) < score)
            PlayerPrefs.SetFloat("Highscore" + currentScene.name, score);

        eggsToAdd = PlayerPrefs.GetInt("NumEggs");
        eggsToAdd += eggs;
        PlayerPrefs.SetInt("NumEggs", eggsToAdd);
        deathMenu.ToggleDeathMenu(score);
    }

    public static void addEggToScore()
    {
        score += 5;
    }
}
