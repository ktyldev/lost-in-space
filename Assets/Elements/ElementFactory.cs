﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementFactory : MonoBehaviour {

    public GameObject[] elements;

    private Element[] _elements;

	// Use this for initialization
	void Start () {
        _elements = elements
            .Select(_ => Instantiate(_, transform).GetComponent<Element>())
            .ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<Element> GetElements(int number)
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            var tmp = _elements[i];
            var r = Random.Range(i, _elements.Length);
            _elements[i] = _elements[r];
            _elements[r] = tmp;
        }

        return _elements.Take(number).ToList();
    }
}