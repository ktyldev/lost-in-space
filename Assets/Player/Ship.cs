using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public float startFuel;
    public float fuelBurnRate;

    public float FuelRemaining { get; private set; }
    

    // Use this for initialization
    void Start()
    {
        FuelRemaining = startFuel;
    }

    // Update is called once per frame
    void Update()
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

    private Vector3 GetMoveDirection()
    {
        return new Vector3(
            Input.GetAxis(GameTags.Horizontal),
            0,
            Input.GetAxis(GameTags.Vertical)).normalized;
    }
}
