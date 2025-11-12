using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cámaras virtuales")]
    public CinemachineCamera followCamera;
    public CinemachineCamera wideCamera;

    private bool usingFollowCamera = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }

    private void ToggleCamera()
    {
        usingFollowCamera = !usingFollowCamera;

        if (usingFollowCamera)
        {
            followCamera.Priority = 10;
            wideCamera.Priority = 5;
        }
        else
        {
            followCamera.Priority = 5;
            wideCamera.Priority = 10;
        }
    }
}
