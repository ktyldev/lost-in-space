using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementFactory : MonoBehaviour
{
    public Sprite[] elementSprites;
    public GameObject element;
    public int startingElements = 5;

    private int _availableElements;
    private Element[] _elements;

    void Awake()
    {
        _availableElements = startingElements;   
        elementSprites = ShuffleArray(elementSprites);
        _elements = new Element[elementSprites.Length];
        for (int i = 0; i < elementSprites.Length; i++)
        {
            _elements[i] = MakeElement(i + 1, elementSprites[i]);
        }
    }

    private void Start()
    {
    }

    private IEnumerator IncreaseAvailableElements()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            _availableElements++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool ElementExists(int number)
    {
        return _elements.Length >= number;
    }

    public Element GetElement(int number)
    {
        if (!ElementExists(number))
            throw new System.Exception();

        return _elements[number - 1];
    }

    public Element[] GetElements()
    {
        return _elements;
    }

    public Element[] GetRandomElements(int number)
    {
        var availableElements = _elements
            .Where(e => e.atomicNumber <= _availableElements)
            .ToArray();

        return ShuffleArray(availableElements).Take(number).ToArray();
    }

    private Element MakeElement(int atomicNumber, Sprite sprite)
    {
        var newElement = Instantiate(element, transform).GetComponent<Element>();
        newElement.elementName = sprite.name;
        newElement.sprite = sprite;
        newElement.atomicNumber = atomicNumber;

        print(string.Format("Created element: {0} {1}", newElement.atomicNumber, newElement));
        return newElement;
    }

    private T[] ShuffleArray<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var tmp = array[i];
            var r = Random.Range(i, array.Length);
            array[i] = array[r];
            array[r] = tmp;
        }

        return array;
    }
}
