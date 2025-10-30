using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private GameObject settingPanel;

    private void Start()
    {
        settingPanel.SetActive(false);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SettingPanel()
    {
        settingPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        settingPanel.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Dừng play mode
#else
        Application.Quit(); // Thoát khi build thật
#endif
    }
}
