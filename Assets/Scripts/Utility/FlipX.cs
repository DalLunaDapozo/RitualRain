using UnityEngine;

public class FlipX: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public bool EsUnSprite;
    public bool FlipRespetandoElInput;

    private void Awake()
    {
        if(EsUnSprite)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(FlipRespetandoElInput)
            FlipFollowingInput();
    }
    private void FlipFollowingInput()
    {
        if (InputManager.GetInstance().GetMoveDirection().x < 0)

            transform.localScale = new Vector2(-1, 1);


        else if (InputManager.GetInstance().GetMoveDirection().x > 0)

            transform.localScale = new Vector2(1, 1);

    }
}
