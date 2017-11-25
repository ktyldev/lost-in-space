using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Crafter : MonoBehaviour
{

    public GameObject left;
    public GameObject right;
    public GameObject craftButton;

    private Element[] _items;
    private ElementFactory _elements;
    private UnityEvent _OnAddItem;
    private Inventory _inventory;

    void Awake()
    {
        _OnAddItem = new UnityEvent();
        _items = new Element[2];
        left.SetActive(false);
        right.SetActive(false);
    }

    void Start()
    {
        _elements = GameObject.FindGameObjectWithTag(GameTags.Elements).GetComponent<ElementFactory>();
        _inventory = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Inventory>();

        craftButton.GetComponent<Button>().interactable = false;

        _OnAddItem.AddListener(() =>
        {
            foreach (var item in _items)
            {
                if (item == null)
                    return;
            }
            
            craftButton.GetComponent<Button>().interactable = _elements.ElementExists(_items[0].atomicNumber + _items[1].atomicNumber);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCraftingItem(Element element)
    {
        if (_items[0] == null)
        {
            _items[0] = element;
            left.SetActive(true);
            left.GetComponent<Image>().sprite = element.sprite;

            print("craft 0: " + element);
            _OnAddItem.Invoke();
        }
        else if (_items[1] == null)
        {
            _items[1] = element;
            right.SetActive(true);
            right.GetComponent<Image>().sprite = element.sprite;

            print("craft 1: " + element);
            _OnAddItem.Invoke();
        }
    }

    public void Craft()
    {
        var newElement = _elements.GetElement(_items[0].atomicNumber + _items[1].atomicNumber);
        var d = new Dictionary<Element, int>();
        d.Add(newElement, 1);
        _inventory.AddElements(d);

        Clear();
    }

    public void Cancel()
    {
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
        _inventory.AddElements(d);

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
