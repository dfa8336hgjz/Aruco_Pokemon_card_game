using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Health : MonoBehaviour
{
    [HideInInspector]
    public int max_health = 0;
    [HideInInspector]
    public int current_health = 0;

    public void updateEvolHealth(int max_hp)
    {
        current_health += max_hp - max_health;
        max_health = max_hp; 
    }

    public void buffHealth()
    {
        if (current_health != 0)
        {
            current_health += 500;
            if (current_health > max_health)
                current_health = max_health;

        }
    }
    public void decreaseHealth(int amount)
    {
        current_health -= amount;
        if(current_health < 0)
            current_health = 0;
    }

    public bool isDead()
    {
        return current_health <= 0;
    }
}
