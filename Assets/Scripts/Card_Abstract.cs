using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card_Abstract : MonoBehaviour
{
    [HideInInspector]
    public string tags;

    // Get marker id through aruco objects
    [HideInInspector]
    public ArucoUnity.Objects.ArucoMarker thisAruco;
    // Get tracker to call intermediate function to Game controller
    protected Tracker_Control parentTracker;
    // Name of object
    protected string Name;

    // Time handler for handling flicker
    protected float timeGap = 2.0f;
    protected float disableTime;
    protected float distance;

    // True if the object has been detected for the first time
    protected bool firstEnabled;

    protected virtual void Awake()
    {
        disableTime = 0;
        firstEnabled = false;
        thisAruco = GetComponent<ArucoUnity.Objects.ArucoMarker>();
        parentTracker = GetComponentInParent<Tracker_Control>();
    }

    protected virtual void OnDisable()
    {
        if (!firstEnabled) firstEnabled = true;
    }

    protected abstract void getData();
}
