using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Crafter : MonoBehaviour {

    public GameObject left;
    public GameObject right;

    private Element[] _items;
    private ElementFactory _elements;

    void Awake()
    {
        _items = new Element[2];
        left.SetActive(false);
        right.SetActive(false);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCraftingItem(Element element)
    {
        if (_items[0] == null)
        {
            _items[0] = element;
            left.SetActive(true);
            left.GetComponent<Image>().sprite = element.sprite;

            print("craft 0: " + element);
        }
        else if (_items[1] == null)
        {
            _items[1] = element;
            right.SetActive(true);
            right.GetComponent<Image>().sprite = element.sprite;

            print("craft 1: " + element);
        }
    }

    public void Craft()
    {

    }

    public void Cancel()
    {
        var inv = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Inventory>();
        var d = new Dictionary<Element, int>();
        foreach (var item in _items.Where(e => e != null))
        {
            if (d.ContainsKey(item))
            {
                d[item]++;
            }
            else
            {
                d.Add(item, 1);
            }
        }
        inv.AddElements(d);

        Clear();
    }

    private void Clear()
    {
        foreach (var go in new[] { left, right })
        {
            go.GetComponent<Image>().sprite = null;
            go.SetActive(false);
        }
        _items = new Element[2];
    }
}
