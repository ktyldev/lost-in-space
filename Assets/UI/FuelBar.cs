using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private Ship _playerShip;
    private Image _bar;

    // Use this for initialization
    void Start()
    {
        _playerShip = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Ship>();
        _bar = GetComponentInChildren<Image>();
    }

    void OnGUI()
    {
        _bar.fillAmount = _playerShip.FuelRemaining / _playerShip.startFuel;
    }
}
