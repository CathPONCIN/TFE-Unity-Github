using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimerUI : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 360f;
    [SerializeField] private bool isRunning = true;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverPanel;

    private bool isGameOver;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isRunning || isGameOver)
            return;

        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            if(timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                isRunning = false;
                TriggerGameOver();
            }
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        if (timerText == null)
            return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("Temps écoulé");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
