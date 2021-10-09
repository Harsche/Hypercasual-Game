using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private HealthGauge healthGauge;
    [SerializeField] private Player player;

    public static Score Score;
    public static HealthGauge HealthGauge;
    public static Player Player;

    private void Awake()
    {
        Score = score;
        HealthGauge = healthGauge;
        Player = player;
    }
}
