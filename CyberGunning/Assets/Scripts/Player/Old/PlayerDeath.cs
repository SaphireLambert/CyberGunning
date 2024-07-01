using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private PlayerUIManagerSO healthManagerSO;

    public void OnCharacterDeath()
    {
        healthManagerSO.c_Health = healthManagerSO.m_Health;
        SceneManager.LoadScene(0);
        this.gameObject.SetActive(true);
    }
}
