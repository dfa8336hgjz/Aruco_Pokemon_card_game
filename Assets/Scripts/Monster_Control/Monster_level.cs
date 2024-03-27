using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_level : MonoBehaviour
{
    private Monster_Main_Control control;
    private int level;

    private void Awake()
    {
        control = GetComponentInParent<Monster_Main_Control>();
        level = 0;
    }

    public void LevelUp()
    {
        level++;
        control.buffHealth();
        control.checkEvolve(level);
    }

    public int getLevel()
    {
        return level;
    }
}
