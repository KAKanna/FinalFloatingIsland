using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int totalLives = 3;  
    public int currentLives;
    public TMP_Text livesText; 
    public string gameOver;

    private void Start()
    {
      
        currentLives = totalLives;
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        
        livesText.text = "Lives: " + currentLives;

    }

    void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Void"))
        {
            TakeDamage(); 
        }
    }

    public void TakeDamage()  
    {
        currentLives--;  
        UpdateLivesUI(); 
        if (currentLives <= 0)
        {
            Time.timeScale = 0;
        }
    }



}
