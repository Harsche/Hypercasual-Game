using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;

public class UIMovement : MonoBehaviour
{
    [SerializeField] private Vector2 finalPosition;
    [SerializeField] private float moveDuration;
    [SerializeField] private Ease easeType;
    [SerializeField] private UnityEvent onMoveFinish = new UnityEvent();
    private Vector2 startPos;
    private RectTransform myRectTransform;
    private Tween move;


    void Start()
    {
        startPos = transform.position;
        myRectTransform = GetComponent<RectTransform>();
        RectTransform canvasRectTransform = transform.parent.GetComponent<RectTransform>();
        finalPosition += new Vector2(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.height / 2);
        move = myRectTransform.DOLocalMove(finalPosition, moveDuration);
        move.SetEase(easeType);
        move.OnComplete(() => { onMoveFinish.Invoke(); });
    }

    public void ChangePosition(Vector2 finalPosition)
    {
        this.finalPosition = finalPosition;
    }

    public void ChangeDuration(float moveDuration)
    {
        this.moveDuration = moveDuration;
    }

    public void ChangeEase(Ease easeType)
    {
        this.easeType = easeType;
    }

    public void StartTween()
    {
        move = myRectTransform.DOLocalMove(finalPosition, moveDuration);
        move.SetEase(easeType);
    }

    public void StartTweenFrom()
    {
        startPos += new Vector2(+transform.parent.GetComponent<RectTransform>().rect.width / 2, transform.parent.GetComponent<RectTransform>().rect.height / 2);;
        myRectTransform.DOLocalMove(startPos, moveDuration);
    }
}
