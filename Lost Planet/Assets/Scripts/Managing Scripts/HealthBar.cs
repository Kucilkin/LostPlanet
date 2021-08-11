using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthValue;  //Reference for the Slider moving the "Health Filling"
    /// <summary>
    /// Sets the MaxValue of the Slider to the maximum HP of the Player. Also sets current value to the Max Value.
    /// </summary>
    /// <param name="_health">Health Value to be set</param>
    public void SetMaxHealth(float _health)
    {
        HealthValue.maxValue = _health;
        HealthValue.value = _health;
    }
    /// <summary>
    /// Updates the Slider's Value to the current Value of the player's HP. Gets called in the HealthSystem of the Player.
    /// </summary>
    /// <param name="_health">Health Value to be set</param>
    public void UpdateHealth(float _health)
    {
        HealthValue.value = _health;
    }

}
