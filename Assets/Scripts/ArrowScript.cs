using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (!SceneManager.GetActiveScene().name.Contains("1"))
        {
            col.GetComponent<ButtonScript>().collided = true;
            col.GetComponent<ButtonScript>().colObject = gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        col.GetComponent<ButtonScript>().collided = false;
        ButtonScript.missedOnes += 1;
    }
}
