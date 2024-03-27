using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Action card: Buff attack, buff health, attack, up level
public class Action_Main_Control : Card_Abstract
{
    private Action_data data;
    private bool isTrigger;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Invoke("getData", 2.0f);
        timeGap = 1.2f;
    }
    
    private void OnEnable()
    {
        distance = Time.time - disableTime;
    }

    private void FixedUpdate()
    {
        if (!isTrigger && firstEnabled)
        {
            callTracker();
            isTrigger = true;
        }
        else if (distance > timeGap)
        {
            isTrigger = false;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        disableTime = Time.time;
    }

    protected override void getData()
    {
        Card_data card = GetComponentInParent<Tracker_Control>().jsonSupport.cards[thisAruco.MarkerId];
        data = new Action_data(card);
    }

    protected void callTracker()
    {
        if(thisAruco != null)
        {
            isTrigger = true;
            parentTracker.actionCall(this.gameObject, thisAruco.MarkerId);
        }
    }
}
