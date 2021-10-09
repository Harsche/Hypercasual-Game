using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private int gaugeMax;
    [SerializeField] private int healValue;
    [SerializeField] private Vector2 healthPosition;
    [SerializeField] private float moveDuration;
    private Slider gaugeSlider;
    private RectTransform myRectTransform;

    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
        healthPosition += new Vector2(-transform.parent.GetComponent<RectTransform>().rect.width / 2, 0f);
        myRectTransform.DOLocalMove(healthPosition, moveDuration);
        gaugeSlider = GetComponent<Slider>();
        gaugeSlider.maxValue = gaugeMax;
        gaugeSlider.value = 0;
    }

    public void ChangeGaugeValue(int num)
    {
        gaugeSlider.value += num;
        if(gaugeSlider.value >= gaugeSlider.maxValue)
        {
            Globals.Player.Heal(healValue);
        }
    }
}
