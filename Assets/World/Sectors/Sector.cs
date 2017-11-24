using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sector : MonoBehaviour
{
    public Bounds bounds;
    public EdgeReachedEvent OnEdgeReached { get; private set; }

    private SectorEdge[] _edges;
    private Transform _player;

    void Awake()
    {
        OnEdgeReached = new EdgeReachedEvent();    
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(GameTags.Player).transform;

        _edges = transform.GetComponentsInChildren<SectorEdge>();
        foreach (var edge in _edges)
        {
            edge.ShipEnter.AddListener(() => 
            {
                if (!bounds.Contains(_player.transform.position))
                    return;
                
                OnEdgeReached.Invoke(edge.direction);
            });
        }
    }

    public class EdgeReachedEvent : UnityEvent<Vector3>
    {
    }
}
