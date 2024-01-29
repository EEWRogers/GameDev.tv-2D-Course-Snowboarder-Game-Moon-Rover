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
    bool isFinishing = false;

    void OnEnable() 
    {
        currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        finishSFX = GetComponent<AudioSource>();
        isFinishing = false;
    }

void OnTriggerEnter2D(Collider2D other) 
{
    if (other.GetComponentInParent<PlayerController>() == null) { return; }

    if (!isFinishing)
    {
        StartCoroutine(RestartLevel());
    }
}

IEnumerator RestartLevel()
{
    isFinishing = true;
    finishEffect.Play();
    finishSFX.Play();

    yield return new WaitForSeconds(reloadDelay);

    SceneManager.LoadScene(currentActiveScene);
}

}
