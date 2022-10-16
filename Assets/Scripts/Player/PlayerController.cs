using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private PlayerAnimations animations;
    private PlayerMovement movement;

    [SerializeField] private Transform ritual_spawn_point;
    [SerializeField] private Transform mirror_world_spawn_point;

    public bool can_fall;

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

        SceneController.instance.PlayAnimation("fade_in");

 

        yield return new WaitForSeconds(animations.animator.GetCurrentAnimatorStateInfo(0).length + 1f);

        TeleportPlayer(spawn_point.position);

        SceneController.instance.PlayAnimation("fade_out");

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MirrorWorld_1") ||
           collision.CompareTag("MirrorWorld_2") ||
           collision.CompareTag("MirrorWorld_3")) can_fall = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MirrorWorld_1") ||
         collision.CompareTag("MirrorWorld_2") ||
         collision.CompareTag("MirrorWorld_3")) can_fall = false;


        if (collision.CompareTag("MirrorWorld_death") && can_fall) StartCoroutine(OnDeath("Fall", mirror_world_spawn_point));
    }
  
}

