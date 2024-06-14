using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyCollectable : MonoBehaviour
{

    private TextMeshProUGUI moneycounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Add money to the counter
            //moneycounter.SetText(moneycounter.text + 1);
            //Destroy the money from the scene
            Destroy(gameObject);
        }
    }
}
