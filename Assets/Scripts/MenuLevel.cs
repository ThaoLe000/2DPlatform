using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private int level;

    public void Level()
    {
        SceneManager.LoadScene(level);
    }
}
