using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_Complete : MonoBehaviour
{
    [SerializeField] private Image start1;
    [SerializeField] private Image start2;
    [SerializeField] private Image start3;
    [SerializeField] private Sprite starSprite;

    public void Start()
    {
        Debug.Log("CompleteLevel được gọi");
        if (GameManager.Instance.fruitsCollected == GameManager.Instance.totalFruits)
        {
            start1.sprite = starSprite;
            start2.sprite = starSprite;
            start3.sprite = starSprite;
        }
    }
    public void NextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
