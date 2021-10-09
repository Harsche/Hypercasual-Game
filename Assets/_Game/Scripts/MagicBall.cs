using System.Collections;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScoreAndHealth>().ChangeHealth(damage);
            Destroy(gameObject);
        }
    }
}
