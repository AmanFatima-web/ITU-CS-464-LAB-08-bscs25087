
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int damageAmount = 10;
    public float damageCooldown = 1f;

    [Header("Hit Sound")]
    public AudioSource audioSource;
    public AudioClip enemyHitSound;

    private float nextDamageTime;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY TOUCHING PLAYER");

            if (Time.time >= nextDamageTime)
            {
                TakeDamage(damageAmount);

                if (audioSource != null && enemyHitSound != null)
                {
                    audioSource.PlayOneShot(enemyHitSound);
                    Debug.Log("HIT SOUND PLAYED");
                }
                else
                {
                    Debug.Log("AUDIO SOURCE OR CLIP MISSING");
                }

                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0)
            return;

        currentHealth = Mathf.Max(0, currentHealth - amount);

        GameEvents.OnDamaged(currentHealth);

        if (currentHealth == 0)
        {
            GameEvents.OnDied();
        }
    }
}
