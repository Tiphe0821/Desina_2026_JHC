using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                        // 카메라가 따라갈 대상
    public Vector3 offset = new Vector3(0.0f, 12.0f, -8.0f);

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;
    }
}
