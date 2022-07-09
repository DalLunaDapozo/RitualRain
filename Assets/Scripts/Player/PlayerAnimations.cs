using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float VelocidadDeLaAnimacion_Caminar;
    [SerializeField] private float VelocidadDeLaAnimacion_Idle;
    [SerializeField] private float VelocidadDeLaAnimacion_Stealth;

    private bool isMoving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimatorFloat("VelocidadDeLaAnimacion_Caminar", VelocidadDeLaAnimacion_Caminar);       
        SetAnimatorFloat("VelocidadDeLaAnimacion_Idle", VelocidadDeLaAnimacion_Idle);
        SetAnimatorFloat("VelocidadDeLaAnimacion_Stealth", VelocidadDeLaAnimacion_Stealth);

        SetAnimatorBool("isMoving", isMoving);
        SetAnimatorBool("Stealth", !LighterController.lightIsOn);

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
            isMoving = true;
        else
            isMoving = false;        
    }
}
