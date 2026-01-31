using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        // Rotates the wheel around the Z axis
        transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}