using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleComponent : MonoBehaviour
{
    [Header("References")]
    [SerializeField] VehicleRegions vehicleComponent;

    [Header("Customization")]
    [SerializeField] private bool isOptionable = true;
    public CustomizationOption[] options;

    private int currOption; // Note: -1 indicates nothing
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


        if (isOptionable == true)
            currOption = -1;
        else 
            currOption = 0;

        SetActiveOption(currOption);
    }

    
    //void ChooseOption(int index)
    //{
    //    options[index].gameObject.SetActive(true);
    //
    //    totalPrice = options[index].price + options[index].selectedMaterial.price;
    //}
    
    
    public void NextOption()
    {
        currOption++;

        if (currOption >= options.Length)
        {
            if (isOptionable)
                currOption = -1;
            else
                currOption = 0;
        }  

        SetActiveOption(currOption);
    }

    public void PrevOption()
    {
        currOption--;

        if(isOptionable)
        {
            if(currOption < -1)
                currOption = options.Length - 1;
        }
        else
        {
            if (currOption < 0)
                currOption = options.Length - 1;
        }

        SetActiveOption(currOption);
    }


    private void SetActiveOption(int index)
    {
        foreach (var option in options)
            option.gameObject.SetActive(false);

        // if nothing
        if (index < 0) 
            return;

        options[index].gameObject.SetActive(true);
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

