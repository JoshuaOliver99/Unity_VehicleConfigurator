using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All possible vehicles
/// </summary>
[CreateAssetMenu()]
public class SO_Stock : ScriptableObject
{
    [Header("References")]
    [SerializeField] private SO_Vehicle[] vehicles;
    public SO_Vehicle[] Vehicles
    {
        get { return vehicles; }
        set { vehicles = value; }
    }

    private void OnEnable()
    {
        // Error Handling
        if (vehicles == null) Debug.LogWarning($"{name} {nameof(vehicles)} == null. No vehicles in stock!");

    }
}