using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SectorEdge : MonoBehaviour {

    public Vector3 direction;
    public UnityEvent ShipEnter { get; private set; }

    void Awake()
    {
        ShipEnter = new UnityEvent();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        var ship = other.gameObject.GetComponent<Ship>();
        if (ship == null)
            return;

        ShipEnter.Invoke();
    }
}
