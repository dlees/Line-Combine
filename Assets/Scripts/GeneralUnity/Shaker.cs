using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Shakes the game object around its base position that it started with. 
 * 
 * Does not work for moving objects (The position to shake around is only set on Start)
 * 
 * */
public class Shaker : MonoBehaviour {

    public float speed = 1.0f;
    public float amount = 1.0f;

    private Vector2 basePosition;

    void Start()
    {
        basePosition = transform.position;
    }

    void OnEnable()
    {
        basePosition = transform.position;
    }

    void Update()
    {
        transform.position = new Vector2(basePosition.x + Mathf.Sin(Time.time * speed) * amount,
            basePosition.y + Mathf.Cos(Time.time * speed) * amount);
    }
    
    void OnDisable()
    {
        transform.position = basePosition;
    }
}
