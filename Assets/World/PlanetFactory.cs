using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetFactory : MonoBehaviour
{
    public GameObject sectorTemplate;

    private Dictionary<Vector2Int, Sector> _sectors;

    void Awake()
    {
        _sectors = new Dictionary<Vector2Int, Sector>();
    }

    // Use this for initialization
    void Start()
    {
        GenerateSector(new Vector2Int());
    }
    
    private void GenerateNeighbours(Sector sector)
    {
        var currentPoint = _sectors.Single(_ => _.Value == sector).Key;

        var neighborPoints = new[] {
            new Vector2Int(-1, 1),
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(-1, 0),
            new Vector2Int(1, 0),
            new Vector2Int(-1, -1),
            new Vector2Int(0, -1),
            new Vector2Int(1, -1)
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

    private void GenerateSector(Vector2Int point)
    {
        var newSector = Instantiate(sectorTemplate, transform).GetComponent<Sector>();
        var newPosition = new Vector3(
            point.x * newSector.size,
            0,
            point.y * newSector.size);

        newSector.name = string.Format("{0}, {1}", point.x, point.y);
        newSector.transform.position = newPosition;
        newSector.OnEnter.AddListener(() => GenerateNeighbours(newSector));

        _sectors[point] = newSector;
    }
}
