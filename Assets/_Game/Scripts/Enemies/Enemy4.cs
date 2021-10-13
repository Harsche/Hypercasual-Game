using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy4 : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float shootTime;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    private Transform myTransform;
    private float duration;

    void Start()
    {
        myTransform = transform;

        Vector2 initialPos = RandomPosition();
        duration = Vector2.Distance(myTransform.position, initialPos) / speed;

        Tween move = myTransform.DOMove(initialPos, duration);
        move.OnComplete(() => { StartCoroutine(PositionAndShoot()); });
        move.SetLink(gameObject);
    }

    IEnumerator PositionAndShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootTime);

            float playerPosX = Globals.Player.transform.position.x;
            duration = Vector2.Distance(myTransform.position, new Vector2(playerPosX, myTransform.position.y)) / speed;
            Tween moveToPlayer = myTransform.DOMoveX(playerPosX, duration);
            moveToPlayer.SetLink(gameObject);
            Instantiate(projectile, myTransform.GetChild(0).position, Quaternion.identity);

            yield return moveToPlayer.WaitForCompletion();
        }
    }

    private Vector2 RandomPosition()
    {
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
