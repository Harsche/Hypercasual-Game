using UnityEngine;
using UnityEngine.UI;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private int gaugeMax;
    [SerializeField] private int healValue;
    private Slider gaugeSlider;

    void Start()
    {
        gaugeSlider = GetComponent<Slider>();
        gaugeSlider.maxValue = gaugeMax;
        gaugeSlider.value = 0;
    }

    public void ChangeGaugeValue(int num)
    {
        gaugeSlider.value += num;
        if(gaugeSlider.value >= gaugeSlider.maxValue)
        {
            gaugeSlider.value = 0;
            Globals.Player.Heal(healValue);
        }
    }
}
