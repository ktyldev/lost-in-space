using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFactory : MonoBehaviour
{
    public GameObject sector;

    private List<Sector> _sectors;

    void Awake()
    {
        _sectors = new List<Sector>();    
    }

    // Use this for initialization
    void Start()
    {
        // Generate starting sector
        _sectors.Add(GenerateSector(Vector3.zero));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GenerateSectors()
    {
        print("Polling sector generation");
        yield return new WaitForSeconds(1);
    }

    private Sector GenerateSector(Vector3 position)
    {
        var newSector = Instantiate(sector, transform).GetComponent<Sector>();
        newSector.transform.position = position;
        newSector.OnEdgeReached.AddListener(d =>
        {
            print("reached edge of sector " + d);
        });

        return newSector;
    }
}
