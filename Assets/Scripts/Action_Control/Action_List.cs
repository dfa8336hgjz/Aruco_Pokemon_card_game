using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_List : MonoBehaviour
{
    // Current game controller
    [SerializeField] private Game_Control game_Control;
    // 2 players for attacking action
    private Player_Control currentPlayer;
    private Player_Control rivalPlayer;

    private void FixedUpdate()
    {
        // Update current player
        if (game_Control.takeTurnPlayer)
        {
            currentPlayer = game_Control.takeTurnPlayer;
            rivalPlayer = game_Control.notTakeTurnPlayer;
        }
    }
    
    // Buff attack for current player's monster
    public void buffAttack()
    {
        if (currentPlayer != null)
        {
            currentPlayer.buffAttackForCurrentMonster();
        }
        Game_Control.gameAction -= buffAttack;
    }

    // Buff health for current player's monster
    public void buffHealth()
    {
        if (currentPlayer != null)
        {
            currentPlayer.buffHealthForCurrentMonster();
        }
        Game_Control.gameAction -= buffHealth;
    }

    // Up level for current player's monster
    public void levelUp()
    {
        if (currentPlayer != null)
            currentPlayer.upLevelForCurrentMonster();
        Game_Control.gameAction -= levelUp;
    }

    // Current player's monster attack the opponent's monster
    public void ATTACK()
    {
        if ((currentPlayer.getCurrentMonster() != null) && (rivalPlayer.getCurrentMonster() != null))
        {
            Monster_Main_Control takeDamageMonster = rivalPlayer.getCurrentMonster();
            Monster_Main_Control attackingMonster = currentPlayer.getCurrentMonster();
            int adjustDamage = attackingMonster.typeCounter(takeDamageMonster.getType());
            takeDamageMonster.decreaseHealth(attackingMonster.getAtkPoint() + adjustDamage);
            if (adjustDamage > 0) Annoucement_control.annoucement.setAnnounce("Super Effective");
            else if (adjustDamage < 0) Annoucement_control.annoucement.setAnnounce("Not Effective");
        }
        Game_Control.gameAction -= ATTACK;
    }
}
