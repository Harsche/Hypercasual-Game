using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    [SerializeField] private float speed;

    void Start()
    {
        if (min != null && max != null)
        {
            Vector3[] v3path = new Vector3[2];
            v3path[0] = RandomPosition();
            v3path[1] = new Vector2(-transform.position.x, transform.position.y);

            float duration = (Vector2.Distance(transform.position, v3path[0]) + Vector2.Distance(v3path[0], v3path[1])) / speed;

            Tween path = transform.DOPath(v3path, duration, PathType.CatmullRom, PathMode.TopDown2D).OnComplete(() => { Destroy(gameObject); });
            path.SetLink(gameObject);
        }
    }

    private Vector2 RandomPosition()
    {
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
