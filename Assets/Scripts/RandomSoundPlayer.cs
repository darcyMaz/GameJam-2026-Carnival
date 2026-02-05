using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour
{
    [Header("Sound Clips")]
    public AudioClip[] clips; // Drag multiple variations here for realism

    [Header("Timing Settings")]
    public float minWaitTime = 2f; // Minimum time between sounds
    public float maxWaitTime = 7f; // Maximum time between sounds

    [Header("Volume Variation")]
    public float minVolume = 0.8f;
    public float maxVolume = 1.0f;

    private AudioSource audioSource;
    private float timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ResetTimer();
    }

    void Update()
    {
        // Count down
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            PlayRandomSound();
            ResetTimer();
        }
    }

    void PlayRandomSound()
    {
        if (clips.Length == 0) return;

        // Pick a random sound from the list
        int randomIndex = Random.Range(0, clips.Length);

        // Add slight pitch variation to make sound less repetitive
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        // Add volume variation
        float randomVol = Random.Range(minVolume, maxVolume);

        // Play it
        audioSource.PlayOneShot(clips[randomIndex], randomVol);
    }

    void ResetTimer()
    {
        // Pick a random time for the next sound
        timer = Random.Range(minWaitTime, maxWaitTime);
    }
}