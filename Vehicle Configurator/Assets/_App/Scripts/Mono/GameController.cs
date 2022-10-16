using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SO_Session session;
    private VehicleCustomization currVehicleCustomization;

    

    private void Start()
    {
        // Note: to do...
        // there should only be one instance of this mono'.
        // Singleton?..

        GameObject newVehicle = Instantiate(session.SelectedVehicle.Vehicle);
        currVehicleCustomization = newVehicle.GetComponentInChildren<VehicleCustomization>();
    }


    #region CurrentVehicle
    public void NextComponent() => currVehicleCustomization.NextComponent();
    public void PrevComponent() => currVehicleCustomization.PrevComponent();
    public void NextOption() => currVehicleCustomization.NextOption();
    public void PrevOption() => currVehicleCustomization.PrevOption();
    public void NextMaterial() => currVehicleCustomization.NextMaterial();
    public void PrevMaterial() => currVehicleCustomization.PrevMaterial();
    #endregion


    #region Session
    public void NextVehicle() => session.NextVehicle();
    public void PrevVehicle() { } //{ session.PrevVehicle(); }
    #endregion

}
