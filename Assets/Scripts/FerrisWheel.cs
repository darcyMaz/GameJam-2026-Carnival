using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Rotator : MonoBehaviour
{
    public float speed = 20f;
    public AudioClip wheelSound;
    [Range(0f, 1f)] public float volume = 0.5f;

    private AudioSource audioSource;

    void Update()
    {
        // Rotates the wheel around the Z axis
        transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    void Start()
    {
        // 1. Get the reference to the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // 2. Configure the settings
        audioSource.clip = wheelSound;
        audioSource.loop = true; // Essential for a continuous machine noise
        audioSource.volume = volume;
        audioSource.playOnAwake = true;

        // 3. Start playing
        if (wheelSound != null)
        {
            audioSource.Play();
        }
    }
}