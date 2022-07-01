using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] EntityCurrentRoom player;

    private bool isFollowingPlayer = true;

    private void Update()
    {
        SwitchIsFollowingPlayer();
        CameraBehaviourMethod();
    }

    private void SwitchIsFollowingPlayer()
    {
        if (InputManager.GetInstance().GetLighterPressed())
        {
            if (!isFollowingPlayer)
                isFollowingPlayer = true;
            else
                isFollowingPlayer = false;
        }
    }
    private void CameraBehaviourMethod()
    {
        if (isFollowingPlayer)
            CameraManager.Instance.FollowPlayer();
        else
            CameraManager.Instance.SetCameraState(player.entityCurrentRoom);
    }
}
