using System.Collections;
using UnityEngine;

public class EnemyScoreAndHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scorePoints;
    [SerializeField] private int gaugePoints;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private float hitTime;
    [SerializeField] private GameObject particleExplosion;
    private SpriteRenderer mySpriteRenderer;
    private Material myMaterial;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myMaterial = mySpriteRenderer.material;
    }

    public void ChangeHealth(int damage)
    {
        health -= damage;
        mySpriteRenderer.material = myMaterial;
        Coroutine hitCoroutine = StartCoroutine(ChangeMaterialOnHit());


        if (health <= 0)
        {
            Globals.Score.ChangeScore(scorePoints);
            Globals.HealthGauge.ChangeGaugeValue(gaugePoints);
            PoolManager.SpawnObject(particleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeMaterialOnHit()
    {
        mySpriteRenderer.material = hitMaterial;

        yield return new WaitForSeconds(hitTime);

        mySpriteRenderer.material = myMaterial;
    }
}
