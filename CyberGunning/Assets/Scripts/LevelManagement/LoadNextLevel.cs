using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadRandomScene();
        }
    }
    void LoadRandomScene()
    {
        int sceneNumber = Random.Range(1,3);
        SceneManager.LoadScene(sceneNumber);
    }
}
