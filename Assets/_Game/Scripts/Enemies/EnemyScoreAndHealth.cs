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

    public void ChangeHealth(int damage, Color color)
    {
        health -= damage;
        mySpriteRenderer.material = myMaterial;
        Coroutine hitCoroutine = StartCoroutine(ChangeMaterialOnHit());


        if (health <= 0)
        {
            Globals.Score.ChangeScore(scorePoints);
            Globals.HealthGauge.ChangeGaugeValue(gaugePoints);
            GameObject explosion = PoolManager.SpawnObject(particleExplosion, transform.position, Quaternion.identity);
            ChangeParticleSystemColor(color, explosion.GetComponent<ParticleSystem>());
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeMaterialOnHit()
    {
        mySpriteRenderer.material = hitMaterial;

        yield return new WaitForSeconds(hitTime);

        mySpriteRenderer.material = myMaterial;
    }

    public void ChangeParticleSystemColor(Color color, ParticleSystem particleSystem)
    {
        float h1, s1, v1;
        Color.RGBToHSV(color, out h1, out s1, out v1);
        s1 *= 0.7f;

        float h2, s2, v2;
        Color.RGBToHSV(color, out h2, out s2, out v2);
        v2 *= 0.5f;
        s2 *= 0.7f;

        Color min = Color.HSVToRGB(h1, s1, v1, true);
        Color max = Color.HSVToRGB(h2, s2, v2, true);

        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(min, max);
    }
}
