using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent activateEvent;
    public UnityEvent deactivateEvent;

    private int _gravityItemsOnPlate;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<GravityController>()) return;
        if (_gravityItemsOnPlate == 0)
        {
            activateEvent.Invoke();
        }
            
        _gravityItemsOnPlate++;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<GravityController>()) return;
        _gravityItemsOnPlate--;

        if (_gravityItemsOnPlate == 0)
        {
            deactivateEvent.Invoke();
        }
    }
}