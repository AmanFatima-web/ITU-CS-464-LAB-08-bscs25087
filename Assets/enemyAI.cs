
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 5f;
    public float detectionRange = 12f;
    public float chaseDuration = 12f;
    public float stopDistance = 1.5f;

    private float chaseTimer = 0f;

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        if (distance <= detectionRange)
        {
            chaseTimer = chaseDuration;
        }
        else if (chaseTimer > 0)
        {
            chaseTimer -= Time.deltaTime;
        }

        if (chaseTimer > 0 && distance > stopDistance)
        {
            transform.position += direction.normalized *
                                  moveSpeed * Time.deltaTime;

            transform.forward = direction.normalized;
        }
    }
}
