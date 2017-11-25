using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject[] elements;
    public int maxElementAmount;
    public int minElementAmount;

    private UIManager _ui;
    private Dictionary<Element, int> _elements;

    void Awake()
    {
        _elements = new Dictionary<Element, int>();
    }

    // Use this for initialization
    void Start()
    {
        _ui = GameObject.FindGameObjectWithTag(GameTags.UI).GetComponent<UIManager>();
        PopulateElements();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Ship>();
        if (player == null)
            return;

        _ui.ShowMinePlanetText();
    }

    void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Ship>();
        if (player == null)
            return;

        _ui.HideMinePlanetText();
    }

    private void PopulateElements()
    {
        var numberOfElements = Random.Range(0, elements.Length);
        
        for (int i = 0; i < numberOfElements; i++)
        {
            var elementTemplate = elements[Random.Range(0, elements.Length)];

            // Don't add an element the planet already has
            if (_elements.Keys.Any(e => e.atomicNumber == elementTemplate.GetComponent<Element>().atomicNumber))
                continue;
            
            var elementAmount = Random.Range(minElementAmount, maxElementAmount);
            var element = Instantiate(elementTemplate, transform).GetComponent<Element>();

            _elements[element] = elementAmount;
        }
    }
}
