using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : ItemBase
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Hover()
    {
        _spriteRenderer.color = Color.gray;
    }

    public override void UnHover()
    {
        _spriteRenderer.color = Color.white;
    }
}
