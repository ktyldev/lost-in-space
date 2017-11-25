using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    public string elementName;
    public int atomicNumber;
    public Sprite sprite;
    
    public override string ToString()
    {
        return elementName;
    }
}
