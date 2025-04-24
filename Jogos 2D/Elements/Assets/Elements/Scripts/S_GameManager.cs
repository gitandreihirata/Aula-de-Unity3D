using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;
    public GameObject hudPrefab;
    public Transform hudParent;
    public Color[] playerColors;
    public string[] playerNames = { "WaterGirl", "FireMan", "Earthling", "AirKid" };

    private int nextIndex = 0;
    private InputAction joinAction;
    private HashSet<InputDevice> joinedDevices = new HashSet<InputDevice>();

    //reinicializar os controles ou o joinAction na nova fase.
    void Awake()
    {
        nextIndex = 0;
        joinedDevices.Clear();

        // Garante que o tempo volta ao normal e controles reiniciam ao trocar de cena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;
        // Reset de estado se precisar
        nextIndex = 0;
        joinedDevices.Clear();
    }

    private void OnEnable()
    {
        joinAction = new InputAction(binding: "<Gamepad>/start");
        joinAction.AddBinding("<Keyboard>/enter");
        joinAction.performed += ctx => TryAddPlayer(ctx.control.device);
        joinAction.Enable();
    }

    private void OnDisable()
    {
        joinAction.Disable();
    }

    void TryAddPlayer(InputDevice device)
    {
        if (nextIndex >= playerPrefabs.Length ||
            nextIndex >= spawnPoints.Length ||
            nextIndex >= playerColors.Length ||
            nextIndex >= playerNames.Length)
        {
            Debug.LogError("Índice fora do intervalo. Verifique os arrays de prefabs, spawnPoints, cores e nomes.");
            return;
        }

        if (joinedDevices.Contains(device))
        {
            Debug.Log("Esse dispositivo já foi usado para instanciar um jogador.");
            return;
        }

        joinedDevices.Add(device);

        var playerInput = PlayerInput.Instantiate(
            playerPrefabs[nextIndex],
            playerIndex: nextIndex,
            controlScheme: null,
            splitScreenIndex: -1,
            pairWithDevice: device
        );

        playerInput.transform.position = spawnPoints[nextIndex].position;

        var custom = playerInput.GetComponent<S_PlayerCustomization>();
        if (custom != null)
        {
            custom.ApplyCustomization(playerNames[nextIndex], playerColors[nextIndex]);
        }

        GameObject hud = Instantiate(hudPrefab, hudParent);
        var hudScript = hud.GetComponent<S_PlayerHUD>();
        if (hudScript != null)
            hudScript.SetPlayer(playerInput);

        nextIndex++;
    }
}