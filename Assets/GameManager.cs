using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas/ScoreValue").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        //Debug.Log(PlayerPrefs.GetInt("highScore").ToString());
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void GameRestart()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1.0f;
    }

}
