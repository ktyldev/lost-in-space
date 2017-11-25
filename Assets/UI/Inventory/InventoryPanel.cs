using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    private bool _isHidden = true;
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isHidden = !_isHidden;
            _animator.SetBool("isHidden", _isHidden);
        }
	}

    public void Craft()
    {
        print("Craft");
    }
}
