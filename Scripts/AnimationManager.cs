using UnityEngine;
using UnityEngine.AI;
using static Waypoint;

public class AnimationManager : MonoBehaviour
{
    private WaypointManager _waypointManager;
    private AvatarManager _avatarManager;
    private Animator _animator;
    private NavMeshAgent _agent;
    private Transform _waypoint;
    private float _rotationSpeed = 3;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _waypointManager = GetComponent<WaypointManager>();
        _avatarManager = GetComponent<AvatarManager>();

        _avatarManager.OnReachingWaypoint += ReachedWaypoint;
    }

    private void LateUpdate()
    {
        if (IsAgentStopping())
        {
            Quaternion targetRotation = Quaternion.LookRotation(_waypoint.forward);
            _agent.transform.rotation = Quaternion.Slerp(_agent.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private bool IsAgentStopping()
    {
        return (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance &&
            (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f) && _waypoint != null);
    }

    internal void SetAvatarToWalk()
    {
        _animator.SetBool("Walk", true);
        _waypoint = null;
    }

    private void DisableAnimations()
    {
        _animator.SetBool("OrderScreen", false);
        _animator.SetBool("Queue", false);
        _animator.SetBool("Wait", false);
        _animator.SetBool("Walk", false);
        _animator.SetBool("Pickup", false);
        _animator.SetBool("Checkout", false);
        _animator.SetBool("Exit", false);
    }

    private void ReachedWaypoint(Waypoints waypoint, Transform t)
    {
        Debug.Log("ReachedWaypoint: " + waypoint);
        _waypoint = t;

        DisableAnimations();

        switch (waypoint)
        {
            case Waypoints.None:
                break;
            case Waypoints.Start1:
                break;
            case Waypoints.Start2:
                break;
            case Waypoints.OrderHere1:
                _animator.SetBool("OrderScreen", true);
                break;
            case Waypoints.OrderHere2:
                _animator.SetBool("OrderScreen", true);
                break;
            case Waypoints.OrderHere3:
                _animator.SetBool("OrderScreen", true);
                break;
            case Waypoints.Queue1b:
                _animator.SetBool("Queue", true);
                break;
            case Waypoints.Queue1c:
                _animator.SetBool("Queue", true);
                break;
            case Waypoints.Checkout1:
                _animator.SetBool("Checkout", true);
                break;
            case Waypoints.PickupWait1:
                _animator.SetBool("Wait", true);
                break;
            case Waypoints.PickupWait2:
                _animator.SetBool("Wait", true);
                break;
            case Waypoints.PickupWait3:
                _animator.SetBool("Wait", true);
                break;
            case Waypoints.Pickup1:
                _animator.SetBool("Pickup", true);
                break;
            case Waypoints.End1:
                _animator.SetBool("Exit", true);
                break;
            case Waypoints.End2:
                _animator.SetBool("Exit", true);
                break;
            case Waypoints.EndSeated1:
                _animator.SetBool("Sit", true);
                break;
            case Waypoints.EndSeated2:
                _animator.SetBool("Sit", true);
                break;
        }
    }
}
