using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    public event EventHandler BackToBathroom;

    private PlayerAnimations animations;
    private PlayerMovement movement;

    [SerializeField] private Transform ritual_spawn_point;
    [SerializeField] private Transform mirror_world_spawn_point;
    [SerializeField] private SpriteRenderer sprite;

    public bool can_fall;
    public bool is_hidden;
    public bool is_well_hidden;
    
    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        if (!GameManager.Instance.testMode) GameManager.Instance.OnBeforeStateChanged += OnChangeState;
        else EnableInputAndGameplay();
    }
    
    private void OnChangeState(GameState state)
    {
        switch(state)
        {
            case GameState.Starting:

                StartCoroutine(OnSpawnCoroutine());

                break;
        }
    }

    private IEnumerator OnSpawnCoroutine()
    {

        transform.position = ritual_spawn_point.position;
        
        animations.PlayAnimation("Spawn");
        
        
        yield return new WaitForSeconds(animations.animator.GetCurrentAnimatorStateInfo(0).length + 0.2f);

        EnableInputAndGameplay();
    }
    private IEnumerator OnDeath(string death_name, Transform spawn_point)
    {
        InputManager.GetInstance().DisableInput();
        movement.SetMovementToZero();
        animations.PlayAnimation(death_name);

        yield return new WaitForSeconds(animations.animator.GetCurrentAnimatorStateInfo(0).length);

        SceneController.instance.PlayAnimation("fade_in", 1f);

 

        yield return new WaitForSeconds(animations.animator.GetCurrentAnimatorStateInfo(0).length + 1f);

        TeleportPlayer(spawn_point.position);

        SceneController.instance.PlayAnimation("fade_out", 1f);

        yield return new WaitForSeconds(animations.animator.GetCurrentAnimatorStateInfo(0).length + 1f);
       
        
        EnableInputAndGameplay();

    }
    private void EnableInputAndGameplay()
    {
        InputManager.GetInstance().EnableInput();
        GameManager.Instance.ChangeState(GameState.Gameplay);
    }
    
    public void TeleportPlayer(Vector3 newPos)
    {
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackToBath")) BackToBathroom?.Invoke(this, EventArgs.Empty); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MirrorWorld_1") ||
           collision.CompareTag("MirrorWorld_2") ||
           collision.CompareTag("MirrorWorld_3")) can_fall = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MirrorWorld_1") ||
         collision.CompareTag("MirrorWorld_2") ||
         collision.CompareTag("MirrorWorld_3")) can_fall = false;


        if (collision.CompareTag("MirrorWorld_death") && can_fall) StartCoroutine(OnDeath("Fall", mirror_world_spawn_point));
    }

    public void PlayAnimation(string animation)
    {
        animations.animator.Play(animation);
    }

    public void TriggerSpawnAnimation()
    {
        animations.animator.SetTrigger("spawn");
    }

    public void ToggleSprite(bool value)
    {
        sprite.gameObject.SetActive(value);
    }

}

