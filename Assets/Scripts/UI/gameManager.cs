using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    bool playerDestroyed = false;

    public int totalLives = 0;
    public int currentLives;
    public TMP_Text livesText;


    public TMP_Text Text;
    public GameObject EndScreen;
    public Button Button;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameStart();

        totalLives = PlayerPrefs.GetInt("SelectedLives", 3);
        currentLives = totalLives;
    }

    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Vector3 pos = player.transform.position;

            if (pos.y < -5)
            {
                currentLives--;
                Destroy(player);
                playerDestroyed = true;
            }

        }

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            if (playerDestroyed)
            {
                Destroy(enemy);
                playerDestroyed = false;
            }
        }

        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives;
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    private void GameStart()
    {
        Time.timeScale = 1f;
        Text.gameObject.SetActive(false);
        EndScreen.SetActive(false);
        Button.gameObject.SetActive(false);

    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        Text.gameObject.SetActive(true);
        EndScreen.SetActive(true);
        Button.gameObject.SetActive(true);
    }





}
