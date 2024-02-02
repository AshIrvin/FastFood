using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    internal static Action<Waypoint.Waypoints> OnGoToWaypoint;
    internal static Action OnAutoNextWaypoint;
    internal static Action<bool> OnAutoMode;
    
    internal bool _setAvatarToAutoMove = false;

    [SerializeField] private KeyCode _mapKey = KeyCode.M;
    [SerializeField] private GameObject _mapCanvas;
    [SerializeField] private Camera[] _cameras;

    private void Update()
    {
        if (Input.GetKeyDown(_mapKey))
        {
            _mapCanvas.SetActive(!_mapCanvas.activeInHierarchy);
        }
    }

    public void SelectCamera(int n)
    {
        foreach (var cam in _cameras)
        {
            cam.gameObject.SetActive(false);
        }

        _cameras[n].gameObject.SetActive(true);
    }

    public void GoToWaypoint(string message)
    {
        var parsedMessage = (Waypoint.Waypoints)Enum.Parse(typeof(Waypoint.Waypoints), message);
        OnGoToWaypoint?.Invoke(parsedMessage);
    }

    public void AutoNextWaypoint()
    {
        OnAutoNextWaypoint?.Invoke();
    }

    public void SetAvatarToAutoMove(bool state)
    {
        _setAvatarToAutoMove = state;
        OnAutoMode?.Invoke(state);
    }
}
