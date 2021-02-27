using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
public class ManagerScript : MonoBehaviour
{
    public bool start;
    public AudioSource music;
    public ScrollScript scroll;
    public int totalArrows;
    public int hitArrows;
    public bool ended;
    public TextMeshProUGUI hit;
    public TextMeshProUGUI miss;
    public TextMeshProUGUI percent;
    public TextMeshProUGUI grade;
    public List<int> percentages;
    public List<string> grades;
    public static bool notsaved;
    public static ManagerScript gameManager;
    bool savedOnce;
    void Update()
    {
        
        music.volume = SettingsManager.volume;
        if (!start)
        {
            if (!SceneManager.GetActiveScene().name.Contains("1"))
            {
                if (Input.anyKeyDown)
                {
                    start = true;
                    scroll.started = true;
                    music.Play();
                }
            }
        }
        else
        {
            UpdateCounts();
            if (!music.isPlaying)
            {
                ended = true;
            }
        }
        if (ended)
        {
            GameObject.Find("Canvas").GetComponent<Animator>().Play("EndAnim");
            percent.text = (int) ButtonScript.percentage + "%";
            if(ButtonScript.percentage == 100f)
            {
                grade.text = "S";
            }
            else if(ButtonScript.percentage > 95f)
            {
                grade.text = "A+";
            }
            else if(ButtonScript.percentage > 80f)
            {
                grade.text = "A";
            }
            else if(ButtonScript.percentage > 70f)
            {
                grade.text = "B";
            }
            else if(ButtonScript.percentage > 60f)
            {
                grade.text = "C";
            }
            else if(ButtonScript.percentage > 50f)
            {
                grade.text = "D";
            }
            else
            {
                grade.text = "F";
            }
            if ((int)ButtonScript.percentage > percentages[SceneManager.GetActiveScene().buildIndex])
            {
                percentages[SceneManager.GetActiveScene().buildIndex] = (int)ButtonScript.percentage;
                Debug.Log(percentages[SceneManager.GetActiveScene().buildIndex]);
                grades[SceneManager.GetActiveScene().buildIndex] = grade.text;
                if (!savedOnce)
                {
                    Save();
                    savedOnce = true;
                }
            }
            if (Input.anyKeyDown)
            {
                savedOnce = false;
                SceneManager.LoadScene("StartMenu1");
            }
        }
    }
    void UpdateCounts()
    {
        if (!SceneManager.GetActiveScene().name.Contains("1"))
        {
            hit.text = ButtonScript.hitOnes.ToString();
            miss.text = ButtonScript.missedOnes.ToString();
        }
    }
    public void Save()
    {
        SaveScript.Save(this);
    }
    public void Load()
    {
        HolderScript holder = SaveScript.Load();
        if (!notsaved)
        {
            percentages = holder.percentages;
            grades = holder.grades;
        }
        else
        {
            Save();
            notsaved = false;
        }
    }
    void Start()
    {
        if(ManagerScript.gameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManager = this;
        }
        Load();
        if (percentages != null)
        {
            if (percentages.Count < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    percentages.Add(0);
                }
            }
        }
        else
        {
            percentages = new List<int>();
            if (percentages.Count < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    percentages.Add(0);
                }
            }
        }
        if (grades != null)
        {
            if (grades.Count < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    grades.Add("F");
                }
            }
        }
        else
        {
            grades = new List<string>();
            if (grades.Count < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    grades.Add("F");
                }
            }
        }
    }

}