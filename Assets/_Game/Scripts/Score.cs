using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Score : MonoBehaviour
{
    public static int score { get; private set; }
    [SerializeField] private Vector2 scorePosition;
    [SerializeField] private float moveDuration;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeStrength;
    [SerializeField] private int shakeVibrato;
    [SerializeField] private float shakeRandomness;
    private bool gameOver;
    private Text scoreText;
    private RectTransform myRectTransform;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        gameOver = false;
    }

    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
        scorePosition += new Vector2(+transform.parent.GetComponent<RectTransform>().rect.width / 2, transform.parent.GetComponent<RectTransform>().rect.height / 2);
        myRectTransform.DOLocalMove(scorePosition, moveDuration);
    }

    public void ChangeScore(int num)
    {
        if (!gameOver)
        {
            score += num;
            scoreText.text = score.ToString();
            myRectTransform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, false, true);
        }
    }

    public void CinemachineShake()
    {
        
    }

    public void SetGameOver()
    {
        gameOver = true;
    }
}
