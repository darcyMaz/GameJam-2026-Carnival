using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<ParkAttraction> parkAttractions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MaskSwapped(int IllusionState)
    {
        for (int i = 0; i < parkAttractions.Count; i++)
        {
            if (parkAttractions[i] == null)
            {
                Debug.Log("The game manager is holding a ParkAttraction class which is of null value. It was skipped.");
                continue;
            }
            parkAttractions[i].SetIllusionState(IllusionState);
        }
    }

    public void AddParkAttraction(ParkAttraction pa)
    {
        parkAttractions.Add(pa);
    }
    public void RemoveParkAttraction(ParkAttraction pa)
    {
        parkAttractions.Remove(pa);
    }
}