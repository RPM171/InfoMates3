using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform to follow
    public float smoothSpeed = 0.125f; // How quickly the camera follows the player
    public Vector3 offset; // Offset between the player and the camera

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

