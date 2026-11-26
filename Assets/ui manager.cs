
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text healthText;
    public GameManager gameManager;
    public GameObject pausePanel;
    public GameObject settingsPanel;

    void Update()
    {
        if (gameManager != null && timerText != null)
        {
            timerText.text = "Time: " +
                Mathf.CeilToInt(gameManager.timeRemaining);
        }
    }

    public void UpdateHealth(int health)
    {
        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    public void OpenPause()
    {
        Debug.Log("OpenPause Called");

        if (pausePanel != null)
            pausePanel.SetActive(true);
        else
            Debug.LogError("Pause Panel is NOT assigned!");

        if (gameManager != null)
            gameManager.PauseGame();
    }

    public void ClosePause()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (gameManager != null)
            gameManager.ResumeGame();
    }

    public void OpenSettings()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
