using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    [SerializeField]
    private HealthManagerSO healthManager;

    public bool isCharacterAlive = true;
    private void Update()
    {        
        UpdateSliderPercent(healthManager.c_Health);
        if(healthManager.c_Health >= 0)
        {
            isCharacterAlive = false;
        }
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
