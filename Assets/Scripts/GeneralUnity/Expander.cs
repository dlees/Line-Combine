using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour {

    public float timeFactor = 1.0f;
    public float minSizeRatio = 1.0f;
    public float maxSizeRatio = 2.0f;

    private float currentTime = 0.0f;
    private float originalLocalScale;

    void Update()
    {
        transform.localScale = new Vector3(PingPong(Time.time * timeFactor, minSizeRatio, maxSizeRatio),
            PingPong(Time.time * timeFactor, minSizeRatio, maxSizeRatio),
            PingPong(Time.time * timeFactor, minSizeRatio, maxSizeRatio));
    }

    float PingPong(float aValue, float aMin, float aMax)
    {
        return Mathf.PingPong(aValue, aMax - aMin) + aMin;
    }

}
