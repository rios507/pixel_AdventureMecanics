using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] TimerController timer;
    [SerializeField] float health;
    [SerializeField] Slider Slider;
    float MaxHealth;
    [SerializeField] GameObject panelRestart;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = health;
        Slider.maxValue = MaxHealth;
        Slider.minValue = 0;
        timer.OnTimeFinished += death;
    }
    private void Update()
    {
        Slider.value = health;
    }
    public void death()
    {
        gameObject.SetActive(false);
        Slider.gameObject.SetActive(false);
        panelRestart.SetActive(true);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Slider.gameObject.SetActive(false);
            panelRestart.SetActive(true);
        }
    }
    public void  TakeHealth(float heal)
    {
        health += heal;

        if(health > MaxHealth)
        {
            health = MaxHealth;
        }
    }
}
