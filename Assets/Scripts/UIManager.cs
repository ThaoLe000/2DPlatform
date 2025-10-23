using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject completePanel;
    [SerializeField] private TextMeshProUGUI timerText;


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
    public void CompleteLevel()
    {
        Time.timeScale = 0f;
        Instantiate(completePanel, transform);

    }
    public void UpdateTimerUI(float time)
    {
        time = Mathf.Max(0, time);
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = $"{minutes}: {seconds:D2}";
        timerText.color = time <= 10 ? Color.red : Color.white;
    }
}
