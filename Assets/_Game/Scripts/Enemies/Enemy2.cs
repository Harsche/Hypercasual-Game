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
    private Coroutine shootCoroutine;
    private GameObject shooter;

    void Start()
    {
        shooter = transform.GetChild(0).gameObject;

        if (min != null && max != null)
        {
            Vector3[] v3path = new Vector3[1];
            v3path[0] = RandomPosition();

            float duration = Vector2.Distance(transform.position, v3path[0]) / speed;

            Tween path = transform.DOPath(v3path, duration, PathType.Linear, PathMode.TopDown2D);
            path.OnComplete(() => { shootCoroutine = StartCoroutine(Shoot()); });
            path.SetLink(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject shoot1 = Instantiate(projectile);
            GameObject shoot2 = Instantiate(projectile);
            GameObject shoot3 = Instantiate(projectile);
            shoot1.transform.position = shooter.transform.position;
            shoot2.transform.position = shooter.transform.position;
            shoot3.transform.position = shooter.transform.position;
            shoot1.transform.eulerAngles = new Vector3(0f, 0f, (-90f - shootAngle / 2));
            shoot2.transform.eulerAngles = new Vector3(0f, 0f, (-90f + shootAngle / 2));
            shoot3.transform.eulerAngles = new Vector3(0f, 0f, -90f);

            yield return new WaitForSeconds(shootTime);
        }

    }

    private Vector2 RandomPosition()
    {
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}