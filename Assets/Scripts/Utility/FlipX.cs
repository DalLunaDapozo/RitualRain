using UnityEngine;

public class FlipX: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public bool EsUnSprite;
    public bool FlipRespetandoElInput;

    private Vector2 scale;

    private void Awake()
    {
        if(EsUnSprite)
            spriteRenderer = GetComponent<SpriteRenderer>();

        scale = transform.localScale;
    }
    private void Update()
    {
        if(FlipRespetandoElInput)
            FlipFollowingInput();
    }
    private void FlipFollowingInput()
    {
        if (InputManager.GetInstance().GetMoveDirection().x < 0)

            transform.localScale = new Vector2(-scale.x, scale.y);


        else if (InputManager.GetInstance().GetMoveDirection().x > 0)

            transform.localScale = new Vector2(scale.x, scale.y);

    }
}
