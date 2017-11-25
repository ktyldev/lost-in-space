using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public float startFuel;
    public float fuelBurnRate;

    public float FuelRemaining { get; private set; }

    private Inventory _inv;
    private Planet _nearbyPlanet;

    // Use this for initialization
    void Start()
    {
        FuelRemaining = startFuel;
        _inv = GetComponentInChildren<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_nearbyPlanet != null && Input.GetKeyDown(KeyCode.Space))
        {
            print("mining");
            Mine();
        }

        Move();
    }

    private void Move()
    {
        var moveDirection = new Vector3(
            Input.GetAxis(GameTags.Horizontal),
            0,
            Input.GetAxis(GameTags.Vertical)).normalized;

        if (moveDirection == Vector3.zero)
            return;

        FuelRemaining -= fuelBurnRate * Time.deltaTime;

        if (FuelRemaining <= 0)
            return;
        
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        transform.LookAt(transform.position + moveDirection);
    }

    private void Mine()
    {
        _inv.AddElements(_nearbyPlanet.GetElements());
    }

    private Vector3 GetMoveDirection()
    {
        return new Vector3(
            Input.GetAxis(GameTags.Horizontal),
            0,
            Input.GetAxis(GameTags.Vertical)).normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        var planet = other.gameObject.GetComponent<Planet>();
        if (planet != null)
        {
            _nearbyPlanet = planet;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        var planet = other.gameObject.GetComponent<Planet>();
        if (planet == _nearbyPlanet)
        {
            _nearbyPlanet = null;
        }
    }
}
