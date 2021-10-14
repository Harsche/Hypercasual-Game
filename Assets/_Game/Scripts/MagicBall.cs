using System.Collections;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] private int damage;
    private SpriteRenderer mySpriteRenderer;
    private Transform myTransform;
    private static Color[] possibleColors = new Color[3];

    private Color myColor;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myTransform = transform;
        possibleColors[0] = Color.blue;
        possibleColors[1] = Color.red;
        possibleColors[2] = Color.green;
    }

    private void OnEnable()
    {
        StartCoroutine(CheckDistance());
        Color randomColor = possibleColors[Random.Range(0, 3)];
        myColor = randomColor;

        float h, s, v;
        Color.RGBToHSV(randomColor, out h, out s, out v);
        s *= 0.7f;
        mySpriteRenderer.color = Color.HSVToRGB(h, s, v, true); ;
        ChangeParticleSystemColor(randomColor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScoreAndHealth>().ChangeHealth(damage, myColor);
            PoolManager.ReleaseObject(gameObject);
        }
    }

    public void ChangeParticleSystemColor(Color color)
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

        ParticleSystem.MainModule mainModule = Globals.ShootParticles.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(min, max);
    }

    public IEnumerator CheckDistance()
    {
        while (true)
        {
            if (myTransform.position.magnitude >= 7.0f)
            {
                PoolManager.ReleaseObject(gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}