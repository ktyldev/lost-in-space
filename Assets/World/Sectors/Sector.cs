using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Sector : MonoBehaviour
{
    public int size = 200;

    public GameObject planet;
    public int minPlanets;
    public int maxPlanets;
    public int planetVerticalOffset;
    public int minPlanetSeperation;

    public UnityEvent OnEnter { get; private set; }
    
    void Awake()
    {
        OnEnter = new UnityEvent();
        GeneratePlanets();
    }

    private void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Ship>();
        if (player == null)
            return;

        print("OnEnter");
        OnEnter.Invoke();
    }

    private void GeneratePlanets()
    {
        var planetsToGenerate = Random.Range(minPlanets, maxPlanets);
        var planetPositions = new List<Vector3>();

        var planetsGenerated = 0;
        var failedAttempts = 0;
        while (planetsGenerated < planetsToGenerate && failedAttempts < 5)
        {
            var x = Random.Range(0f, size) - size / 2;
            var y = Random.Range(0f, size) - size / 2;

            var planetPosition = new Vector3(x, planetVerticalOffset, y);
            if (planetPositions.Any(p => Vector3.Distance(p, planetPosition) < minPlanetSeperation))
            {
                failedAttempts++;
                continue;
            }

            planetPositions.Add(planetPosition);
            Instantiate(planet, new Vector3(x, planetVerticalOffset, y), Quaternion.identity, transform);
            planetsGenerated++;
        }
    }
}
