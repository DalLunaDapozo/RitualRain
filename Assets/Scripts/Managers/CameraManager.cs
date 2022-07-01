using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] CinemachineVirtualCamera[] cameras;

    public void FollowPlayer()
    {
        AllCamerasPriorityToZero();

        for (int i = 0; i < cameras.Length; i++)
            if (cameras[i].name == "FollowPlayer")
                cameras[i].Priority = 1;
    }
    public void SetCameraState(CurrentRoom name)
    {
        AllCamerasPriorityToZero();

        for (int i = 0; i < cameras.Length; i++)
            if (cameras[i].name == name.ToString())
                cameras[i].Priority = 1;
    }

    private void AllCamerasPriorityToZero()
    {
        for (int i = 0; i < cameras.Length; i++)
            if (cameras[i].Priority > 0)
                cameras[i].Priority = 0;
    }
}

