using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject[] elements;
    public int maxElementAmount;
    public int minElementAmount;
    public Material[] surfaceMaterials;
    public Material[] ringMaterials;
    
    private UIManager _ui;
    private Dictionary<Element, int> _elements;
    private bool _hasElements;
    
    void Awake()
    {
        _elements = new Dictionary<Element, int>();
        _hasElements = true;
    }

    // Use this for initialization
    void Start()
    {
        _ui = GameObject.FindGameObjectWithTag(GameTags.UI).GetComponent<UIManager>();
        PopulateElements();

        var renderer = GetComponentInChildren<Renderer>();

        var mats = renderer.materials;
        mats[0] = ringMaterials[Random.Range(0, ringMaterials.Length)];
        mats[2] = surfaceMaterials[Random.Range(0, surfaceMaterials.Length)];
        renderer.materials = mats;
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
        var fac = GameObject.FindGameObjectWithTag(GameTags.Elements)
            .GetComponent<ElementFactory>();

        foreach (var e in fac.GetElements(numberOfElements))
        {
            _elements[e] = Random.Range(minElementAmount, maxElementAmount);
        }
    }

    public Dictionary<Element, int> GetElements()
    {
        if (!_hasElements)
            return new Dictionary<Element, int>();

        _hasElements = false;
        return _elements;
    }
}
