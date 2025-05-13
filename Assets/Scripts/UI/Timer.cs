using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    public float timeElapsed;
    private bool isTimerRunning = true;

    
    
    void Start()
    {
        timeElapsed = 0f;
       
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += UnityEngine.Time.deltaTime;
            
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
}
