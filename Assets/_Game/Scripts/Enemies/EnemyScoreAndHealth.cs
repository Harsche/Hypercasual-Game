using UnityEngine;

public class EnemyScoreAndHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scorePoints;
    [SerializeField] private int gaugePoints;

    public void ChangeHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Globals.Score.ChangeScore(scorePoints);
            Globals.HealthGauge.ChangeGaugeValue(gaugePoints);
            Destroy(gameObject);
        }
    }
}
