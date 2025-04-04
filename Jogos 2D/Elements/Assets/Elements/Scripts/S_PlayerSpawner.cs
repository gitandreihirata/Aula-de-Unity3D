using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerSpawner : MonoBehaviour
{
    public GameObject prefabAgua;
    public GameObject prefabFogo;

    private int playerCount = 0;

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Novo jogador entrou: " + playerInput.playerIndex);
    }

    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame || Gamepad.all.Count > playerCount)
        {
            if (playerCount == 0)
            {
                PlayerInput.Instantiate(prefabAgua, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[0]);
            }
            else if (playerCount == 1)
            {
                PlayerInput.Instantiate(prefabFogo, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[1]);
            }

            playerCount++;
        }
    }
}
