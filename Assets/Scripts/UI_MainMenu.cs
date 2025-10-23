using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Slider musicSlider;

    public void NewGame()
    {
        SceneManager.LoadScene(sceneName);
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
