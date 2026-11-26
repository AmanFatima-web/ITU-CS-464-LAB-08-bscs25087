
using UnityEngine;
using UnityEngine.UI;

public class HealthUIListener : MonoBehaviour
{
    public Slider healthSlider;
    public UIManager uiManager;

    void Start()
    {
        if (healthSlider != null)
            healthSlider.value = 100;

        if (uiManager != null)
            uiManager.UpdateHealth(100);
    }

    void OnEnable()
    {
        GameEvents.Damaged += UpdateHealth;
    }

    void OnDisable()
    {
        GameEvents.Damaged -= UpdateHealth;
    }

    void UpdateHealth(int health)
    {
        if (healthSlider != null)
            healthSlider.value = health;

        if (uiManager != null)
            uiManager.UpdateHealth(health);
    }
}

