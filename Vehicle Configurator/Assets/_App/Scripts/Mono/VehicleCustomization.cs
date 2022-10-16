using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCustomization : MonoBehaviour
{
    [SerializeField] private VehicleComponent body;
    [SerializeField] private VehicleComponent spoiler;
    [SerializeField] private VehicleComponent breaks;
    [SerializeField] private VehicleComponent suspension;
    [SerializeField] private VehicleComponent accessory1;
    [SerializeField] private VehicleComponent accessory2;

    VehicleComponent[] vehicleComponents;

    private void Start()
    {
        // Note:
        // some vehicles might not have a component...
        // this needs thinking about

        vehicleComponents = new VehicleComponent[]
        { body, spoiler, breaks, suspension, accessory1, accessory2 };


    }
}
