using System;
using UnityEngine;

public class ParkAttraction : MonoBehaviour
{


    public GameManager Manager;
    private IllusionStates state;

    private void OnEnable()
    {
        Manager.AddParkAttraction(this);
    }
    private void OnDisable()
    {
        Manager.RemoveParkAttraction(this);
    }

    public void SetIllusionState()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
