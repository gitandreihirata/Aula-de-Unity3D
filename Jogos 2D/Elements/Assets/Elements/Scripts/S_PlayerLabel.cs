using UnityEngine;
using TMPro;

public class S_PlayerLabel : MonoBehaviour
{
    public string playerName = "Player";
    public Transform labelOffset;

    private TextMeshPro label;

    void Start()
    {
        label = GetComponentInChildren<TextMeshPro>();
        if (label != null)
            label.text = playerName;

        if (labelOffset != null)
            label.transform.position = labelOffset.position;
    }

    void Update()
    {
        if (label != null)
            label.transform.rotation = Camera.main.transform.rotation;
    }
}