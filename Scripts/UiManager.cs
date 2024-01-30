using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static Action OnWaypointStart1;
    public static Action OnWaypointStart2;

    public static Action OnWaypointOrderHere1;
    public static Action OnWaypointOrderHere2;
    public static Action OnWaypointOrderHere3;

    public static Action OnWaypointQueue1a;
    public static Action OnWaypointQueue1b;
    public static Action OnWaypointQueue1c;

    public static Action OnWaypointWait1;
    public static Action OnWaypointWait2;
    public static Action OnWaypointWait3;

    public static Action OnWaypointPickup;

    public static Action OnWaypointEnd1;
    public static Action OnWaypointEnd2;

    public static Action onAutoNextWaypoint;

    [SerializeField] private KeyCode _mapKey = KeyCode.M;
    [SerializeField] private GameObject _mapCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(_mapKey))
        {
            _mapCanvas.SetActive(!_mapCanvas.activeInHierarchy);
        }
    }

    public void StartHere(int n)
    {
        switch (n)
        {
            case 0:
                OnWaypointStart1?.Invoke(); 
                break;
            case 1: 
                OnWaypointStart2?.Invoke(); 
                break;
        }
    }

    public void AutoNextWaypoint()
    {
        onAutoNextWaypoint?.Invoke();
    }

    public void OrderHereButton(int n)
    {
        OnWaypointOrderHere1?.Invoke();

        switch (n)
        {
            case 0:
                OnWaypointOrderHere1?.Invoke();
                break;
            case 1:
                OnWaypointOrderHere2?.Invoke();
                break;
            case 2:
                OnWaypointOrderHere2?.Invoke();
                break;
        }
    }

    public void QueueHere(int n)
    {
        switch (n)
        {
            case 0:
                OnWaypointQueue1a?.Invoke();
                break;
            case 1:
                OnWaypointQueue1b?.Invoke();
                break;
            case 2:
                OnWaypointQueue1c?.Invoke();
                break;
            default:
                break;
        }
    }

    public void WaitHere(int n)
    {
        switch (n)
        {
            case 0:
                OnWaypointWait1?.Invoke();
                break;
            case 1:
                OnWaypointWait2?.Invoke();
                break;
            case 2:
                OnWaypointWait3?.Invoke();
                break;
            default:
                break;
        }
    }

    public void Pickup()
    {
        OnWaypointPickup?.Invoke();
    }

    public void End(int n)
    {
        switch(n)
        {
            case 0:
                OnWaypointEnd1?.Invoke();
                break;
            case 1:
                OnWaypointEnd2?.Invoke();
                break;
        }
    }
}
