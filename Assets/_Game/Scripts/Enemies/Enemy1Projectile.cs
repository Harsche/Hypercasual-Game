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
        direction = Globals.Player.transform.position - myTransform.position;
        direction.Normalize();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        StartCoroutine(CheckDistance());
    }

    void Update()
    {
        myTransform.Translate(direction * speed * Time.deltaTime);
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
