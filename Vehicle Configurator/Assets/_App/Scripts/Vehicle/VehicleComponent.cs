using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleComponent : MonoBehaviour
{
    //[Header("References")]
    //[SerializeField] VehicleRegions vehicleComponent;

    [Header("Customization")]
    [SerializeField] private bool isOptionable = true;
    [SerializeField] private CustomizationOption[] options;

    [Header("Data")]
    private int currOption = 0; // Note: -1 indicates nothing
    private float totalPrice = 0;


    public delegate void CostUpdate();
    public static event CostUpdate OnCostUpdate;

    public bool IsOptionable { get => isOptionable;  private set => isOptionable = value; }
    public float TotalPrice { get => totalPrice; private set => totalPrice = value; }
    public CustomizationOption[] Options { get => options; }
    public CustomizationOption CurrOption
    {
        get
        {
            if (currOption >= 0)
                return options[currOption];
            else
                return null;
        }
    }


    void Start()
    {
        //// Error Handling
        //if (vehicleComponent == null) Debug.LogWarning($"{name} {nameof(vehicleComponent)} == null. Component not identified!");
        if (options == null) Debug.LogWarning($"{name} {nameof(options)} == null. Component has no options");


        foreach (var option in options)
        {
            // Disable all options
            option.GameObject.SetActive(false);

            // Set default material is paintable
            if (option.IsPaintable)
                UpdateActiveMaterial();
        }


        if (isOptionable == true)
            currOption = -1;
        else 
            currOption = 0;

        SetActiveOption(currOption);
    }



    private void SetActiveOption(int index)
    {
        // Deactivate others
        foreach (var option in options)
            option.GameObject.SetActive(false);

        //// if nothing
        //if (index < 0)
        //{
        //    UpdateTotalPrice();
        //    return;
        //}

        // if (options exist && not option "nothing")
        if (options.Length > 0 && index > -1)
            options[index].GameObject.SetActive(true);

        UpdateTotalPrice();
    }


    private void SetActiveMaterial(int index)
    {
        options[currOption].GameObject.GetComponent<Renderer>().material = options[currOption].MaterialOptions[index].Material;
    }
    private void UpdateActiveMaterial()
    {
        options[currOption].GameObject.GetComponent<Renderer>().material = options[currOption].MaterialOptions[options[currOption].CurrMaterialIndex].Material;
            
        
        UpdateTotalPrice();
    }


    private void UpdateTotalPrice()
    {
        totalPrice = 0;

        if (currOption != -1)
        {
            totalPrice += options[currOption].Price;

            // (add material price) Note: this is completely unreadable. 
            if (options[currOption].MaterialOptions.Length > 0)
                totalPrice += options[currOption].MaterialOptions[options[currOption].CurrMaterialIndex].Price; 
        }
        
        OnCostUpdate?.Invoke();
    }



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


    public void NextMaterial()
    {
        if (currOption < 0)
            return;

        if (!options[currOption].IsPaintable)
            return;

        options[currOption].CurrMaterialIndex++;

        if (options[currOption].CurrMaterialIndex >= options[currOption].MaterialOptions.Length)
            options[currOption].CurrMaterialIndex = 0;

        UpdateActiveMaterial();
    }
    public void PrevMaterial()
    {
        if (currOption < 0)
            return;

        if (!options[currOption].IsPaintable)
            return;

        options[currOption].CurrMaterialIndex--;

        if (options[currOption].CurrMaterialIndex < 0)
            options[currOption].CurrMaterialIndex = options[currOption].MaterialOptions.Length - 1;

        UpdateActiveMaterial();
    }
}


[System.Serializable]
public class CustomizationOption
{
    [Header("Item")]
    [SerializeField] private string name;
    //[SerializeField] private string description;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float price;

    [Header("Marerial Options")]
    [SerializeField] private bool isPaintable = false;
    [SerializeField] private CustomizableMaterial[] materialOptions;
    private int currMaterialIndex = 0;

    // Item public
    public string Name { get => name; }
    public GameObject GameObject { get => gameObject; }
    public float Price { get => price; }

    // Material Options public
    public bool IsPaintable { get => isPaintable; }
    public CustomizableMaterial[] MaterialOptions { get => materialOptions; }
    public CustomizableMaterial CurrMaterial { get => materialOptions[currMaterialIndex]; }
    public int CurrMaterialIndex { get => currMaterialIndex; set => currMaterialIndex = value; }


    // Note:
    // putting NextMaterial() and PrevMaterial() here would make this consistent with other classes.
}


[System.Serializable]
public class CustomizableMaterial
{ 
    [SerializeField] private Material material;
    [SerializeField] private float price;

    public Material Material { get => material; }
    public float Price { get => price; }
}

