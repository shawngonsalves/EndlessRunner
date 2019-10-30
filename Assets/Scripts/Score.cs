/*
 * Jeff McCluckerson - Score.cs 
 * Scoring system that has a difficulty level and max difficulty.
 * Keeps track of score and increases difficulty (movement speed) based on score.
 * Rate at which score increases is increased at each difficulty level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private float score;
    private int difficultyLevel;
    private int maxDifficultyLevel;
    private int scoreToNextLevel;
    private bool isDead;
    public DeathMenu deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        score = 0.0f;
        difficultyLevel = 1;
        maxDifficultyLevel = 6;
        scoreToNextLevel = 10;
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
    }

    void difficultyUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        GetComponent<ChickenControllerCC>().SetSpeed(difficultyLevel);
        difficultyLevel++;
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleDeathMenu(score);
    }
}
