using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float bpm;
    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        bpm = bpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {

        if (started)
        {
            transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.position.z);
        }
    }
}
