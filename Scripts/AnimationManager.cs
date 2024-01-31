using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    // Player walks into restaurant 
    // Looks at tablets, presses button, 'Out of Order'
    // Walks over and tries the next tablet
    // Slowly walks towards queue
    // Points and orders at till
    // Pays, but is declined
    // Uses other method, accepted
    // walks to wait area
    // Picks up food and walks to exit

    [SerializeField] private GameObject _player;

    private Animator _animator;
    private NavMeshAgent _agent;

    private void Start()
    {
        _animator = _player.GetComponent<Animator>();
        
        _agent = _player.GetComponent<NavMeshAgent>();

        AvatarManager.OnReachingWaypoint += ReachedWaypoint;
    }

    private void LateUpdate()
    {
        if (_agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            _agent.transform.rotation = Quaternion.LookRotation(_agent.velocity.normalized);
        }
    }

    private void PlayAnimator(string animatorName)
    {
        _animator.Play(animatorName, -1); // -1 plays 1st state
    }

    private void ReachedWaypoint(Waypoint.Waypoints waypoint)
    {
        // queue animators or ?
        // create full pay, decline, use other method, accept animation
        // when 1st pay ends, send update to till message

        // each waypoint will have a specific queue of animations to play
        // the walk animation will be for between waypoints

        // create the blend states in the animator
        // activate them when they hit the correct waypoint

        switch (waypoint)
        {
            case Waypoint.Waypoints.None:
                PlayAnimator("StandingIdle");
                break;
            case Waypoint.Waypoints.Start1:
                PlayAnimator("StandingIdle");
                break;
            case Waypoint.Waypoints.Start2:
                PlayAnimator("StandingIdle");
                break;
            case Waypoint.Waypoints.OrderHere1:
                //PlayAnimator("ButtonPushing");
                _animator.SetBool("ButtonPushing", true);

                // show Out of Order
                // Look at next screen?
                break;
            case Waypoint.Waypoints.OrderHere2:
                PlayAnimator("ButtonPushing");
                break;
            case Waypoint.Waypoints.OrderHere3:
                PlayAnimator("ButtonPushing");

                // show Out of Order
                // Look at queue?
                // QueueAnimation("Walk_07_Stroll_Loop_IP");
                break;
            case Waypoint.Waypoints.Queue1b:
                PlayAnimator("Convo_11_Listening_Loop"); 

                // stand still
                // play with phone
                break;
            case Waypoint.Waypoints.Queue1c:
                PlayAnimator("Convo_11_Listening_Loop");
                break;
            case Waypoint.Waypoints.Checkout1:
                PlayAnimator("Convo_11_Listening_Loop");
                break;
            case Waypoint.Waypoints.PickupWait1:
                PlayAnimator("Walk_07_Stroll_Loop_IP");
                break;
            case Waypoint.Waypoints.PickupWait2:
                PlayAnimator("Walk_07_Stroll_Loop_IP");
                break;
            case Waypoint.Waypoints.PickupWait3:
                PlayAnimator("Walk_07_Stroll_Loop_IP");
                break;
            case Waypoint.Waypoints.Pickup1:
                PlayAnimator("Walk_07_Stroll_Loop_IP");
                break;
            case Waypoint.Waypoints.End1:
                PlayAnimator("Walk_07_Stroll_Loop_IP");
                break;
        }
    }
}
