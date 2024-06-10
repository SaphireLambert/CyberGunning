using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    [SerializeField]
    private HealthManagerSO healthManager;


    private void Update()
    {        
        UpdateSliderPercent(healthManager.c_Health);
    }

    private void OnEnable()
    {
        healthManager.UpdateHealth.AddListener(UpdateSliderPercent);
    }

    private void OnDisable()
    {
        healthManager.UpdateHealth.RemoveListener(UpdateSliderPercent);
    }


    private void UpdateSliderPercent(float amount)
    {
        healthBarSlider.value = amount;
    }
}
