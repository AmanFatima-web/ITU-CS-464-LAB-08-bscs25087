
using UnityEngine;

public class GameStatusListener : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.Paused += HandlePause;
        GameEvents.Resumed += HandleResume;
    }

    void OnDisable()
    {
        GameEvents.Paused -= HandlePause;
        GameEvents.Resumed -= HandleResume;
    }

    void HandlePause()
    {
        Debug.Log("Game Paused Event Received");
    }

    void HandleResume()
    {
        Debug.Log("Game Resumed Event Received");
    }
}
