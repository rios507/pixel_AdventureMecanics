using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public delegate void UpdateLiveDelegate(float newValue);

    public UpdateLiveDelegate takeDamager;
    public UpdateLiveDelegate takeHealth;


    [SerializeField] TimerController timer;
    [SerializeField] float health;
    public float MaxHealth;
    [SerializeField] GameObject panelRestart;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = health;
        timer.OnTimeFinished += death;
    }
    public void death()
    {
        gameObject.SetActive(false);
        panelRestart.SetActive(true);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        takeDamager?.Invoke(health);
    }
    public void  TakeHealth(float heal)
    {
        health += heal;

        if(health > MaxHealth)
        {
            health = MaxHealth;
        }
        takeHealth?.Invoke(health);
    }
}
