using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum Waypoints
    {
        None,
        Start1,
        Start2,
        End1,
        End2,
        OrderHere1,
        OrderHere2,
        OrderHere3,
        Queue1b,
        Queue1c,
        Checkout1,
        PickupWait1,
        PickupWait2,
        PickupWait3,
        PickupWait4,
        Pickup1,
    }

    public Waypoints WaypointTypes;

    internal bool WaypointOccupied;
}
