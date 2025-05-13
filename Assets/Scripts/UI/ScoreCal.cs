using TMPro;
using UnityEngine;

public class ScoreCal : MonoBehaviour
{
    public TMP_Text ScoreText;
    public float scoreFinal;
    public float scoreMap;
    float scoreTime;

    void Start()
    {
        scoreMap = 0f;
        scoreTime = PlayerPrefs.GetFloat("ScoreTime", 1f);

    }

    void Update()
    {
        scoreMap += UnityEngine.Time.deltaTime;
        UpdateUI();
    }

    private void UpdateUI()
    {
        ScoreSum();
        ScoreText.text = "Score:" + Mathf.FloorToInt(scoreFinal); ;
    }

    private void ScoreSum()
    {
        scoreFinal = scoreMap * scoreTime;

    }

}
