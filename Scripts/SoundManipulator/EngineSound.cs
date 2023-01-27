using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    AudioSource carEngine;
    private float speed = 0f;
    private float acceleration;

    private float minPitch = 0.02f;
    private float maxPitch = 1f;
    private void Start()
    {
        acceleration = GetComponent<PlayerController>().acceleration;
        carEngine = GetComponent<AudioSource>();
        carEngine.pitch = 0f;
    }

    private void Update()
    {
        speed = GetComponent<PlayerController>().carspeed * 1.6f;
        if (speed > maxPitch)
            speed = maxPitch;
        if (speed < minPitch)
            speed = minPitch;
        carEngine.pitch = speed;
    }
}
