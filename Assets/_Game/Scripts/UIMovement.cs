using UnityEngine;
using DG.Tweening;

public class UIMovement : MonoBehaviour
{
    [SerializeField] private Vector2 finalPosition;
    [SerializeField] private float moveDuration;
    private RectTransform myRectTransform;


    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
        RectTransform canvasRectTransform = transform.parent.GetComponent<RectTransform>();
        finalPosition += new Vector2(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.height / 2);
        myRectTransform.DOLocalMove(finalPosition, moveDuration);
    }
}
