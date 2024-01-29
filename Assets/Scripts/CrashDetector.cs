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

void OnEnable() 
{
    currentActiveScene = SceneManager.GetActiveScene().buildIndex;
    crashSFX = GetComponent<AudioSource>();
    playerController = GetComponentInParent<PlayerController>();
}

void OnCollisionEnter2D(Collision2D other) 
{
    StartCoroutine(RestartLevel());
}

    IEnumerator RestartLevel()
{
    playerController.DisableControls();
    crashEffect.Play();
    crashSFX.Play();

    yield return new WaitForSeconds(reloadDelay);

    SceneManager.LoadScene(currentActiveScene);
}

}
