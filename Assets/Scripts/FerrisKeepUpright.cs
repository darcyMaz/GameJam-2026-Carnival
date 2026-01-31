using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    void LateUpdate()
    {
        // Locks the rotation to 0 (upright) regardless of parent rotation
        transform.rotation = Quaternion.identity;
    }
}