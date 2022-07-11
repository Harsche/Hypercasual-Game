using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    [SerializeField] private float speed;
    [SerializeField] private float shootTime;
    [SerializeField] private float shootAngle;
    [SerializeField] private GameObject projectile;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private Coroutine shootCoroutine;
    private GameObject shooter;
    private Tween path;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        shooter = transform.GetChild(0).gameObject;
        GoToStartPosition();
    }

    private void OnDestroy()
    {
        if (shootCoroutine != null)
            StopCoroutine(shootCoroutine);
    }

    private void OnDisable()
    {
        path.Kill();
    }

    private void GoToStartPosition()
    {
        if (min != null && max != null)
        {
            Vector3[] v3path = new Vector3[1];
            v3path[0] = GenerateRandomPosition();
            mySpriteRenderer.flipX = v3path[0].x > transform.position.x ? false : true;
            float duration = Vector2.Distance(transform.position, v3path[0]) / speed;
            path = transform.DOPath(v3path, duration, PathType.Linear, PathMode.TopDown2D);
            path.OnComplete(() => {
                myAnimator.SetTrigger("Idle");
                shootCoroutine = StartCoroutine(ShootCoroutine()); 
                });
            path.SetLink(gameObject);
        }
    }

    public void Shoot()
    {
        GameObject shoot1 = PoolManager.SpawnObject(projectile);
        GameObject shoot2 = PoolManager.SpawnObject(projectile);
        GameObject shoot3 = PoolManager.SpawnObject(projectile);
        shoot1.transform.position = shooter.transform.position;
        shoot2.transform.position = shooter.transform.position;
        shoot3.transform.position = shooter.transform.position;
        shoot1.transform.eulerAngles = new Vector3(0f, 0f, (-90f - shootAngle / 2));
        shoot2.transform.eulerAngles = new Vector3(0f, 0f, (-90f + shootAngle / 2));
        shoot3.transform.eulerAngles = new Vector3(0f, 0f, -90f);
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            myAnimator.SetTrigger("Shoot");
            yield return new WaitForSeconds(shootTime);
        }
    }

    private Vector2 GenerateRandomPosition()
    {
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}