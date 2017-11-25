using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementRow : MonoBehaviour
{
    public GameObject elementItem;
    public RectTransform[] itemLocations;

    private ElementItem[] _items;
    private Inventory _inventory;
    private int _currentIndex;

    private void Awake()
    {
        _items = new ElementItem[itemLocations.Length];
    }

    // Use this for initialization
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Inventory>();
        _inventory.OnChange.AddListener(Populate);
        Populate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Forward()
    {
        if (_currentIndex + itemLocations.Length > _inventory.GetContents().Length)
            return;

        _currentIndex += itemLocations.Length;
        Populate();
    }

    public void Back()
    {
        if (_currentIndex - itemLocations.Length < 0)
            return;

        _currentIndex -= itemLocations.Length;
        Populate();
    }

    private void Populate()
    {
        print("repopulating items");
        _items.Where(_ => _ != null)
            .ToList()
            .ForEach(_ => Destroy(_.gameObject));

        var invContent = _inventory.GetContents();

        for (int i = 0; i < itemLocations.Length; i++)
        {
            ElementItem eItem;
            if (i >= invContent.Length)
            {
                eItem = Instantiate(elementItem, itemLocations[i]).GetComponent<ElementItem>();
            }
            else
            {
                var e = invContent[i + _currentIndex];
                eItem = Instantiate(elementItem, itemLocations[i]).GetComponent<ElementItem>();
                eItem.Element = e.Key;
                eItem.Amount = e.Value;

            }

            _items[i] = eItem;
        }
    }
}
