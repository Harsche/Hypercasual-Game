using UnityEngine;
using System.Collections;

public class Enemy2Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;
        StartCoroutine(CheckDistance());
    }

    void Update()
    {
        myTransform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage(damage);
            Destroy(gameObject);
        }
    }

    public IEnumerator CheckDistance()
    {
        while(true)
        {
            if(myTransform.position.magnitude >= 10.0f)
            {
                PoolManager.ReleaseObject(gameObject);
            }
        }
    }
}
