using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject[] elements;
    public int maxElementAmount;
    public int minElementAmount;

    public GameObject graphicsRoot;

    public AnimatorController animationController;
    public GameObject[] models;
    public Material[] surfaceMaterials;
    public Material[] ringMaterials;
    public Material[] cloudMaterials; 
    
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

        // Set up model
        var model = Instantiate(models[Random.Range(0, models.Length)], graphicsRoot.transform);

        // Set up animator
        var animator = GetComponentInChildren<Animator>();
        animator.runtimeAnimatorController = animationController;

        // Set up materials
        var renderer = GetComponentInChildren<Renderer>();
        var mats = renderer.materials;
        mats[0] = ringMaterials[Random.Range(0, ringMaterials.Length)];
        mats[1] = cloudMaterials[Random.Range(0, cloudMaterials.Length)];
        mats[2] = surfaceMaterials[Random.Range(0, surfaceMaterials.Length)];
        mats[3] = cloudMaterials[Random.Range(0, cloudMaterials.Length)];
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

        foreach (var e in fac.GetRandomElements(numberOfElements))
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
