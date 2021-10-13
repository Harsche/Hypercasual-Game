using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject enemySpawners;
    private bool touched;

    private void Start()
    {
        if (PlayerPrefs.HasKey("tutorial") && Convert.ToBoolean(PlayerPrefs.GetInt("tutorial")))
        {
            ActivateSpawners();
            Destroy(gameObject);
        }
    }

    public void FadeOut()
    {
        if (!touched)
        {
            StartCoroutine(FadeOutCoroutine());
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        Text text = GetComponent<Text>();
        ActivateSpawners();
        touched = true;

        yield return new WaitForSeconds(2f);
        Tween fade = text.DOFade(0f, 2f);

        yield return fade.WaitForCompletion();
        PlayerPrefs.SetInt("tutorial", 1);
    }

    private void ActivateSpawners()
    {
        enemySpawners.SetActive(true);

    }
}
