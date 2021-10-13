using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy3 : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float deltaX;
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;
        Vector2 startPos = myTransform.position;
        StartCoroutine(CheckPosition());

        myTransform.Translate(deltaX / 2, 0f, 0f);
        Sequence moveX = DOTween.Sequence();
        Tween move1 = myTransform.DOMoveX(startPos.x - deltaX / 2, speedX / 2);
        Tween move2 = myTransform.DOMoveX(startPos.x + deltaX / 2, speedX / 2);
        move1.SetEase(Ease.InOutQuad);
        move2.SetEase(Ease.InOutQuad);
        moveX.Append(move1);
        moveX.Append(move2);
        moveX.SetLink(gameObject);
        moveX.SetLoops(-1, LoopType.Restart);
    }

    private void Update()
    {
        myTransform.Translate(0f, speedY * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
    
    IEnumerator CheckPosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            if(myTransform.position.y <= -7)
            {
                Destroy(gameObject);
            }
        }
    }
}
