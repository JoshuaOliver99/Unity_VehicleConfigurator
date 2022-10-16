using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleComponent : MonoBehaviour
{
    [Header("References")]
    [SerializeField] VehicleRegions vehicleComponent;

    [Header("Customization")]
    [SerializeField] private bool isOptionable = true;
    [SerializeField] private CustomizationOption[] options;

    private CustomizationOption chosenOption;
    private float totalPrice;

    void Start()
    {
        //// Error Handling
        //if (vehicleComponent == null) Debug.LogWarning($"{name} {nameof(vehicleComponent)} == null. Component not identified!");

        
        foreach (var option in options)
        {
            // Disable all options
            option.gameObject.SetActive(false);

            // Set default material is paintable
            if (option.isPaintable)
                option.selectedMaterial = option.materialOptions[0];
        }

        // Enable one if not optionable
        if (isOptionable == false)
            options[0].gameObject.SetActive(true);
    }

    void CycleOption(int direction)
    {
        
    }

    void ChooseOption(int index)
    {
        options[index].gameObject.SetActive(true);

        totalPrice = options[index].price + options[index].selectedMaterial.price;
    }

}

[System.Serializable]
public class CustomizationOption
{
    [Header("Item")]
    public string name;
    //public string description;
    public GameObject gameObject;
    public float price;

    [Header("Marerial Options")]
    public bool isPaintable = false;
    public CustomizableMaterial[] materialOptions;
    public CustomizableMaterial selectedMaterial;
}

[System.Serializable]
public class CustomizableMaterial
{ 
    public Material material;
    public float price;
}

