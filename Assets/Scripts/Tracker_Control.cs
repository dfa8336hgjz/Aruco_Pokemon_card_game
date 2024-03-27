using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Call Game_Control's functions each time the cards are detected
public class Tracker_Control : MonoBehaviour
{
    public JsonSupport jsonSupport;
    private Game_Control game_Control;
    private ArucoUnity.Objects.Trackers.ArucoObjectsTracker tracker;

    private void Awake()
    {
        game_Control = GetComponentInParent<Game_Control>();
    }

    public void add(Monster_Main_Control monster)
    {
        game_Control.addMonster(monster.gameObject);
    }

    public void updateCurrentMonster(Monster_Main_Control monster)
    {
       game_Control.updateCurrentMonster(monster.gameObject);
    }

    public void actionCall(GameObject action_card, int id)
    {
       game_Control.actionCall(id);
    }

    public void checkTurn(GameObject action_card)
    {
        game_Control.checkTurn(action_card);
    }
}
