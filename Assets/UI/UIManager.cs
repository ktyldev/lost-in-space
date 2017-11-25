using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject minePlanetText;
    private GameObject _minePlanetText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMinePlanetText()
    {
        _minePlanetText = Instantiate(minePlanetText, transform);
    }

    public void HideMinePlanetText()
    {
        Destroy(_minePlanetText);
        _minePlanetText = null;
    }
}
