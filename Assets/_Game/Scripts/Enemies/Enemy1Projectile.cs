using UnityEngine;

public class Enemy1Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Transform myTransform;
    private Vector2 direction;
    void Start()
    {
        myTransform = transform;
        direction = Globals.Player.transform.position - myTransform.position;
        direction.Normalize();
    }

    void Update()
    {
        myTransform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
