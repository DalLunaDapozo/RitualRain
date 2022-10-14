using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] EntityCurrentRoom player;

    public bool canFollowPlayer;

    private void Start()
    {
        canFollowPlayer = false;
    }

    private void Update()
    {
        CameraBehaviourMethod();
    }

    //METODO QUE SWITCHEA EL FOLLOW PLAYER CUANDO SE PRENDE LA LUZ (FEATURE VIEJO)
   /* private void SwitchIsFollowingPlayer()
    {
        if (InputManager.GetInstance().GetLighterPressed())
        {
            if (!isFollowingPlayer)
                isFollowingPlayer = true;
            else
                isFollowingPlayer = false;
        }
    }*/
    private void CameraBehaviourMethod()
    {
        CameraManager.Instance.SetCameraState(player.entityCurrentRoom);
    }
}
