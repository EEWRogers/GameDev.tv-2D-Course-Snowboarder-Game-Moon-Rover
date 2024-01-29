using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float reloadDelay = 1f;
    int currentActiveScene;
    AudioSource crashSFX;
    PlayerController playerController;
    bool isCrashing = false;

void OnEnable() 
{
    currentActiveScene = SceneManager.GetActiveScene().buildIndex;
    crashSFX = GetComponent<AudioSource>();
    playerController = GetComponentInParent<PlayerController>();
    isCrashing = false;
}

void OnCollisionEnter2D(Collision2D other) 
{
    if (!isCrashing)
    {
        StartCoroutine(RestartLevel());
    }
}

    IEnumerator RestartLevel()
{
    isCrashing = true;
    playerController.DisableControls();
    crashEffect.Play();
    crashSFX.Play();

    yield return new WaitForSeconds(reloadDelay);

    SceneManager.LoadScene(currentActiveScene);
}

}
