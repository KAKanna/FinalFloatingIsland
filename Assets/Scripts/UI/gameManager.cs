using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;


    public int totalLives = 0;
    public int currentLives;
    public TMP_Text livesText;
   

    public TMP_Text Text;
    public GameObject EndScreen;
    public Button Button;

    private void Start()
    {

        currentLives = totalLives;
        Text.gameObject.SetActive(false);
        EndScreen.SetActive(false);
        Button.gameObject.SetActive(false);
    }

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
            Button.gameObject.SetActive(true);
        }

    }

    
}
