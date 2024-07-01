using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    private Color green = Color.green;
    private Color red = Color.red;

    [SerializeField]
    private PlayerUIManagerSO healthManager;


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
        healthBarSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(red, green, healthBarSlider.normalizedValue);
    }
}
