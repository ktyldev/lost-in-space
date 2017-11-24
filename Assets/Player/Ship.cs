using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var moveDirection = new Vector3(
            Input.GetAxis(GameTags.Horizontal),
            0,
            Input.GetAxis(GameTags.Vertical)).normalized;
        
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
