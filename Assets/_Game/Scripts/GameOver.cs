using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private Text highscoreNumber;
    [SerializeField] private GameObject[] disableOnGameOver;

    void Start()
    {
        Globals.Score.SetGameOver();
        GetComponent<Image>().DOFade(0.7f, fadeDuration);
        foreach(GameObject go in disableOnGameOver)
        {
            go.SetActive(false);
        }
        
        int score = Score.score;

        if(PlayerPrefs.HasKey("highscore")  )
        {
            if(score > PlayerPrefs.GetInt("highscore"))
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

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
