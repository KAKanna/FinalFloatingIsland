using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string sceneName;
    private Button button;   

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
    }

    void ChangeScene()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(sceneName);
    }
}
