using UnityEngine;
using DG.Tweening;
using Lean.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float lanesDistance;
    [SerializeField] private float moveDuration;
    [SerializeField] private float swipeDeadzone;
    private Rigidbody2D myRigidbody2d;
    private RectTransform myTransform;
    private RectTransform canvasTransform;
    private float left;
    private float right;
    private float middle;
    private int finalPos;

    private bool canSwipe = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<RectTransform>();
        canvasTransform = myTransform.parent.GetComponent<RectTransform>();
        finalPos = 0;

        middle = canvasTransform.rect.width / 2.0f;
        left = middle - lanesDistance * canvasTransform.rect.width;
        right = middle + lanesDistance * canvasTransform.rect.width;

    }


    public void SwipeMove(LeanFinger finger)
    {
        if (this.enabled)
        {
            if (finger.Down)
            {
                canSwipe = true;
            }

            if (canSwipe && Mathf.Abs((finger.ScreenPosition - finger.StartScreenPosition).x) >= swipeDeadzone)
            {
                int dirX = (int)Mathf.Sign((finger.ScreenPosition - finger.StartScreenPosition).x);

                if (finalPos + dirX >= -1 && finalPos + dirX <= 1)
                {
                    finalPos += dirX;

                    Vector2 endValue = new Vector2(GetLane(finalPos), myTransform.position.y);

                    myRigidbody2d.DOMove(endValue, moveDuration);
                    canSwipe = false;
                }
            }
        }
    }

    private float GetLane(int num)
    {
        switch (num)
        {
            case 0:
                return middle;
            case -1:
                return left;
            case 1:
                return right;
            default:
                return middle;
        }
    }
}
