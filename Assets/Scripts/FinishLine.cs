using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    int currentActiveScene;

    void OnEnable() 
    {
        currentActiveScene = SceneManager.GetActiveScene().buildIndex;
    }

void OnTriggerEnter2D(Collider2D other) 
{
    if (other.GetComponentInParent<PlayerController>() == null) { return; }

    StartCoroutine(RestartLevel());
}

IEnumerator RestartLevel()
{
    Debug.Log("You finished the level!");

    yield return new WaitForSeconds(reloadDelay);

    SceneManager.LoadScene(currentActiveScene);
}

}
