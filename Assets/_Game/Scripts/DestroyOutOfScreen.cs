using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PoolManager.ReleaseObject(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PoolManager.ReleaseObject(other.gameObject);
    }
}
