using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static bool postProcess;
    public static KeyCode leftArr;
    public static KeyCode upArr;
    public static KeyCode downArr;
    public static KeyCode rightArr;
    public static float volume;
    public Slider volumeSlider;
    public bool recording;
    public string recordType;
    public Toggle toggle;
    
    // Start is called before the first frame update
    void Start()
    {
        if(leftArr == KeyCode.None)
        {
            leftArr = KeyCode.LeftArrow;
            upArr = KeyCode.UpArrow;
            downArr = KeyCode.DownArrow;
            rightArr = KeyCode.RightArrow;
            postProcess = true;
            if (SceneManager.GetActiveScene().name.Contains("Settings"))
            {
                toggle.isOn = true;
                volumeSlider.value = 1f;
            }
            volume = 1f;
        }
        else
        {
            Debug.Log("Nope");
        }
        if (SceneManager.GetActiveScene().name.Contains("Settings"))
        {
            GameObject.Find("Left").GetComponentInChildren<TextMeshProUGUI>().text = leftArr.ToString();
            GameObject.Find("Up").GetComponentInChildren<TextMeshProUGUI>().text = upArr.ToString();
            GameObject.Find("Down").GetComponentInChildren<TextMeshProUGUI>().text = downArr.ToString();
            GameObject.Find("Right").GetComponentInChildren<TextMeshProUGUI>().text = rightArr.ToString();
            toggle.isOn = postProcess;
            volumeSlider.value = volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!postProcess)
        {
            Camera.main.GetComponent<PostProcessVolume>().isGlobal = false;
        }
        else
        {
            Camera.main.GetComponent<PostProcessVolume>().isGlobal = true;
        }
        if (volumeSlider != null)
        {
            volume = volumeSlider.value;
            postProcess = toggle.isOn;
        }
        if(recording == true)
        {
            if (recordType == "Left")
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        leftArr = kcode;
                        recording = false;
                        GameObject.Find(recordType).GetComponentInChildren<TextMeshProUGUI>().text = kcode.ToString();
                    }
                }
            }
            else if (recordType == "Up")
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        upArr = kcode;
                        recording = false;
                        GameObject.Find(recordType).GetComponentInChildren<TextMeshProUGUI>().text = kcode.ToString();
                    }
                }
            }
            else if (recordType == "Down")
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        downArr = kcode;
                        recording = false;
                        GameObject.Find(recordType).GetComponentInChildren<TextMeshProUGUI>().text = kcode.ToString();
                    }
                }
            }
            else if (recordType == "Right")
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        rightArr = kcode;
                        recording = false;
                        GameObject.Find(recordType).GetComponentInChildren<TextMeshProUGUI>().text = kcode.ToString();
                    }
                }
            }
        }
        
    }
    public void Left()
    {
        recording = true;
        recordType = "Left";
    }
    public void Up()
    {
        recording = true;
        recordType = "Up";
    }
    public void Down()
    {
        recording = true;
        recordType = "Down";
    }
    public void Right()
    {
        recording = true;
        recordType = "Right";
    }
}
