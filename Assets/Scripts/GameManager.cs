using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay;
    public Player player;

    [Header("Fruits Management")]
    public bool fruitsAreRandom;
    public int fruitsCollected;
    public int totalFruits;

    [Header("Checkpoint")]
    public bool canReactivate;

    [Header("Time")]
    public float timeRemaining;
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
        CollectFruitsInfo();
    }
    private void Start()
    {
        //CollectFruitsInfo();
        StartCoroutine(CountdownCoroutine());
    }

    
    private IEnumerator CountdownCoroutine()
    {
        while (timeRemaining > 0) {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            UIManager.Instance.UpdateTimerUI(timeRemaining);
        }
        timeRemaining = 0;
        UIManager.Instance.UpdateTimerUI(0);


    }
    private void CollectFruitsInfo()
    {
        Fruits[] allFruits = FindObjectsOfType<Fruits>();
        totalFruits = allFruits.Length;
    }

    public void UpdateRespawnPosition(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCourutine());
    }
    private IEnumerator RespawnCourutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position,Quaternion.identity);
        player = newPlayer.GetComponent<Player>();
    }
    public void AddFruit()
    {
        fruitsCollected++;
    }
    public bool FruitsHaveRandomLook()
    {
         return fruitsAreRandom;
    }
}
