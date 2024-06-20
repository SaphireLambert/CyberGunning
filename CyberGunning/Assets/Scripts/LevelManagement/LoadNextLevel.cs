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
<<<<<<< HEAD
        int sceneNumber = Random.Range(1,4);
=======
        int sceneNumber = Random.Range(1,2);
>>>>>>> fd99b039d10ffc5a3397498374804a72d0f108f9
        SceneManager.LoadScene(sceneNumber);
    }
}
