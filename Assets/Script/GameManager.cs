using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int playerScore;
    public Text scoreText;
    public Text comboText;
    public Text timerText;
    public float timer;
    public GameObject resultPanel;
    public Text scoreText2;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();
        if (timer <= 0)
        {
            Time.timeScale = 0;
            resultPanel.SetActive(true);
            scoreText2.text = playerScore.ToString();
        }
    }

    public void GetScore(int point)
    {
        playerScore += point;
        scoreText.text = playerScore.ToString();
    }

    public void SetMultiplier(float multiplier)
    {
        comboText.text = multiplier.ToString()+"x";
    }
}