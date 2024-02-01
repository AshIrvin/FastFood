using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum Waypoints
    {
        None,
        Start1,
        Start2,
        OrderHere1,
        OrderHere2,
        OrderHere3,
        Queue1c,
        Queue1b,
        Checkout1,
        PickupWait1,
        PickupWait2,
        PickupWait3,
        PickupWait4,
        Pickup1,
        End1,
        End2,
        EndSeated1,
        EndSeated2
    }

    public Waypoints WaypointTypes;

    internal bool IsWaypointOccupied;
}
