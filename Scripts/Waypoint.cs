using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum Waypoints
    {
        None,
        Start1,
        End1,
        OrderHere1,
        OrderHere2,
        Queue1a,
        Queue1b,
        Checkout1,
        PickupWait1,
        Pickup1,
    }

    public Waypoints _waypoints;

}
