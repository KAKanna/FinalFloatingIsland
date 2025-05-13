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
        PlayerPrefs.SetInt("SelectedLives", 5);
        SceneManager.LoadScene("FloatingIsland");

    }

    void SelectHardMode()
    {
        PlayerPrefs.SetInt("SelectedLives", 3);
        SceneManager.LoadScene("FloatingIsland");

    }
}
