using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    [SerializeField] private float speed;
    private Animator myAnimator;
    private const string shootTrigger = "Shoot";


    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        GoToStartPosition();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(damage);
            Destroy(gameObject);
        }
    }

    private void GoToStartPosition()
    {
        if (min != null && max != null)
        {
            Vector3[] v3path = new Vector3[2];
            v3path[0] = GenerateRandomPosition();
            v3path[1] = new Vector2(-transform.position.x, transform.position.y);

            float duration = (Vector2.Distance(transform.position, v3path[0]) + Vector2.Distance(v3path[0], v3path[1])) / speed;

            Tween path = transform.DOPath(v3path, duration, PathType.CatmullRom, PathMode.TopDown2D).OnComplete(() => { Destroy(gameObject); });
            path.SetLink(gameObject);
            path.SetEase(Ease.Linear);
            StartCoroutine(DoShootAnimation(duration));
        }
    }

    private IEnumerator DoShootAnimation(float duration)
    {
        yield return new WaitForSeconds(duration / 2);
        myAnimator.SetTrigger(shootTrigger);
    }

    public void Shoot()
    {
        GameObject beam = PoolManager.SpawnObject(this.projectile, transform.GetChild(0).position, Quaternion.identity);
        beam.transform.right = Globals.Player.transform.position - beam.transform.position;
    }

    private Vector2 GenerateRandomPosition()
    {
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
