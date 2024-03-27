using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Control : MonoBehaviour
{
    [SerializeField] 
    private side playerSide;
    [HideInInspector]
    public bool takeTurn;

    private float period = 0.0f;
    private bool startCount = false;
    private Monster_Main_Control currentMonster = null;
    private List<GameObject> monsterList = new List<GameObject>();

    private void Awake()
    {
        takeTurn = false;
    }

    private void FixedUpdate()
    {
        if(currentMonster && !currentMonster.isActiveAndEnabled)
        {
            if (!startCount)
            {
                startCount = true;
            }
            else
            {
                period += Time.deltaTime;
                if (period > 2.0f)
                {
                    currentMonster = null;
                    startCount = false;
                    period = 0.0f;
                }
            }
        }
        deactivateBuffAttack();
    }

    public void updateCurrentMonster(Monster_Main_Control monster)
    {
        if (!currentMonster)
        {
            currentMonster = monster;
            Annoucement_control.annoucement.setAnnounce
                ("Player " + (playerSide == side.left ? "1" : "2") + " has summoned " + monster.getName());
        }
    }

    public void addMonster(Monster_Main_Control _monster)
    {
        _monster.isAdded = true;
        _monster.playerSide = playerSide;
        monsterList.Add(_monster.gameObject);
       
        if (!currentMonster)
        {
            currentMonster = _monster;
            Annoucement_control.annoucement.setAnnounce
                ("Player "+ (playerSide == side.left? "1": "2") + " has summoned "+ _monster.getName());
        }

    }

    public Monster_Main_Control getCurrentMonster()
    {
        return currentMonster;
    }

    public void buffAttackForCurrentMonster()
    {
        if (currentMonster)
        {
            currentMonster.buffAttack();
        }
    }
    public void buffHealthForCurrentMonster()
    {
        if (currentMonster)
        {
            currentMonster.buffHealth();
        }
    }
    public void upLevelForCurrentMonster()
    {
        if (currentMonster)
        {
            currentMonster.buffLevel();
        }
    }

    private void deactivateBuffAttack()
    {
        if(currentMonster)
            if(!takeTurn && currentMonster.isBuffedAttack)
            {
                currentMonster.isBuffedAttack = false;
                currentMonster.decreaseAttack();
            }
    }
}
