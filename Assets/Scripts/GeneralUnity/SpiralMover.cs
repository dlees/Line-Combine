using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMover : MonoBehaviour {

    public float revolutionSpeed = 1.0f;
    public float startRadius = 1.0f;
    public float spiralIncrease = 1.0f;

    void Update()
    {
        transform.position = new Vector2(transform.position.x + Mathf.Sin(Time.time * revolutionSpeed) * startRadius,
            transform.position.y + Mathf.Cos(Time.time * revolutionSpeed) * startRadius);

        startRadius += Time.deltaTime * spiralIncrease;
    }
    
}
