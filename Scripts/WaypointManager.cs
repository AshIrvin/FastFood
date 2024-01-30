using UnityEngine;
using UnityEngine.AI;

public class WaypointManager : MonoBehaviour
{
    //[SerializeField] private Transform _waypointGroup;
    [SerializeField] private Waypoint[] _startPoints;
    [SerializeField] private Waypoint[] _orderPoints;
    [SerializeField] private Waypoint[] _queuePoints;
    [SerializeField] private Waypoint[] _checkoutPoints;
    [SerializeField] private Waypoint[] _waitPoints;
    [SerializeField] private Waypoint[] _pickupPoints;
    [SerializeField] private Waypoint[] _endPoints;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private AnimationManager _animationManager;

    private int _stepProcess = 0;

    private void Start()
    {
        UiManager.onAutoNextWaypoint += QueueTestWaypoints;
    }

    private Vector3 GetNextWaypoint()
    {
        // TODO - animation shouldn't be in here

        switch (_stepProcess)
        {
            case 0:
                _animationManager.PlayAnimation("Standing Idle");
                return _startPoints[Random.Range(0, _startPoints.Length)].transform.position;
            case 1:
                _animationManager.PlayAnimation("Walk_07_Stroll_Loop_IP");
                return _orderPoints[Random.Range(0, _orderPoints.Length)].transform.position;
            case 2:
                _animationManager.PlayAnimation("Walk_07_Stroll_Loop_IP");
                return _queuePoints[Random.Range(0, _queuePoints.Length)].transform.position;
            case 3:
                _animationManager.PlayAnimation("Convo_11_Listening_Loop");
                return _checkoutPoints[Random.Range(0, _checkoutPoints.Length)].transform.position;
            case 4:
                return _waitPoints[Random.Range(0, _waitPoints.Length)].transform.position;
            case 5:
                return _pickupPoints[Random.Range(0, _pickupPoints.Length)].transform.position;
            case 6:
                return _endPoints[Random.Range(0, _endPoints.Length)].transform.position;
        }

        return Vector3.zero;
    }

    private void QueueTestWaypoints()
    {
        _agent.SetDestination(GetNextWaypoint());
        _stepProcess++;

        if (_stepProcess >= 5)
            _stepProcess = 0;
    }
}
