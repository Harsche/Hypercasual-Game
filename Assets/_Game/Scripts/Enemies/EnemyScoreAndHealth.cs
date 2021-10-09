using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAndHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scorePoints;

    public void ChangeHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Globals.Score.ChangeScore(scorePoints);
            Destroy(gameObject);
        }
    }
}
