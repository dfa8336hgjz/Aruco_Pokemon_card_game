using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    public Monster_Health health;
    private Slider healthSlider;

    void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }

    private void updateText()
    {
        if(health.max_health != 0)
        {
            healthSlider.value = health.current_health / health.max_health;
        }
    }
}
