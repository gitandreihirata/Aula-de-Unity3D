using UnityEngine;

public class S_FinalDoor : MonoBehaviour
{
    public string requiredTag;
    public Sprite spriteFechada;
    public Sprite spriteAberta;

    private bool jogadorNaPorta = false;
    public bool JogadorNaPorta => jogadorNaPorta;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && spriteFechada != null)
            spriteRenderer.sprite = spriteFechada;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(requiredTag))
        {
            jogadorNaPorta = true;
            if (spriteRenderer != null && spriteAberta != null)
                spriteRenderer.sprite = spriteAberta;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(requiredTag))
        {
            jogadorNaPorta = false;
            if (spriteRenderer != null && spriteFechada != null)
                spriteRenderer.sprite = spriteFechada;
        }
    }
}