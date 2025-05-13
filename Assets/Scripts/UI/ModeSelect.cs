using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public Button EasyMode;
    public Button HardMode;

    void Start()
    {
        
        EasyMode.onClick.AddListener(SelectEasyMode);
        HardMode.onClick.AddListener(SelectHardMode);
    }

    void SelectEasyMode()
    {
        gameManager.Instance.totalLives = 5;
        SceneManager.LoadScene("FloatingIsland");

    }

    void SelectHardMode()
    {
        gameManager.Instance.totalLives = 3;
        SceneManager.LoadScene("FloatingIsland");

    }
}
