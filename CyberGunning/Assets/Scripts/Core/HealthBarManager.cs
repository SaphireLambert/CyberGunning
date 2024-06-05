using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    private Color lowHP;
    private Color highHP;

    [SerializeField] private Vector3 offset;

    private void Start()
    {
        healthBarSlider.gameObject.SetActive(true);
    }
    private void Update()
    {
        healthBarSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float cHealth, float mHealth)
    {
        healthBarSlider.value = cHealth;
        healthBarSlider.maxValue = mHealth;

        healthBarSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHP, highHP, healthBarSlider.normalizedValue);
    }
    
}
