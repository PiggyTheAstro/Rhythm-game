using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public float bpm;
    float beat;
    float bar;
    Vector3 velocity;
    Vector3 normalScale;
    Vector3 targetScale;
    // Start is called before the first frame update
    void Start()
    {
        beat = 60f / bpm;
        bar = beat * 4f;
        velocity = Vector3.zero;
        normalScale = new Vector3(100f, 1f, 100f);
        targetScale = normalScale * 1.3f;
        Invoke("Transform", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, beat);
    }
    void Transform()
    {
    
    }
}
