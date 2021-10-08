using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private Score score;

    public static Score Score;

    private void Awake()
    {
        Score = score;
    }
}
