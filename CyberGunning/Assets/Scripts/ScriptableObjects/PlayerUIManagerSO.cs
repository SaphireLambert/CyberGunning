using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerUIManagerSO", menuName = "ScriptableObjects/UIMangager")]
public class PlayerUIManagerSO : ScriptableObject
{

    public float m_Health;
    
    public float c_Health;

    public float moneyCount;

    [System.NonSerialized]
    public UnityEvent<float> UpdateHealth;

    [System.NonSerialized]
    public UnityEvent<float> UpdateCash;
    private void OnEnable()
    {
        c_Health = m_Health;
        if(UpdateHealth == null)
        {
            UpdateHealth = new UnityEvent<float>();
        }
        if(UpdateCash == null)
        {
            UpdateCash = new UnityEvent<float>();
        }
    }



    public void Decreasehealth(float amount)
    {
        c_Health -= amount;
        UpdateHealth.Invoke(c_Health);
    }

}
