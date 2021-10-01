using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField] private Vector2 scorePosition;
    [SerializeField] private float moveDuration;
    private RectTransform myTransform;
    private int score;


    void Start()
    {
        myTransform = GetComponent<RectTransform>();
        scorePosition +=  new Vector2(0, transform.parent.GetComponent<RectTransform>().rect.height / 2);
        myTransform.DOLocalMove(scorePosition, moveDuration);
    }

    public void ChangeScore(int num)
    {
        score += num;
    }
}
