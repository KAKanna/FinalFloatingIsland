using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int totalLives = 3;
    public int currentLives;
    public TMP_Text livesText;

    public TMP_Text Text;
    public GameObject EndScreen;
    public Button resetButton;

    private void Start()
    {
        currentLives = totalLives;
        Text.gameObject.SetActive(false);
        EndScreen.SetActive(false);
        resetButton.gameObject.SetActive(false);

       
    }

    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject player in players)
        {
            Vector3 pos = player.transform.position;

            if (pos.y < -5)
            {
                currentLives--;
                Destroy(player);
            }
        }

        foreach (GameObject enemy in enemys)
        {
            if (currentLives <= 0)
            {
                currentLives--;
                Destroy(enemy);
            }
        }

        UpdateLivesUI();
    }
    private void UpdateLivesUI()
    {

        livesText.text = "Lives: " + currentLives;
        if (currentLives <= 0)
        {
            Time.timeScale = 0f;
            Text.gameObject.SetActive(true);
            EndScreen.SetActive(true);
            resetButton.gameObject.SetActive(true);
        }

    }

    
}
