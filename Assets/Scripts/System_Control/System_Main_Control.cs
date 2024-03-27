using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// System card: turn, deck
public class System_Main_Control : Card_Abstract
{
    private System_Data data;

    protected override void Awake()
    {
        base.Awake();
        Invoke("getData", 2.0f);
    }

    private void FixedUpdate()
    {
        if (thisAruco && parentTracker)
        {
            if(thisAruco.MarkerId == 0 && firstEnabled)
            {
                parentTracker.checkTurn(this.gameObject);
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void getData()
    {
        Card_data card = GetComponentInParent<Tracker_Control>().jsonSupport.cards[thisAruco.MarkerId];
        data = new System_Data(card);
    }
}
