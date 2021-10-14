using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private RectTransform screenBlack;
    [SerializeField] private Vector2 finalPosition1;
    [SerializeField] private float duration1;
    [SerializeField] private Ease ease1;
    [SerializeField] private RectTransform screenWhite;
    [SerializeField] private Vector2 finalPosition2;
    [SerializeField] private float duration2;
    [SerializeField] private Ease ease2;
    [SerializeField] private UnityEvent onMoveFinish = new UnityEvent();

    public void MoveStart()
    {
        RectTransform canvasRectTransform = transform.parent.GetComponent<RectTransform>();
        finalPosition1 += new Vector2(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.height / 2);
        finalPosition2 += new Vector2(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.height / 2);

        Tween move1 = screenBlack.DOLocalMove(finalPosition1, duration1);
        move1.SetEase(ease1);
        Tween move2 = screenWhite.DOLocalMove(finalPosition2, duration2);
        move2.SetEase(ease2);

        move1.OnComplete(() => { onMoveFinish.Invoke(); });
    }
}
