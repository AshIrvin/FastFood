using System;
using UnityEngine;
using UnityEngine.AI;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] private Waypoint[] _startPoints;
    [SerializeField] private Waypoint[] _orderPoints;
    [SerializeField] private Waypoint[] _queuePoints;
    [SerializeField] private Waypoint[] _checkoutPoints;
    [SerializeField] private Waypoint[] _waitPoints;
    [SerializeField] private Waypoint[] _pickupPoints;
    [SerializeField] private Waypoint[] _endPoints;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private AnimationManager _animationManager;

    internal Vector3 GetNextWaypoint(Waypoint.Waypoints currentWaypoint)
    {
        Debug.Log("current Waypoint: " + currentWaypoint);
        var nextWaypoint = (Waypoint.Waypoints)(((int)currentWaypoint + 1) % Enum.GetNames(typeof(Waypoint.Waypoints)).Length);
        Debug.Log("Next Waypoint: " + nextWaypoint);

        switch (nextWaypoint)
        {
            case Waypoint.Waypoints.None: 
                return _startPoints[0].transform.position;
            case Waypoint.Waypoints.Start1: 
                return _startPoints[0].transform.position;
            case Waypoint.Waypoints.Start2: 
                return _startPoints[1].transform.position;
            case Waypoint.Waypoints.OrderHere1: 
                return _orderPoints[0].transform.position;
            case Waypoint.Waypoints.OrderHere2: 
                return _orderPoints[1].transform.position;
            case Waypoint.Waypoints.OrderHere3: 
                return _orderPoints[2].transform.position;
            case Waypoint.Waypoints.Queue1c: 
                return _queuePoints[0].transform.position;
            case Waypoint.Waypoints.Queue1b: 
                return _queuePoints[1].transform.position;
            case Waypoint.Waypoints.Checkout1: 
                return _checkoutPoints[0].transform.position;
            case Waypoint.Waypoints.PickupWait1: 
                return _waitPoints[0].transform.position;
            case Waypoint.Waypoints.PickupWait2: 
                return _waitPoints[1].transform.position;
            case Waypoint.Waypoints.PickupWait3: 
                return _waitPoints[2].transform.position;
            case Waypoint.Waypoints.PickupWait4:
                return _waitPoints[3].transform.position;
            case Waypoint.Waypoints.Pickup1: 
                return _pickupPoints[0].transform.position;
            case Waypoint.Waypoints.End1: 
                return _endPoints[0].transform.position;
            case Waypoint.Waypoints.End2: 
                return _endPoints[1].transform.position;
        }

        return Vector3.zero;
    }
}
