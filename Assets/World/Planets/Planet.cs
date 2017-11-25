using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    private UIManager _ui;

    // Use this for initialization
    void Start()
    {
        _ui = GameObject.FindGameObjectWithTag(GameTags.UI).GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Ship>();
        if (player == null)
            return;

        _ui.ShowMinePlanetText();
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Ship>();
        if (player == null)
            return;

        _ui.HideMinePlanetText();
    }
}
