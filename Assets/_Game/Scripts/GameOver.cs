using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private GameObject[] disableOnGameOver;

    void Start()
    {
        GetComponent<Image>().DOFade(0.7f, fadeDuration);
        foreach(GameObject go in disableOnGameOver)
        {
            go.SetActive(false);
        }
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
