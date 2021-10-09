using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private int startHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private HealthUI healthUI;
    [SerializeField] private GameObject gameOver;


    void Start()
    {
        Heal(startHealth);
    }

    public void Heal(int num)
    {
        playerHealth += num;
        playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        healthUI.ChangeLife(playerHealth);
    }

    public void Damage(int num)
    {
        playerHealth -= num;

        if (playerHealth <= 0)
        {
            healthUI.ChangeLife(0);
            gameOver.SetActive(true);
        }
        else
        {
            healthUI.ChangeLife(playerHealth);
        }

    }
}
 