using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    private bool _isHidden = true;
    private Animator _animator;
    private ElementRow _row;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _row = GetComponentInChildren<ElementRow>();
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

    public void Cancel()
    {
        print("Cancel");
    }

    public void MakeFuel()
    {
        print("Make Fuel");
    }

    public void Forward()
    {
        _row.Forward();
    }

    public void Back()
    {
        _row.Back();
    }
}
