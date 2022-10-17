using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VehicleCustomization : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private VehicleComponent body;
    [SerializeField] private VehicleComponent spoiler;
    [SerializeField] private VehicleComponent breaks;
    [SerializeField] private VehicleComponent suspension;
    //[SerializeField] private VehicleComponent windows;
    [SerializeField] private VehicleComponent accessory1;
    [SerializeField] private VehicleComponent accessory2;
    private List<VehicleComponent> vehicleComponents = new();
    
    [Header("Settings")]
    [SerializeField] private float startingPrice = 0;

    [Header("Data")]
    private int currComponentFocus = 0;
    private float totalPrice = 0;

    
    public delegate void ComponentFocusChange(VehicleCustomization currentVehicle);
    public static event ComponentFocusChange OnCustomizationUpdate; // Passing data relating to current vehicle

    public VehicleComponent CurrComponent { get => vehicleComponents[currComponentFocus]; }
    public List<VehicleComponent> Components { get => vehicleComponents; }
    public float TotalPrice { get => totalPrice; }


    private void Start()
    {
        if (body != null) vehicleComponents.Add(body);
        if (spoiler != null) vehicleComponents.Add(spoiler);
        if (breaks != null) vehicleComponents.Add(breaks);
        if (suspension != null) vehicleComponents.Add(suspension);
        if (accessory1 != null) vehicleComponents.Add(accessory1);
        if (accessory2 != null) vehicleComponents.Add(accessory2);

        OnCustomizationUpdate?.Invoke(this);
    }


    private void OnEnable() => VehicleComponent.OnCostUpdate += CalculateTotalPrice;
    private void OnDisable() => VehicleComponent.OnCostUpdate -= CalculateTotalPrice;


    private void CalculateTotalPrice()
    {
        totalPrice = startingPrice;
        foreach (VehicleComponent vehicleComponent in vehicleComponents)
            totalPrice += vehicleComponent.TotalPrice;

        OnCustomizationUpdate?.Invoke(this);
    }



    public void NextComponent() 
    {
        currComponentFocus++;

        if (currComponentFocus >= vehicleComponents.Count)
            currComponentFocus = 0;

        OnCustomizationUpdate?.Invoke(this);
    }
    public void PrevComponent() 
    {
        currComponentFocus--;

        if (currComponentFocus < 0)
            currComponentFocus = vehicleComponents.Count - 1;

        OnCustomizationUpdate?.Invoke(this);
    }

    public void NextOption() => vehicleComponents[currComponentFocus].NextOption();
    public void PrevOption() => vehicleComponents[currComponentFocus].PrevOption();

    public void NextMaterial() => vehicleComponents[currComponentFocus].NextMaterial();
    public void PrevMaterial() => vehicleComponents[currComponentFocus].PrevMaterial();
}
