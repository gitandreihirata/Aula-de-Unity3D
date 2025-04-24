using UnityEngine;

public class S_Gates : MonoBehaviour
{
    public GameObject gate;
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogWarning("S_Gates: Nenhum SpriteRenderer encontrado no objeto.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireMan") || collision.CompareTag("WaterGirl"))
        {
            gate.SetActive(false);
            if (spriteRenderer != null && pressedSprite != null)
                spriteRenderer.sprite = pressedSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FireMan") || collision.CompareTag("WaterGirl"))
        {
            gate.SetActive(true);
            if (spriteRenderer != null && defaultSprite != null)
                spriteRenderer.sprite = defaultSprite;
        }
    }
}