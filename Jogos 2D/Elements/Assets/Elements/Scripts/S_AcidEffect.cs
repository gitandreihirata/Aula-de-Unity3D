using UnityEngine;

public class S_AcidEffect : MonoBehaviour
{
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1f + Mathf.Sin(Time.time * 5f) * 0.05f;
        transform.localScale = originalScale * scale;
    }
}
