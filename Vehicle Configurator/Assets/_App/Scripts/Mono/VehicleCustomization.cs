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

    public int currComponentFocus = 0;

    public float totalPrice = 0;

    private void Start()
    {
        // Note:
        // some vehicles might not have a component...
        // this needs thinking about

        vehicleComponents = new VehicleComponent[]
        { body, spoiler, breaks, suspension, accessory1, accessory2 };
    }

    private void OnEnable() => VehicleComponent.OnCostUpdate += VehicleComponent_OnCostUpdate;
    private void OnDisable() => VehicleComponent.OnCostUpdate -= VehicleComponent_OnCostUpdate;



    private void VehicleComponent_OnCostUpdate()
    {
        totalPrice = 0;
        foreach (VehicleComponent vehicleComponent in vehicleComponents)
            totalPrice += vehicleComponent.totalPrice;
    }



    public void NextComponent() 
    {
        currComponentFocus++;

        if (currComponentFocus >= vehicleComponents.Length)
            currComponentFocus = 0;
    }
    public void PrevComponent() 
    {
        currComponentFocus--;

        if (currComponentFocus < 0)
            currComponentFocus = vehicleComponents.Length - 1;
    }



    public void NextOption() => vehicleComponents[currComponentFocus].NextOption();
    public void PrevOption() => vehicleComponents[currComponentFocus].PrevOption();

    public void NextMaterial() => vehicleComponents[currComponentFocus].NextMaterial();
    public void PrevMaterial() => vehicleComponents[currComponentFocus].PrevMaterial();
}
