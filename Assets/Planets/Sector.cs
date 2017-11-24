using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    void Start()
    {
    }

    void OnTriggerExit(Collider other)
    {
        var ship = other.gameObject.GetComponent<Ship>();
        if (ship == null)
            return;

        print("ship leaving sector!");
    }
}
