using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallaxEffect;
    [SerializeField] GameObject playerCamera;
    float length;
    float startPosition;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        ParallaxEffect();
    }

    void ParallaxEffect()
    {
        float temp = playerCamera.transform.position.x * (1 - parallaxEffect);
        float distance = playerCamera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
        {
            startPosition += length;
        }

        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
