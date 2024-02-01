using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AvatarManager : MonoBehaviour
{
    [SerializeField] private GameObject _mobilePhoneGameObject;
    [SerializeField] private TextMeshPro _mobilePhoneScreenText;
    [SerializeField] private GameObject _rightHand;

    internal Action<Waypoint.Waypoints> OnReachingWaypoint;
    internal static Action<int> OnPressingOrderScreen;
    internal static Action<string> OnTryingToPay;

    private WaypointManager _waypointManager;
    private Waypoint.Waypoints _currentWaypoint;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _waypointManager = GetComponent<WaypointManager>();

        UiManager.OnAutoNextWaypoint += GoToNextWaypoint;
        UiManager.OnGoToWaypoint += GotoWaypoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Waypoint")) return;

        var waypoint = other.GetComponent<Waypoint>();
        waypoint.IsWaypointOccupied = true;

        _currentWaypoint = waypoint.WaypointTypes;

        OnReachingWaypoint?.Invoke(waypoint.WaypointTypes);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Waypoint")) return;

        var waypoint = other.GetComponent<Waypoint>();
        waypoint.IsWaypointOccupied = false;
    }

    private void GotoWaypoint(Waypoint.Waypoints waypoint)
    {
        _agent.SetDestination(_waypointManager.GetNextWaypoint(waypoint));
    }

    #region Animation Events

    private void GoToNextWaypoint()
    {
        Debug.Log("GoToNextWaypoint");
        _agent.SetDestination(_waypointManager.GetNextWaypoint(_currentWaypoint));
    }

    private void PressedOrderScreen(int n)
    { // comes from animation event
        Debug.Log("PressedOrderScreen: " + n);
        OnPressingOrderScreen?.Invoke(n);
    }

    private void TryToPayAtCheckout(string text)
    {
        OnTryingToPay?.Invoke(text);
    }

    private void ToggleMobilePhone(string message)
    {
        switch (message)
        {
            case "GrabMobile":
                _mobilePhoneGameObject.transform.SetParent(_rightHand.transform, false);
                _mobilePhoneGameObject.SetActive(true);
                break;
            case "Face Unlocked":
                UpdateMobileScreenText(message, Color.white);
                break;
            case "Pay With Phone":
                UpdateMobileScreenText(message, Color.white);
                break;
            case "Connection Issue":
                UpdateMobileScreenText(message, Color.red);
                break;
            case "Declined":
                UpdateMobileScreenText(message, Color.red);
                break;
            case "Battery Low":
                UpdateMobileScreenText(message, Color.red);
                break;
            case "Pocket":
                _mobilePhoneGameObject.transform.SetParent(_rightHand.transform.root, false);
                _mobilePhoneGameObject.SetActive(false);
                break;
        }
    }

    #endregion Animation Events

    private void UpdateMobileScreenText(string text, Color color)
    {
        _mobilePhoneScreenText.color = color;
        _mobilePhoneScreenText.text = text;
    }
}
