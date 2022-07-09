using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;

    public bool interactPressed { get; private set; }
    private bool lighterPressed = false;

    private static InputManager instance;
    private PlayerInputActions input;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Found more than one Input Manager in the scene.");
        instance = this;

        input = new PlayerInputActions();

        SubscribeToInputs();
    }

    public void EnableInput()
    {
        input.Enable();
    }
    public void DisableInput()
    {
        input.Disable();
    }

    public void EnterCutSceneMode()
    {
        input.Gameplay.Movement.performed -= MovePressed;
        input.Gameplay.Lighter.performed -= LighterButtonPressed;
    }

    public void ExitCutSceneMode()
    {
        input.Gameplay.Movement.performed += MovePressed;
        input.Gameplay.Lighter.performed += LighterButtonPressed;
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        moveDirection = input.Gameplay.Movement.ReadValue<Vector2>();
    }
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            interactPressed = true;
        if(context.canceled)
            interactPressed = false;
    }
 
    public void LighterButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            lighterPressed = true;
        if (context.canceled)
            lighterPressed = false;
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public bool GetInteractPressed()
    {
        return interactPressed;
    }
    public bool GetLighterPressed()
    {
        bool result = lighterPressed;
        lighterPressed = false;
        return result;
    }

    public void RegisterInteractPressed()
    {
        interactPressed = false;
    }

    public void InteractTrue()
    {
        interactPressed = true;
    }
    public void InteractFalse()
    {
        interactPressed = false;
    }
    private void SubscribeToInputs()
    {
        input.Gameplay.Movement.performed += MovePressed;
        input.Gameplay.Lighter.performed += LighterButtonPressed;
        input.Gameplay.Interact.performed += ctx => InteractTrue();
        input.Gameplay.Interact.canceled += ctx => InteractFalse();
    }

    private void OnDestroy()
    {
        input.Gameplay.Movement.performed -= MovePressed;
        input.Gameplay.Lighter.performed -= LighterButtonPressed;
        input.Gameplay.Interact.performed -= InteractButtonPressed; 
    }

}