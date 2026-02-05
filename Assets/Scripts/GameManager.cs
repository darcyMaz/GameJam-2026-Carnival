using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<ParkAttraction> parkAttractions = new();

    private IllusionStates currentState = IllusionStates.Illusory;

    private void Awake()
    {
        parkAttractions.Clear();
    }

    // Called by MaskController
    public void MaskSwapped(int illusionState)
    {
        currentState = (IllusionStates)illusionState;

        for (int i = 0; i < parkAttractions.Count; i++)
        {
            if (parkAttractions[i] == null)
                continue;

            parkAttractions[i].SetIllusionState(illusionState);
        }
    }

    public void AddParkAttraction(ParkAttraction attraction)
    {
        if (!parkAttractions.Contains(attraction))
            parkAttractions.Add(attraction);

        // Sync new attraction to current state
        attraction.SetIllusionState((int)currentState);
    }

    public void RemoveParkAttraction(ParkAttraction attraction)
    {
        parkAttractions.Remove(attraction);
    }

    public IllusionStates GetCurrentState()
    {
        return currentState;
    }
}