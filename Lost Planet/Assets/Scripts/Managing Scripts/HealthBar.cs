using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthValue;

    public void SetMaxHealth(float _health)
    {
        HealthValue.maxValue = _health;
        HealthValue.value = _health;
    }

    public void UpdateHealth(float _health)
    {
        HealthValue.value = _health;
    }

}
