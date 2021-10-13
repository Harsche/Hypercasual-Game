using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Sprite redHeart;
    [SerializeField] private Sprite empyHeart;
    private Image[] heartSprites;
    private RectTransform myRectTransform;



    void Awake()
    {
        myRectTransform = GetComponent<RectTransform>();

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
