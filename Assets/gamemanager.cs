
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 30f;
    public float timeRemaining;
    public bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        timeRemaining = gameDuration;
    }

    void Update()
    {
        if (gameEnded || Time.timeScale == 0f)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            gameEnded = true;

            Debug.Log("PLAYER WON!");

            GameEvents.OnWon();

            Time.timeScale = 0f;
        }
    }

    public void PlayerDied()
    {
        if (gameEnded) return;

        gameEnded = true;
        GameEvents.OnLost();
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        if (!gameEnded && Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            GameEvents.OnPaused();
        }
    }

    public void ResumeGame()
    {
        if (!gameEnded && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            GameEvents.OnResumed();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
