using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Dictionary<Element, int> _elements;

	// Use this for initialization
	void Start () {
        var fac = GameObject.FindGameObjectWithTag(GameTags.Elements).GetComponent<ElementFactory>();
        _elements = fac.GetElements().ToDictionary(e => e, _ => 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddElements(Dictionary<Element, int> elements)
    {
        foreach (var item in elements)
        {
            AddElement(item.Key.atomicNumber, item.Value);
        }
    }

    void AddElement(int atomicNumber, int amount)
    {
        var element = _elements.Keys.Single(e => e.atomicNumber == atomicNumber);
        _elements[element] += amount;
    }
}
