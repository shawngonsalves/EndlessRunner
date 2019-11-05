using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImage;
    private bool isShown = false;
    private float transition;

    // Start is called before the first frame update
    void Start()
    {
        transition = 0.0f;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
            return;
        else
        {
            transition += Time.deltaTime;
            backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        }
    }

    public void ToggleDeathMenu(float score)
    {
        gameObject.SetActive(true);
        isShown = true;
        scoreText.text = ((int)score).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
