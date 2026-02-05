using UnityEngine;

public class ParkAttraction : MonoBehaviour
{
    private GameManager manager;
    private IllusionStates state;
    private SpriteRenderer sr;

    [Header("Sprites")]
    public Sprite IllusorySprite;   // Mask off / illusion state
    public Sprite VisibleSprite;    // Mask on / true state

    private void Awake()
    {
        // Get the SpriteRenderer on this GameObject
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError($"ParkAttraction '{name}' has no SpriteRenderer!");
        }

        // Find the GameManager automatically
        manager = FindFirstObjectByType<GameManager>();
        if (manager == null)
        {
            Debug.LogError("No GameManager found in the scene!");
        }
    }

    private void OnEnable()
    {
        // Register this attraction with the GameManager
        manager?.AddParkAttraction(this);
        // Sync with current mask state immediately
        ReflectChangedState();
    }

    private void OnDisable()
    {
        manager?.RemoveParkAttraction(this);
    }

    /// <summary>
    /// Called by GameManager to set the illusion state
    /// </summary>
    public void SetIllusionState(int IllusionState)
    {
        state = (IllusionStates)IllusionState;
        ReflectChangedState();
    }

    /// <summary>
    /// Updates the sprite based on the current illusion state
    /// </summary>
    private void ReflectChangedState()
    {
        if (sr == null) return;

        switch (state)
        {
            case IllusionStates.Illusory:
                if (IllusorySprite != null)
                    sr.sprite = VisibleSprite;
                break;
            case IllusionStates.Visible:
                if (VisibleSprite != null)
                    sr.sprite = IllusorySprite;
                break;
        }
    }
}