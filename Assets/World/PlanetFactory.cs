using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetFactory : MonoBehaviour
{
    public GameObject sectorTemplate;
    public int sectorSize = 200;

    private Dictionary<Point, Sector> _sectors;

    void Awake()
    {
        _sectors = new Dictionary<Point, Sector>();
    }

    // Use this for initialization
    void Start()
    {
        GenerateSector(new Point());
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

    private void GenerateNeighbours(Sector sector)
    {
        var currentPoint = _sectors.Single(_ => _.Value == sector).Key;

        var neighborPoints = new[] {
            new Point { X = -1, Y = 1 },
            new Point { X = 0, Y = 1 },
            new Point { X = 1, Y = 1 },
            new Point { X = -1, Y = 0 },
            new Point { X = 1, Y = 0 },
            new Point { X = -1, Y = -1 },
            new Point { X = 0, Y = -1 },
            new Point { X = 1, Y = -1 },
        };

        for (int i = 0; i < neighborPoints.Length; i++)
        {
            var point = neighborPoints[i] + currentPoint;
            // Don't generate sector if it already exists
            if (_sectors.Keys.Any(p => p.Equals(point)))
                continue;
            
            GenerateSector(point);
        }
    }

    private void GenerateSector(Point point)
    {
        var newPosition = new Vector3(
            point.X * sectorSize,
            0,
            point.Y * sectorSize);

        var newSector = Instantiate(sectorTemplate, transform).GetComponent<Sector>();
        newSector.name = string.Format("{0}, {1}", point.X, point.Y);
        newSector.transform.position = newPosition;
        newSector.OnEnter.AddListener(() => GenerateNeighbours(newSector));

        _sectors[point] = newSector;
    }
}
