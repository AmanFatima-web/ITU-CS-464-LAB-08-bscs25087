
using UnityEngine;

public class ResultEventListener : MonoBehaviour
{
    public GameObject resultPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip loseSound;

    void OnEnable()
    {
        GameEvents.Died += HandleDeath;
        GameEvents.Won += ShowWin;
        GameEvents.Lost += ShowLose;
    }

    void OnDisable()
    {
        GameEvents.Died -= HandleDeath;
        GameEvents.Won -= ShowWin;
        GameEvents.Lost -= ShowLose;
    }

    void HandleDeath()
    {
        if (gameManager != null)
            gameManager.PlayerDied();
    }

    void ShowWin()
    {
        resultPanel.SetActive(true);
        winPanel.SetActive(true);
        losePanel.SetActive(false);

        if (audioSource != null && winSound != null)
            audioSource.PlayOneShot(winSound);
    }

    void ShowLose()
    {
        resultPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(true);

        if (audioSource != null && loseSound != null)
            audioSource.PlayOneShot(loseSound);
    }
}
