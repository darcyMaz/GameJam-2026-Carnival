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

    public void SetIllusionState(int IllusionState)
    {
        state = (IllusionStates)IllusionState;
        ReflectChangedState();
    }

    private void ReflectChangedState()
    {
        // This functon will change the sprite depending on the state.
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