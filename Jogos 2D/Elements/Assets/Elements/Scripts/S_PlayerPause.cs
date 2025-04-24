using UnityEngine.InputSystem;
using UnityEngine;

public class S_PlayerPause : MonoBehaviour
{
    public InputAction pauseAction;

    void OnEnable() => pauseAction.Enable();
    void OnDisable() => pauseAction.Disable();

    void Update()
    {
        if (pauseAction.triggered)
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }
}