using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isPlayer;
    [SerializeField] private int scorePoints;

    public void ChangeHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (isPlayer)
            {

            }
            else
            {
                Globals.Score.ChangeScore(scorePoints);
                Destroy(gameObject);
            }
        }
    }
}
