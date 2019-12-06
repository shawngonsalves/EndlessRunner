using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levelButtons;
    public Text highscore1, highscore2, highscore3, displayEggs;

    // Start is called before the first frame update
    void Start()
    {
        // since there are only 3 levels, I am hard coding everything
        // bad practice I know
        int totalEggs = PlayerPrefs.GetInt("NumEggs");
        highscore1.text = "Best: " + ((int)PlayerPrefs.GetFloat("HighscoreLevel1")).ToString();
        displayEggs.text = "x " + totalEggs.ToString();
        if (totalEggs < 15)
        {
            levelButtons[1].interactable = false; // disables interactablility of button 
            levelButtons[2].interactable = false; // disables interactablility of button
        }
        else if (totalEggs < 25)
        {
            highscore2.text = "Best: " + ((int)PlayerPrefs.GetFloat("HighscoreLevel2")).ToString();
            levelButtons[2].interactable = false;
        }
        else 
        {
            highscore2.text = "Best: " + ((int)PlayerPrefs.GetFloat("HighscoreLevel2")).ToString();
            highscore3.text = "Best: " + ((int)PlayerPrefs.GetFloat("HighscoreLevel3")).ToString();
        }
    }
}
