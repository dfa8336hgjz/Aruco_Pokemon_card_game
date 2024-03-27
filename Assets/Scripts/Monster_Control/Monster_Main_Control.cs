using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Player's side corresponding to the screen
public enum side
{
    none,
    left,
    right
}

// Monster card
public class Monster_Main_Control : Card_Abstract
{
    [SerializeField]
    private Monster_level level;
    [SerializeField]
    private Monster_Model model;
    [SerializeField]
    private Monster_Attack attack; 
    [SerializeField]
    private Monster_Health health;
    [SerializeField]
    private Monster_Type type;
    [HideInInspector]
    public side playerSide;
    [HideInInspector]
    public bool isAdded;
    [HideInInspector]
    public bool isBuffedAttack = false;

    private int[] evolutionLevel;
    private int evolution;

    private Monster_data data;


    protected override void Awake()
    {
        base.Awake();

        isAdded = false;
        playerSide = side.none;
        Invoke("getData", 0.2f);
    }

    private void OnEnable()
    {
        distance = Time.time - disableTime;  
    }

    private void FixedUpdate()
    {
        // Handle flickering
        if (!isAdded && firstEnabled) parentTracker.add(this);
        else
        {
            if (distance > timeGap)
            {
                parentTracker.updateCurrentMonster(this);
            }
        }

        
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        disableTime = Time.time;
    }

    // Get data from json Supporter
    protected override void getData()
    {
        Card_data card = GetComponentInParent<Tracker_Control>().jsonSupport.cards[thisAruco.MarkerId];
        data = new Monster_data(card);
        type.type = data.type;
        evolutionLevel = data.lvEvol;
        evolution = 0;

        UpdateEvolData();
    }

    void UpdateEvolData()
    {
        Name = data.names[evolution];
        attack.updateEvolAttack(data.attack[evolution]);
        health.updateEvolHealth(data.health[evolution]);
        if(evolution !=0) model.UpdateEvol(evolution);
    }

    public void checkEvolve(int level)
    {
        for(int i = 0; i < evolutionLevel.Length; i++)
        {
            if(level == evolutionLevel[i])
            {
                Annoucement_control.annoucement.setAnnounce
                    (data.names[evolution] + " has evolved to " + data.names[evolution + 1]);
                evolution++;
                UpdateEvolData();
                break;
            }
        }
    }

    public bool checkDeath()
    {
        return health.isDead();
    }

    public string getName()
    {
        return Name;
    }

    public string getAttackText()
    {
        return attack.current_attack.ToString();
    }

    public int getAtkPoint()
    {
        return attack.current_attack;
    }

    public string getLevelText()
    {
        return "Lv " + (level.getLevel()+1).ToString();
    }

    public string getHealthText()
    {
        return health.current_health.ToString() + " / " + health.max_health.ToString();
    }

    public float getHealthRate()
    {
        return health.max_health != 0 ? (float)health.current_health / health.max_health : 0.0f;
    }

    public void buffAttack()
    {
        isBuffedAttack = true;
        attack.buffAttack();
    }
    public void decreaseAttack()
    {
        attack.decreaseAttack();
    }

    public void buffHealth()
    {
        health.buffHealth();
    }

    public void buffLevel()
    {
        level.LevelUp();
    }

    public void decreaseHealth(int amount)
    {
        health.decreaseHealth(amount);
        if (checkDeath())
        {
            Annoucement_control.annoucement.setAnnounce(Name + " has been defeated!");
        }
    }

    public Sprite getTypeSprite()
    {
        return type.typeSymbol;
    }

    public pokeType getType()
    {
        return type.type;
    }

    public int typeCounter(pokeType rivalType)
    {
        return type.counter[(int)rivalType];
    }

}
