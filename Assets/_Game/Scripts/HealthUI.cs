using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Vector2 healthPosition;
    [SerializeField] private float moveDuration;
    [SerializeField] private Sprite redHeart;
    [SerializeField] private Sprite empyHeart;
    private Image[] heartSprites;
    private RectTransform myRectTransform;



    void Awake()
    {
        myRectTransform = GetComponent<RectTransform>();
        healthPosition += new Vector2(-transform.parent.GetComponent<RectTransform>().rect.width / 2, transform.parent.GetComponent<RectTransform>().rect.height / 2);
        myRectTransform.DOLocalMove(healthPosition, moveDuration);

        heartSprites = new Image[myRectTransform.childCount];
        for (int i = 0; i < myRectTransform.childCount; i++)
        {
            heartSprites[i] = myRectTransform.GetChild(i).gameObject.GetComponent<Image>();
        }
    }

    public void ChangeLife(int healthPoints)
    {
        for (int i = 0; i < myRectTransform.childCount; i++)
        {
            if (i + 1 <= healthPoints)
            {
                heartSprites[i].sprite = redHeart;
            }
            else
            {
                heartSprites[i].sprite = empyHeart;
            }
        }
    }
}
