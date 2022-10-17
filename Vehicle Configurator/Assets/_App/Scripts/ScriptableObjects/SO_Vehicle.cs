using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Default data related to a certian vehicle
/// </summary>
[CreateAssetMenu()]
public class SO_Vehicle : ScriptableObject
{
    [Header("References")]
    [SerializeField] private GameObject vehicle;
    public GameObject Vehicle { get => vehicle; }

    // To Do...
    // contain default data relating to this vehicle.

    //[SerializeField] private MaterialCustomizable[] Materials;
    //[SerializeField] private GameObject[] accessories;
}


//[System.Serializable]
//public class MaterialCustomizable
//{
//    //public string title;
//    public VehicleRegions component;
//
//    private Renderer renderer;
//
//    //public Material[] materialOptions;
//    public BodyCustomization[] bodyCustomization;
//}
//
//
//[System.Serializable]
//public class BodyCustomization
//{
//    public VehicleRegions component;
//
//    public bool materialEditable;
//    public Material material;
//
//
//    public float price;
//}
