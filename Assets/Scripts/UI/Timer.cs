using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public gameManager gm;
    public TMP_Text timerText;

    public float timeElapsed;
    private bool isTimerRunning = true;

    float scoreTime = PlayerPrefs.GetInt("ScoreTime", 1);
    float scoreMap;

    void Start()
    {
        timeElapsed = 0f;
        scoreMap = 0;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += UnityEngine.Time.deltaTime;
            scoreMap += UnityEngine.Time.deltaTime;

            UpdateTimerUI();

            if (gm.currentLives <= 0)
            {
                timeElapsed = 0;
                isTimerRunning = false;
            }
        }
    }

    void UpdateTimerUI()
    {   
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CalculateScoreTime()
    {
      
        if (timeElapsed != null)
        {
            gameManager.Instance.scoreFinal = scoreMap * scoreTime;
        }
    }
}
