using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public bool percent;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (percent)
        {
            text.text = ManagerScript.gameManager.percentages[index + 1].ToString();
        }
        else
        {
            Debug.Log(ManagerScript.gameManager.grades[index+1]);
            text.text = ManagerScript.gameManager.grades[index + 1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
