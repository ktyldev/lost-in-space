using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Vector3 _offset;
    private Transform _tracked;
    
	// Use this for initialization
	void Start () {
        _tracked = GameObject.FindGameObjectWithTag(GameTags.Player).transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = _tracked.position + _offset;
        transform.LookAt(_tracked);
	}
}
