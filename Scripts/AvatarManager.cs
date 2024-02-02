using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AvatarManager : MonoBehaviour
{
    [SerializeField] private GameObject _mobilePhoneGameObject;
    [SerializeField] private GameObject _creditCard;
    [SerializeField] private TextMeshPro _mobilePhoneScreenText;
    [SerializeField] private GameObject _rightHand;

    internal Action<Waypoint.Waypoints, Transform> OnReachingWaypoint;
    internal static Action<int> OnPressingOrderScreen;
    internal static Action<string> OnTryingToPay;

    private WaypointManager _waypointManager;
    private Waypoint.Waypoints _currentWaypoint;
    private NavMeshAgent _agent;

    private bool _setAvatarToAutoMove = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _waypointManager = GetComponent<WaypointManager>();

        UiManager.OnAutoNextWaypoint += AutoMoveToNextWaypoint;
        UiManager.OnGoToWaypoint += GotoWaypoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Waypoint")) return;

        var waypoint = other.GetComponent<Waypoint>();

        if (_waypointManager.NextWaypoint != waypoint.WaypointTypes) return;
        
        waypoint.IsWaypointOccupied = true;
        _currentWaypoint = waypoint.WaypointTypes;
        OnReachingWaypoint?.Invoke(waypoint.WaypointTypes, other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Waypoint")) return;

        var waypoint = other.GetComponent<Waypoint>();
        waypoint.IsWaypointOccupied = false;
    }

    private void ToggleAutoMode(bool state)
    {
        _setAvatarToAutoMove = state;
    }

    private void GotoWaypoint(Waypoint.Waypoints waypoint)
    {
        _agent.SetDestination(_waypointManager.GetNextWaypoint(waypoint));
    }

    private void AutoMoveToNextWaypoint()
    { // Ui button will move Avatar to next waypoint
        _agent.SetDestination(_waypointManager.GetNextWaypoint(_currentWaypoint));
    }

    #region Animation Events

    private void GoToNextWaypoint()
    { // Event won't continue if auto mode is off
        if (!_setAvatarToAutoMove) return;

        Debug.Log("GoToNextWaypoint");
        _agent.SetDestination(_waypointManager.GetNextWaypoint(_currentWaypoint));
    }

    private void PressedOrderScreen(int n)
    {
        switch (_waypointManager.NextWaypoint)
        {
            case Waypoint.Waypoints.OrderHere1:
                OnPressingOrderScreen?.Invoke(0);
                break;
            case Waypoint.Waypoints.OrderHere2:
                OnPressingOrderScreen?.Invoke(1);
                break;
        }
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
                _mobilePhoneGameObject.SetActive(true);
                _mobilePhoneGameObject.GetComponent<Animator>().SetBool("Play", true);
                break;
            case "Face Unlocked":
                _mobilePhoneGameObject.transform.position = Vector3.zero;
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
                _mobilePhoneGameObject.SetActive(false);
                _creditCard.SetActive(true);
                _creditCard.GetComponent<Animator>().SetBool("Play", true);
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
