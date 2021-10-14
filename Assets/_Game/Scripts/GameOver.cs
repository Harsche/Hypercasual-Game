using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private Text highscoreNumber;
    [SerializeField] private Score score;
    [SerializeField] private UIMovement heartUIMovement;
    [SerializeField] private GameObject[] disableOnGameOver;
    private StartScreen startScreen;

    private void Awake()
    {
        startScreen = GetComponent<StartScreen>();
    }

    void Start()
    {

        Globals.Score.SetGameOver();
        foreach (GameObject go in disableOnGameOver)
        {
            go.SetActive(false);
        }

        int score = Score.score;

        if (PlayerPrefs.HasKey("highscore"))
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }

        highscoreNumber.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    private void OnEnable()
    {
        //score.StartTweenFrom();
        heartUIMovement.StartTweenFrom(); 
        startScreen.MoveStart();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in enemies)
        {
            go.SetActive(false);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
