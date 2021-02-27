using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string dest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        SceneManager.LoadScene(dest, LoadSceneMode.Single);
    }
    public void Hover()
    {
        GetComponent<AudioSource>().Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
