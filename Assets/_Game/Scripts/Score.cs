using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class Score : MonoBehaviour
{
    public static int score { get; private set; }
    [SerializeField] private Vector2 scorePosition;
    [SerializeField] private float moveDuration;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeStrength;
    [SerializeField] private int shakeVibrato;
    [SerializeField] private float shakeRandomness;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] float camShakeAmplitude;
    [SerializeField] float camShakeDuration;
    private Vector2 startPos;
    private CinemachineBasicMultiChannelPerlin shake;
    private bool gameOver;
    private Text scoreText;
    private RectTransform myRectTransform;

    void Awake()
    {
        startPos = transform.position;
        shake = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        shake.m_AmplitudeGain = 0f;
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
        Coroutine shakeCoroutine;

        if (!gameOver)
        {
            score += num;
            scoreText.text = score.ToString();
            myRectTransform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, false, true);
            shake.m_AmplitudeGain = camShakeAmplitude;
            shakeCoroutine = StartCoroutine(CinemachineShake());
        }
    }

    public IEnumerator CinemachineShake()
    {
        for(float t = 0; t < 1f; t+=0.1f)
        {
            shake.m_AmplitudeGain = Mathf.Lerp(camShakeAmplitude, 0f, t);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SetGameOver()
    {
        gameOver = true;
    }

    public void StartTweenFrom()
    {
        startPos += new Vector2(+transform.parent.GetComponent<RectTransform>().rect.width / 2, transform.parent.GetComponent<RectTransform>().rect.height / 2);;
        myRectTransform.DOLocalMove(startPos, moveDuration);
    }
}
