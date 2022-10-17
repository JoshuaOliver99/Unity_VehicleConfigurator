using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_VehicleCustomizerUI : MonoBehaviour
{
    [Header("References - Text")]
    [SerializeField] private TMP_Text vehicle;
    [SerializeField] private TMP_Text component;
    [SerializeField] private TMP_Text option;
    [SerializeField] private TMP_Text optionMaterial;
    
    [SerializeField] private TMP_Text componentPrice;
    [SerializeField] private TMP_Text materialPrice;
    [SerializeField] private TMP_Text fullPrice;

    [SerializeField] private TMP_Text orderDetails;

    [Header("References - Buttons")]
    [SerializeField] private GameObject buttonPrevOption;
    [SerializeField] private GameObject buttonNextOption;
    [SerializeField] private GameObject buttonPrevMaterial;
    [SerializeField] private GameObject buttonNextMaterial;

    private void Start()
    {
        // Error Handling
        if (vehicle == null) Debug.LogWarning($"{name} {nameof(vehicle)} == null");
        if (component == null) Debug.LogWarning($"{name} {nameof(component)} == null");
        if (option == null) Debug.LogWarning($"{name} {nameof(option)} == null");
        if (optionMaterial == null) Debug.LogWarning($"{name} {nameof(optionMaterial)} == null");
        if (componentPrice == null) Debug.LogWarning($"{name} {nameof(componentPrice)} == null");
        if (materialPrice == null) Debug.LogWarning($"{name} {nameof(materialPrice)} == null");
        if (fullPrice == null) Debug.LogWarning($"{name} {nameof(fullPrice)} == null");
        if (orderDetails == null) Debug.LogWarning($"{name} {nameof(orderDetails)} == null");

        if (buttonPrevOption == null) Debug.LogWarning($"{name} {nameof(buttonPrevOption)} == null");
        if (buttonNextOption == null) Debug.LogWarning($"{name} {nameof(buttonNextOption)} == null");
        if (buttonPrevMaterial == null) Debug.LogWarning($"{name} {nameof(buttonPrevMaterial)} == null");
        if (buttonNextMaterial == null) Debug.LogWarning($"{name} {nameof(buttonNextMaterial)} == null");
    }
    private void OnEnable() => VehicleCustomization.OnCustomizationUpdate += UpdateUI;
    private void OnDisable() => VehicleCustomization.OnCustomizationUpdate -= UpdateUI;


    private void UpdateUI(VehicleCustomization currVehicle)
    {
        UpdateText(currVehicle);
        UpdateButtons(currVehicle);
    }

    private void UpdateText(VehicleCustomization currVehicle)
    {
        // Vehicle Name
        vehicle.text = currVehicle.name.Split("(Clone)")[0];

        // Component
        component.text = currVehicle.CurrComponent.name;

        // Component Option
        if (currVehicle.CurrComponent.CurrOption == null)
            option.text = "";
        else
            option.text = currVehicle.CurrComponent.CurrOption.Name;

        // Component Option Material
        if (currVehicle.CurrComponent.CurrOption == null)
            optionMaterial.text = "";
        else if (currVehicle.CurrComponent.CurrOption.IsPaintable == false)
            optionMaterial.text = "";
        else 
            optionMaterial.text = currVehicle.CurrComponent.CurrOption.CurrMaterial.Material.name;

        // Component Price
        if (currVehicle.CurrComponent.CurrOption == null)
            componentPrice.text = "/";
        else
            componentPrice.text = "£" + currVehicle.CurrComponent.CurrOption.Price.ToString();

        // Material Price
        if (currVehicle.CurrComponent.CurrOption == null)
            materialPrice.text = "/";
        else if (currVehicle.CurrComponent.CurrOption.IsPaintable == false)
            materialPrice.text = "/";
        else
            materialPrice.text = "£" + currVehicle.CurrComponent.CurrOption.CurrMaterial.Price.ToString();

        // Full Price
        fullPrice.text = "£" + currVehicle.TotalPrice.ToString();


        // Order Details
        orderDetails.text = $"{currVehicle.name.Split("(Clone)")[0]} \n ";
        foreach (var component in currVehicle.Components)
        {
            // Component
            orderDetails.text += $" {component.name}:";
        
            // Option
            if (component.CurrOption == null)
                orderDetails.text += " None Changes";
            else
                orderDetails.text += $" {component.CurrOption.Name}";
        
            // Material
            if (component.CurrOption == null)
                orderDetails.text += "";
            else if (component.CurrOption.IsPaintable == false)
                orderDetails.text += "";
            else
                orderDetails.text += $", {component.CurrOption.CurrMaterial.Material.name}";
        
            // Price
            orderDetails.text += $" - £{component.TotalPrice} \n";
        }
        // Full Price
        orderDetails.text += $"\n £{currVehicle.TotalPrice}";
    }

    private void UpdateButtons(VehicleCustomization currVehicle)
    {
        if (currVehicle.CurrComponent.IsOptionable)
        {
            buttonPrevOption.SetActive(true);
            buttonNextOption.SetActive(true);
        }
        else
        {
            buttonPrevOption.SetActive(false);
            buttonNextOption.SetActive(false);
        }

        if (currVehicle.CurrComponent.CurrOption == null)
        {
            buttonPrevMaterial.SetActive(false);
            buttonNextMaterial.SetActive(false);
        }
        else if (currVehicle.CurrComponent.CurrOption.IsPaintable)
        {
            buttonPrevMaterial.SetActive(true);
            buttonNextMaterial.SetActive(true);
        }
    }
}

