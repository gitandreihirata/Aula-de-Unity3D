using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class S_PlayerHUD : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public UnityEngine.UI.Slider healthBar;

    public void SetPlayer(PlayerInput playerInput)
    {
        string[] nomes = { "Aguinha", "Foguinho", "Terrinha", "Arzinho" };
        int index = playerInput.playerIndex;

        if (playerNameText != null)
            playerNameText.text = nomes[index];

        // A barra de vida pode ser atualizada a partir de outro script (ex: S_PlayerHealth)
    }
}