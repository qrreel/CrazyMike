using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text youWinText;
    [SerializeField] private Button restartButton;

    Health Health;

    void Awake()
    {
        Health = FindObjectOfType<Health>();
    }

    void Start()
    {
        restartButton.transform.localScale = Vector3.zero;
        gameOverText.transform.localScale = Vector3.zero;
        youWinText.transform.localScale = Vector3.zero;
    }

    public void GameOver()
    {
        restartButton.transform.localScale = Vector3.one;

        if (Health.livesNum == 0) gameOverText.transform.localScale = Vector3.one;
        else youWinText.transform.localScale = Vector3.one;
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
