using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Displayer : MonoBehaviour
{
    private Color backgroundColor = new Color(0.3f, 0.3f, 0.3f, 1f);
    private Monster_Main_Control currentMonster = null;

    // True if the player is having turn card
    private bool takeTurn;

    [SerializeField]
    private Player_Control player_controller;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI Level;
    [SerializeField]
    private TextMeshProUGUI Attack;
    [SerializeField]
    private TextMeshProUGUI Health;
    [SerializeField]
    private Image background;
    [SerializeField]
    private Image type;

    private void FixedUpdate()
    {
        currentMonster = player_controller.getCurrentMonster();
        takeTurn = player_controller.takeTurn;
        updateUI();
    }

    // Update UI per frame
    private void updateUI()
    {
        updateBackground();
        updateName();
        updateLevel();
        updateHealth();
        updateAttack();
        updateType();
    }

    private void updateName()
    {
        if ((currentMonster != null) && (currentMonster.getName() != null))
        {
            Name.text = currentMonster.getName();
        }
        else Name.text = " ";
    }

    public void updateLevel()
    {
        if ((currentMonster != null) && (currentMonster.getLevelText() != null))
        {
            Level.text = currentMonster.getLevelText();
        }
        else Level.text = " ";
    }

    private void updateHealth()
    {
        if ((currentMonster != null) && (currentMonster.getHealthRate() > -1.0f))
        {
            Health.text = currentMonster.getHealthText();
            slider.value = currentMonster.getHealthRate();
        }
        else
        {
            Health.text = " ";
            slider.value = 0.0f;
        }
    }

    private void updateAttack()
    {
        if ((currentMonster != null) && (currentMonster.getAttackText() != null))
        {
            Attack.text = currentMonster.getAttackText();
        }
        else Attack.text = " ";
    }

    private void updateBackground()
    {
        if (takeTurn) background.color = Color.red;
        else background.color = backgroundColor;
    }

    private void updateType()
    {
        if ((currentMonster != null) && (currentMonster.getTypeSprite() != null))
        {
            type.sprite = currentMonster.getTypeSprite();
        }
        else type.sprite = null;
    }

    
}
