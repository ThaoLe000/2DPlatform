using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UI_MainMenu : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private GameObject settingPanel;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = settingPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = settingPanel.AddComponent<CanvasGroup>();

        settingPanel.SetActive(false);
        canvasGroup.alpha = 0;
    }
    public void NewGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SettingPanel()
    {
        settingPanel.SetActive(true);
        canvasGroup.alpha = 0;

        canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutQuad);
    }
    public void ClosePanel()
    {
        canvasGroup.DOFade(0f, 0.5f).SetEase(Ease.InQuad)
            .OnComplete(() => settingPanel.SetActive(false));
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
