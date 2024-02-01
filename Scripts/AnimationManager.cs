using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    private WaypointManager _waypointManager;
    private AvatarManager _avatarManager;
    private Animator _animator;
    private NavMeshAgent _agent;

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
        if (_agent.velocity.sqrMagnitude > Mathf.Epsilon)
        { // TODO - Needs to face waypoint direction
            Debug.Log("Agent turning.");
            _agent.transform.rotation = Quaternion.LookRotation(_agent.velocity.normalized);
        }
    }

    internal void SetAvatarToWalk()
    {
        _animator.SetBool("Walk", true);
    }

    private void DisableAnimations()
    {
        _animator.SetBool("OrderScreen", false);
        _animator.SetBool("Queue", false);
        _animator.SetBool("Wait", false);
        _animator.SetBool("Walk", false);
        _animator.SetBool("Pickup", false);
        _animator.SetBool("Checkout", false);
    }

    private void ReachedWaypoint(Waypoint.Waypoints waypoint)
    {
        Debug.Log("ReachedWaypoint: " + waypoint);

        DisableAnimations();

        switch (waypoint)
        {
            case Waypoint.Waypoints.None:
                break;
            case Waypoint.Waypoints.Start1:
                break;
            case Waypoint.Waypoints.Start2:
                break;
            case Waypoint.Waypoints.OrderHere1:
                _animator.SetBool("OrderScreen", true);
                break;
            case Waypoint.Waypoints.OrderHere2:
                _animator.SetBool("OrderScreen", true);
                break;
            case Waypoint.Waypoints.OrderHere3:
                _animator.SetBool("OrderScreen", true);
                break;
            case Waypoint.Waypoints.Queue1b:
                _animator.SetBool("Queue", true);
                break;
            case Waypoint.Waypoints.Queue1c:
                _animator.SetBool("Queue", true);
                break;
            case Waypoint.Waypoints.Checkout1:
                _animator.SetBool("Checkout", true);
                break;
            case Waypoint.Waypoints.PickupWait1:
                _animator.SetBool("Wait", true);
                break;
            case Waypoint.Waypoints.PickupWait2:
                _animator.SetBool("Wait", true);
                break;
            case Waypoint.Waypoints.PickupWait3:
                _animator.SetBool("Wait", true);
                break;
            case Waypoint.Waypoints.Pickup1:
                _animator.SetBool("Pickup", true);
                break;
            case Waypoint.Waypoints.End1:
                _animator.SetBool("Walk", true);
                break;
            case Waypoint.Waypoints.End2:
                _animator.SetBool("Walk", true);
                break;
            case Waypoint.Waypoints.EndSeated1:
                _animator.SetBool("Sit", true);
                break;
            case Waypoint.Waypoints.EndSeated2:
                _animator.SetBool("Sit", true);
                break;
        }
    }
}
