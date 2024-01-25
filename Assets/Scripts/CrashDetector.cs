using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    int currentActiveScene;

void OnEnable() 
{
    currentActiveScene = SceneManager.GetActiveScene().buildIndex;
}

void OnCollisionEnter2D(Collision2D other) 
{
    StartCoroutine(RestartLevel());
}

    IEnumerator RestartLevel()
{
    Debug.Log("You crashed!");

    yield return new WaitForSeconds(reloadDelay);

    SceneManager.LoadScene(currentActiveScene);
}

}
