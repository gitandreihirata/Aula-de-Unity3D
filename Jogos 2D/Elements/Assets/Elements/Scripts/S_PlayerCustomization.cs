using UnityEngine;

public class S_PlayerCustomization : MonoBehaviour
{
    public SpriteRenderer bodyRenderer;
    public S_PlayerLabel label;

    public void ApplyCustomization(string playerName, Color playerColor)
    {
        if (bodyRenderer != null)
            bodyRenderer.color = playerColor;

        if (label != null)
            label.playerName = playerName;
    }
}
