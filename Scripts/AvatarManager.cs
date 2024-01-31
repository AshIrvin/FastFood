using System;
using UnityEngine;
using UnityEngine.AI;

public class AvatarManager : MonoBehaviour
{
    [SerializeField] private WaypointManager _waypointManager;

    internal static Action<Waypoint.Waypoints> OnReachingWaypoint;

    private Waypoint.Waypoints _currentWaypoint;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        UiManager.onAutoNextWaypoint += GetNextWaypoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Waypoint")) return;

        var waypoint = other.GetComponent<Waypoint>();
        waypoint.WaypointOccupied = true;

        _currentWaypoint = waypoint.WaypointTypes;

        OnReachingWaypoint?.Invoke(waypoint.WaypointTypes);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Waypoint")) return;

        var waypoint = other.GetComponent<Waypoint>();
        waypoint.WaypointOccupied = false;
    }

    public void GetNextWaypoint()
    {
        _agent.SetDestination(_waypointManager.GetNextWaypoint(_currentWaypoint));
    }
}
