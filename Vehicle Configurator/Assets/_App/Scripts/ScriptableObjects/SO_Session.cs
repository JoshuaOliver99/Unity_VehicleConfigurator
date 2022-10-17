using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data relating to the session.
/// e.g. currently viewing vehicle
/// </summary>
[CreateAssetMenu()]
public class SO_Session : ScriptableObject
{
    [Header("References")]
    [SerializeField] private SO_Stock stock;


    [Header("Data")]
    private SO_Vehicle selectedVehicle;
    private int currSelectedVehicle = 0;


    public delegate void VehicleChange();
    public static event VehicleChange OnVehicleUpdate;
    
    public SO_Vehicle SelectedVehicle { get => selectedVehicle; }
    public SO_Stock Stock { get => stock; }


    private void OnEnable()
    {
        // Initialization
        if (selectedVehicle == null) 
            if (Stock != null) 
                selectedVehicle = stock.Vehicles[0];

        // Error Handling
        if (stock == null) Debug.LogWarning($"{name} {nameof(stock)} == null. Stock asset not assigned!");
        if (selectedVehicle == null) Debug.LogWarning($"{name} {nameof(selectedVehicle)} == null. No vehicle by default!");


        // To Do...
        // Ensure only one type of this object exists.
    }


    public void NextVehicle()
    {
        if (stock.Vehicles.Length <= 1)
            return;

        currSelectedVehicle++;

        if (currSelectedVehicle >= stock.Vehicles.Length)
            currSelectedVehicle = 0;

        selectedVehicle = stock.Vehicles[currSelectedVehicle];

        OnVehicleUpdate?.Invoke();
    }

    public void PrevVehicle()
    {
        if (stock.Vehicles.Length <= 1)
            return;

        currSelectedVehicle--;

        if (currSelectedVehicle < 0)
            currSelectedVehicle = stock.Vehicles.Length - 1;

        selectedVehicle = stock.Vehicles[currSelectedVehicle];

        OnVehicleUpdate?.Invoke();
    }

}
