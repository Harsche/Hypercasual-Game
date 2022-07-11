using System.Collections;
using UnityEngine;

public class Enemy1Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Transform myTransform;
    private Vector2 direction;

    void Awake()
    {
        myTransform = transform;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        StartCoroutine(CheckDistance());
    }

    void Update()
    {
        myTransform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(damage);
            Destroy(gameObject);
        }
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
