using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthManager : ScriptableObject
{

    [SerializeField]
    private float m_Health;
    [SerializeField]
    private float c_Health;

    [SerializeField]
    private Slider healthBar;

    [System.NonSerialized]
    public UnityEvent<float> UpdateHealth;

    private void OnEnable()
    {
        c_Health = m_Health;
        if(UpdateHealth == null)
        {
            UpdateHealth = new UnityEvent<float>();
        }
    }

    public void Decreasehealth(float amount)
    {
        c_Health -= amount;
        UpdateHealth.Invoke(c_Health);
    }

}
