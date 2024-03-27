using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Attack : MonoBehaviour
{
    [HideInInspector]
    public int current_attack = 0;
    [HideInInspector]
    public int base_attack = 0;
    private int damage = 0;

    public void updateEvolAttack(int base_atk)
    {
        current_attack += base_atk - base_attack;
        base_attack = base_atk;
    }

    public void buffAttack()
    {
        current_attack += 500;
    }
    public void decreaseAttack()
    {
        current_attack -= 500;
        if(current_attack < 0)
            current_attack = 0;
    }
}
