using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Control : MonoBehaviour
{
    [SerializeField]
    private Player_Control playerLeft;
    [SerializeField]
    private Player_Control playerRight;
    private Action_List action_;

    [HideInInspector]
    public Player_Control takeTurnPlayer;
    [HideInInspector]
    public Player_Control notTakeTurnPlayer;
    [HideInInspector]
    public delegate void GameAction();
    [HideInInspector]
    public static event GameAction gameAction = null;

    void Awake()
    {
        action_ = GetComponent<Action_List>();
    }

    private void FixedUpdate()
    {
        // Call action corresponding to action cards
        if(gameAction != null)
        {
            gameAction();
        }
    }

    private bool checkSide(GameObject card)
    {
        return card.transform.position.x < 0;
    }

    // Add monster for the first time detected to the corresponding side's list
    public void addMonster(GameObject monster)
    {
        Monster_Main_Control m = monster.GetComponent<Monster_Main_Control>();
        if (checkSide(monster) && m.playerSide != side.right)
        {
            playerLeft.addMonster(m);
            return;
        }
        if (!checkSide(monster) && m.playerSide != side.left)
        {
            playerRight.addMonster(m);
            return;
        }
    }

    // Update added monster detected on the screen
    public void updateCurrentMonster(GameObject monster)
    {
        Monster_Main_Control m = monster.GetComponent<Monster_Main_Control>();
        if (m.playerSide == side.left)
        {
            playerLeft.updateCurrentMonster(m);
            return;
        }
        if (m.playerSide == side.right)
        {
            playerRight.updateCurrentMonster(m);
            return;
        }
    }

    // Action called each time an action card is detected
    public void actionCall(int id)
    {
        switch(id){
            case 1:
                gameAction += action_.buffAttack;
                break;
            case 2:
                gameAction += action_.buffHealth;
                break;
            case 3:
                gameAction += action_.ATTACK;
                break;
            case 4:
                gameAction += action_.levelUp;
                break;
            default:
                break;
        }
    }

    // Update player's turn by turn card's side corresponding to the screen
    public void checkTurn(GameObject turn_card)
    {
        playerLeft.takeTurn = checkSide(turn_card);
        playerRight.takeTurn = !playerLeft.takeTurn;
        takeTurnPlayer = checkSide(turn_card) ? playerLeft : playerRight;
        notTakeTurnPlayer = checkSide(turn_card) ? playerRight : playerLeft;
    }
}