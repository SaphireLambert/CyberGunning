using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a script for anything other than the player that would need a health bar. 
/// Generally used on enemies is connected to the damageable script rather than a scriptable object in order to let enemies of the
/// same type have different health values.
/// </summary>
public class HealthBarManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    [SerializeField]
    private Damageable damageable;

    private void Update()
    {
        UpdateSliderPercent(damageable.CurrentHealth);
    }

    private void UpdateSliderPercent(float amount)
    {
        healthBarSlider.value = amount;
    }
}
