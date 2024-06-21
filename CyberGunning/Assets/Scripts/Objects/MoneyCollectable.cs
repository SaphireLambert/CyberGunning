using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyCollectable : MonoBehaviour
{

    [SerializeField]
    private PlayerUIManagerSO playerUIManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateMoneyCount(100f);
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        playerUIManager.UpdateHealth.AddListener(UpdateMoneyCount);
    }

    private void OnDisable()
    {
        playerUIManager.UpdateHealth.RemoveListener(UpdateMoneyCount);
    }

    public void UpdateMoneyCount(float amount)
    {
        playerUIManager.moneyCount += amount;
    }
}
