using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SO_Session session;


    private void Start()
    {
        Instantiate(session.SelectedVehicle.Vehicle);
    }


    public void NextComponent() { }
    public void PrevComponent() { }
    public void NextOption() { }
    public void PrevOption() { }
    
    

}
