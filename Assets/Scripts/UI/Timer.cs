using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    public float timeElapsed;
    private bool isTimerRunning = true;

    public float scoreMap;
    float scoreTime;
    
    void Start()
    {
        timeElapsed = 0f;
        scoreMap = 0f;
        scoreTime = PlayerPrefs.GetFloat("ScoreTime", 1f);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += UnityEngine.Time.deltaTime;
            scoreMap ++;
            UpdateTimerUI();

            if (gameManager.Instance.currentLives <= 0)
            {
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
            gameManager.Instance.UpdateScoreUI();
        }
    }
}
