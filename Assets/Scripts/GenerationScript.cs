using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationScript : MonoBehaviour
{
    public GameObject scroller;
    public GameObject arrow;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; EditorScript.positions.Count > i; i++)
        {
            if (EditorScript.positions[i].x == -4f)
            {
                Instantiate(arrow, EditorScript.positions[i], Quaternion.Euler(90f, 0f, 90f), scroller.transform);
            }
            else if(EditorScript.positions[i].x == -1f)
            {
                Instantiate(arrow, EditorScript.positions[i], Quaternion.Euler(90f, 0f, 0f), scroller.transform);
            }
            else if (EditorScript.positions[i].x == 2f)
            {
                Instantiate(arrow, EditorScript.positions[i], Quaternion.Euler(-90f, 0f, 0f), scroller.transform);
            }
            else if (EditorScript.positions[i].x == 5f)
            {
                Instantiate(arrow, EditorScript.positions[i], Quaternion.Euler(-90f, 0f, -90f), scroller.transform);
            }
        }
        scroller.GetComponent<ScrollScript>().bpm = EditorScript.bpm;
        GameObject.Find("GameManager").GetComponent<AudioSource>().clip = EditorScript.ac;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
