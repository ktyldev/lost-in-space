using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    private bool _isHidden = true;
    private Animator _animator;
    private ElementRow _row;
    private Element[] _craftingElements;
    private Crafter _crafter;

    private void Awake()
    {
        _craftingElements = new Element[2];    
    }
    
    void Start () {
        _animator = GetComponent<Animator>();
        _row = GetComponentInChildren<ElementRow>();
        _crafter = GetComponentInChildren<Crafter>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isHidden = !_isHidden;
            _animator.SetBool("isHidden", _isHidden);
        }
	}

    public void AddCraftItem(Element element)
    {
        _crafter.AddCraftingItem(element);
    }

    public void Craft()
    {
        print("Craft");
    }

    public void Cancel()
    {
        _crafter.Cancel();
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
