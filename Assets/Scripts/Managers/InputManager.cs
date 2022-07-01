using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    
    private bool interactPressed = false;
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
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }
   
    
    public void LighterButtonPressed(InputAction.CallbackContext context)
    {
        lighterPressed = true;
    }
    public void LighterButtonUnPressed(InputAction.CallbackContext context)
    {
        lighterPressed = false;
    }
    
    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }
    
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
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
    
    private void SubscribeToInputs()
    {
        input.Gameplay.Movement.performed += MovePressed;
        input.Gameplay.Lighter.performed += LighterButtonPressed;
        input.Gameplay.Lighter.canceled += LighterButtonUnPressed;
    }

}