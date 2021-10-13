using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private HealthGauge healthGauge;
    [SerializeField] private Player player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private ParticleSystem shootParticles;

    public static Score Score;
    public static HealthGauge HealthGauge;
    public static Player Player;
    public static GameObject MainCamera;
    public static ParticleSystem ShootParticles;

    private void Awake()
    {
        Score = score;
        HealthGauge = healthGauge;
        Player = player;
        MainCamera = mainCamera;
        ShootParticles = shootParticles;
    }
}
