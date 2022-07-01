using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float VelocidadDeLaAnimacion_Caminar;
    [SerializeField] private float VelocidadDeLaAnimacion_Idle;

    private bool isWalking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimatorFloat("VelocidadDeLaAnimacion_Caminar", VelocidadDeLaAnimacion_Caminar);       
        SetAnimatorFloat("VelocidadDeLaAnimacion_Idle", VelocidadDeLaAnimacion_Idle);

        SetAnimatorBool("isWalking", isWalking);

        CheckIfInputAxisisPressed();
    }

    private void SetAnimatorFloat(string animationName, float animationSpeed)
    {
        animator.SetFloat(animationName, animationSpeed);
    }
    private void SetAnimatorBool(string animationName, bool state)
    {
        animator.SetBool(animationName, state);
    }

    private void CheckIfInputAxisisPressed()
    {
        if (InputManager.GetInstance().GetMoveDirection() != Vector2.zero)
            isWalking = true;
        else
            isWalking = false;        
    }
}
