using UnityEngine;

public class TabletManager : MonoBehaviour
{
    [SerializeField] private SceneServer _sceneServer;
    [SerializeField] private UiManager _uiManager;

    private void Start()
    {
        if (_sceneServer == null)
            Debug.LogError("Missing SceneServer");
    }

    // This method is being received from the tablet?
    // Shouldn't be in an update method?
    // Is it waiting for the tablet to send the method name and string?
    private void AutoMoveToNextWaypoint()
    {
        _sceneServer.CheckLatestRequestString("Request", _uiManager.AutoNextWaypoint);
    }

    private void GoToWaypoint()
    { // This method requires a name of one of the waypoints passed as a string, no spaces. See Waypoint class
        _sceneServer.CheckLatestRequestString("Request", _uiManager.GoToWaypoint);
    }
}
