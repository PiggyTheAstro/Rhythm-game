using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{
    public bool collided;
    Renderer render;
    Color renderColor;
    public string keyType;
    public GameObject colObject;
    public ManagerScript gameManager;
    public static float hitOnes;
    public static float missedOnes;
    public static float percentage;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        renderColor = render.material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<ManagerScript>();
        hitOnes = 0f;
        missedOnes = 0f;
        percentage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ended)
        {
            Debug.Log(hitOnes);
            Debug.Log(missedOnes);
            percentage = hitOnes / (hitOnes + missedOnes) * 100f;
            Debug.Log(percentage);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
                if(hit.transform.gameObject.name == "Red" || hit.transform.parent.parent.gameObject.name == "Red")
                {
                    LeftClick();
                }
            }
        }
        else if(keyType == "Right")
        {
            if (Input.GetKeyDown(SettingsManager.rightArr))
            {
                
            }
        }
        else if(keyType == "Up")
        {
            if (Input.GetKeyDown(SettingsManager.upArr))
            {
                
            }
        }
        else if(keyType == "Down")
        {
            if (Input.GetKeyDown(SettingsManager.downArr))
            {
                
            }
        }
    }
    void Colorback()
    {
        render.material.color = renderColor;
    }
    public void LeftClick()
    {
        render.material.color = Color.white;
        Invoke("Colorback", 0.1f);
        if (collided)
        {
            Destroy(colObject);
            collided = false;
            hitOnes += 1;
        }
        else
        {
            missedOnes += 1;
        }
    }
    public void UpClick()
    {
        render.material.color = Color.white;
        Invoke("Colorback", 0.1f);
        if (collided)
        {
            Destroy(colObject);
            collided = false;
            hitOnes += 1;
        }
        else
        {
            missedOnes += 1;
        }
    }
    public void DownClick()
    {
        render.material.color = Color.white;
        Invoke("Colorback", 0.1f);
        if (collided)
        {
            Destroy(colObject);
            collided = false;
            hitOnes += 1;
        }
        else
        {
            missedOnes += 1;
        }
    }
    public void RightClick()
    {
        render.material.color = Color.white;
        Invoke("Colorback", 0.1f);
        if (collided)
        {
            Destroy(colObject);
            collided = false;
            hitOnes += 1;
        }
        else
        {
            missedOnes += 1;
        }
    }
}
