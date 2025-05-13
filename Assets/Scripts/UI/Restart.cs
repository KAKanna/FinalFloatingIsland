using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string sceneName;
    private Button resetButton; 

    void Update()
    {
        resetButton = GetComponent<Button>();
        resetButton.onClick.AddListener(ChangeScene);
        
    }

    void ChangeScene()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(sceneName);
    }
}
