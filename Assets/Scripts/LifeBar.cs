using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] HealthPlayer life;

    [SerializeField] Image bar;
    float maxValue;
    private void Start()
    {
        life.takeDamager += UpdateBar;
        life.takeHealth += UpdateBar;
    }
    public void UpdateBar(float newValue)
    {
        bar.fillAmount = (1/life.MaxHealth) * newValue;
        if(bar.fillAmount <= 0)
        {
            life.death();
        }
    }
}
