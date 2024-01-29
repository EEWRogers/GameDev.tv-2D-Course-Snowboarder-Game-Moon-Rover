using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] float reloadDelay = 0.5f;
    int currentActiveScene;
    AudioSource finishSFX;

    void OnEnable() 
    {
        currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        finishSFX = GetComponent<AudioSource>();
    }

void OnTriggerEnter2D(Collider2D other) 
{
    if (other.GetComponentInParent<PlayerController>() == null) { return; }

    StartCoroutine(RestartLevel());
}

IEnumerator RestartLevel()
{
    finishEffect.Play();
    finishSFX.Play();

    yield return new WaitForSeconds(reloadDelay);

    SceneManager.LoadScene(currentActiveScene);
}

}
