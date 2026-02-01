using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<ParkAttraction> parkAttractions;

    public SceneChanger sceneChanger;

    public Timer BarTimer;
    public Timer EyeTimer;

    private void Awake()
    {
        parkAttractions = new List<ParkAttraction>();
    }

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
                Debug.Log("The game manager is holding a ParkAttraction object which is of null value. It was skipped.");
                continue;
            }
            parkAttractions[i].SetIllusionState(IllusionState);
        }

        BarTimer.SwapMask(IllusionState);
        EyeTimer.SwapMask(IllusionState);
    }

    public void AddParkAttraction(ParkAttraction pa)
    {
        parkAttractions.Add(pa);
    }
    public void RemoveParkAttraction(ParkAttraction pa)
    {
        parkAttractions.Remove(pa);
    }


    public void LoadGameScene()
    {
        sceneChanger.ChangeScene("Game");
    }
    public void LoadMainMenu()
    {
        sceneChanger.ChangeScene("Main Menu");
    }
    public void LoadCreditsScene()
    {
        sceneChanger.ChangeScene("Credits");
    }
    public void LoadDeathScene()
    {
        sceneChanger.ChangeScene("Death");
    }
    public void LoadEndScene()
    {
        sceneChanger.ChangeScene("End");
    }
}