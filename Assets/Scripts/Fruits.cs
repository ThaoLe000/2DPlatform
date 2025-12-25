using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FruitType { Apple, Bananas, Cherries, Kiwi, Melon }
public class Fruits : MonoBehaviour
{
    [SerializeField] private FruitType fruitType;
    [SerializeField] private GameObject pickupVfx;

    private GameManager gameManager;
    private UIManager uiManager;
    private Animator animator;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = UIManager.Instance;
        SetRandomLookNeeded();
    }
    private void SetRandomLookNeeded()
    {
        if(gameManager.FruitsHaveRandomLook() == false)
        {
            UpdateFruitVisuals();
            return;
        }
        int randomIndex = Random.Range(0, 5);
        animator.SetFloat("fruitindex",randomIndex);
    }

    private void UpdateFruitVisuals()
    {
        animator.SetFloat("fruitindex", (int)fruitType);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            gameManager.AddFruit();
            uiManager.UpdateFruitsUI(1);
            Destroy(gameObject);

            GameObject newFx = Instantiate(pickupVfx, transform.position, Quaternion.identity);

        }
    }
}
