using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HealthManagerSO", menuName = "ScriptableObjects/HealthManager")]
public class HealthManagerSO : ScriptableObject
{

    public float m_Health;
    
    public float c_Health;

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
