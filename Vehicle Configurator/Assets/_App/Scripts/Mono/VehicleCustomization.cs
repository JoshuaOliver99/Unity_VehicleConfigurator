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

    private void Start()
    {
        // Note:
        // some vehicles might not have a component...
        // this needs thinking about

        vehicleComponents = new VehicleComponent[]
        { body, spoiler, breaks, suspension, accessory1, accessory2 };


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


    public void NextOption()
    {
        //if (vehicleComponents[currComponentFocus].options.Length > 1)
            vehicleComponents[currComponentFocus].NextOption();
        //else
        //    print($"{name} {vehicleComponents[currComponentFocus]} only has one option. Call redundant");

    }
    public void PrevOption()
    {
        //if (vehicleComponents[currComponentFocus].options.Length > 1)
            vehicleComponents[currComponentFocus].PrevOption();
        //else
        //    print($"{name} {vehicleComponents[currComponentFocus]} only has one option. Call redundant");
    }
}
