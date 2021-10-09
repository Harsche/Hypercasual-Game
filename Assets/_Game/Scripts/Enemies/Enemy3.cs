using UnityEngine;
using DG.Tweening;

public class Enemy3 : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float deltaX;
    [SerializeField] private float deltaY;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;
        Vector2 startPos = myTransform.position;

        Vector3[] path = new Vector3[3];
        path[0] = new Vector2(startPos.x + deltaX / 2, startPos.y + deltaY / 3);
        path[1] = new Vector2(startPos.x - deltaX / 2, startPos.y + 2 * deltaY / 3);
        path[2] = new Vector2(startPos.x, startPos.y + deltaY);
        float duration = (Vector2.Distance(path[0], path[1]) + Vector2.Distance(path[1], path[2])) / speed;
        Tween moveX = myTransform.DOPath(path, duration, PathType.CatmullRom, PathMode.TopDown2D);
        moveX.SetLoops(-1, LoopType.Incremental);
        moveX.SetEase(Ease.Linear);
        moveX.SetLink(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
