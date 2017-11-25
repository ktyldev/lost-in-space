using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FuelMaker : MonoBehaviour
{
    public FuelFormula Formula { get; private set; }

    public int updateFormulaTime = 120;
    public GameObject amount1;
    public GameObject element1;
    public GameObject amount2;
    public GameObject element2;

    private ElementFactory _elements;
    private Inventory _inventory;
    
    // Use this for initialization
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Inventory>();
        var button = GetComponent<Button>();
        button.interactable = false;

        _inventory.OnChange.AddListener(() =>
        {
            button.interactable = _inventory.Contains(Formula.Element1, Formula.Amount1) && _inventory.Contains(Formula.Element2, Formula.Amount2);
        });

        _elements = GameObject.FindGameObjectWithTag(GameTags.Elements).GetComponent<ElementFactory>();
        var formulaElements = _elements.GetRandomElements(2);
        Formula = new FuelFormula
        {
            Amount1 = 1,
            Amount2 = 2,
            Element1 = formulaElements[0],
            Element2 = formulaElements[1]
        };

        UpdateDisplay();
        StartCoroutine(UpdateFormula());
    }
    
    private IEnumerator UpdateFormula()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateFormulaTime);

            Formula.Amount1++;
            Formula.Amount2++;

            var formulaElements = _elements.GetRandomElements(2);
            Formula.Element1 = formulaElements[0];
            Formula.Element2 = formulaElements[1];

            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        amount1.GetComponent<Text>().text = Formula.Amount1.ToString();
        element1.GetComponent<Image>().sprite = Formula.Element1.sprite;

        amount2.GetComponent<Text>().text = Formula.Amount2.ToString();
        element2.GetComponent<Image>().sprite = Formula.Element2.sprite;
    }
}
