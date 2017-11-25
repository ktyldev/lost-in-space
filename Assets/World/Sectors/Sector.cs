using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sector : MonoBehaviour
{
    public UnityEvent OnEnter { get; private set; }

    void Awake()
    {
        OnEnter = new UnityEvent();
    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Ship>();
        if (player == null)
            return;

        print("OnEnter");
        OnEnter.Invoke();
    }
}
