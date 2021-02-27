using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
public class EditorScript : MonoBehaviour
{
    Vector3 ypos2;
    public TextMeshProUGUI field;
    public Slider secondField;
    public TextMeshProUGUI bpmShower;
    public AudioSource audioSource;
    public static AudioClip ac;
    int scrollState;
    public List<GameObject> arrows;
    public GameObject scroller;
    public static float bpm;
    public static List<Vector3> positions;
    Vector3 spawnPoint;
    public static List<GameObject> placed;
    public static bool notSaved;
    // Start is called before the first frame update
    void Update()
    {
        bpm = secondField.value / 60f;
        bpmShower.text = (bpm * 60f).ToString();
        scroller.transform.position -= new Vector3(0f, 0f, (bpm * Time.deltaTime) * scrollState);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine("TestGetAudio", field.text);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            var dist = transform.position.y - Camera.main.transform.position.y;
            ypos2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -dist));
            Debug.Log(ypos2);
            if (ypos2.x > -6f && ypos2.x < -2.5f)
            {
                Debug.Log("Left");
                spawnPoint = new Vector3(-4f, -0.1f, ypos2.z);
                placed.Add(Instantiate(arrows[0], spawnPoint, Quaternion.Euler(90f, 0f, 90f), scroller.transform));
                spawnPoint.z -= scroller.transform.position.z;
                positions.Add(spawnPoint);
            }
            else if (ypos2.x < 0.5f && ypos2.x > -2.5f)
            {
                Debug.Log("Up");
                spawnPoint = new Vector3(-1f, -0.1f, ypos2.z);
                placed.Add(Instantiate(arrows[1], spawnPoint, Quaternion.Euler(90f, 0f, 0f), scroller.transform));
                spawnPoint.z -= scroller.transform.position.z;
                positions.Add(spawnPoint);
            }
            else if (ypos2.x < 3.5f && ypos2.x > 0.5f)
            {
                spawnPoint = new Vector3(2f, -0.4f, ypos2.z);
                Debug.Log("Down");
                placed.Add(Instantiate(arrows[2], spawnPoint, Quaternion.Euler(-90f, 0f, 0f), scroller.transform));
                spawnPoint.z -= scroller.transform.position.z;
                positions.Add(spawnPoint);
            }
            else if (ypos2.x < 7f && ypos2.x > 3.5f)
            {
                Debug.Log("Right");
                spawnPoint = new Vector3(5f, -0.4f, ypos2.z);
                placed.Add(Instantiate(arrows[3], spawnPoint, Quaternion.Euler(-90f, 0f, -90f), scroller.transform));
                spawnPoint.z -= scroller.transform.position.z;
                positions.Add(spawnPoint);
            }
            SaveLevel();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            var dist = transform.position.y - Camera.main.transform.position.y;
            ypos2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -dist));
            RaycastHit hit;
            Debug.DrawRay(ypos2, Vector3.down, Color.green, 100f, false);
            if (Physics.Raycast(ypos2, Vector3.down, out hit))
            {
                for (int i = 0; i < placed.Count; i++)
                {
                    if (placed[i] == hit.transform.gameObject)
                    {
                        placed.RemoveAt(i);
                        positions.RemoveAt(i);
                        Debug.Log("Removed");
                        Destroy(hit.transform.gameObject);
                    }
                }
                
            }
        }
    }
    IEnumerator TestGetAudio(string path)
    {
        string path2 = path.Trim();
        string path3 = path2.Remove(path2.Length - 1);
        if (path3.Contains("\""))
        {
            path3 = path3.Replace("\"", "");
        }
        using (UnityWebRequest testRequest = UnityWebRequestMultimedia.GetAudioClip($"file://{path3}", AudioType.WAV))
        {

            yield return testRequest.SendWebRequest();
            if (testRequest.isNetworkError || testRequest.isHttpError)
            {
                Debug.Log($"file:///{path}");
                Debug.Log(testRequest.result);
                Debug.Log(testRequest.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(testRequest);
                ac = myClip;
                audioSource.clip = ac;
            }
        }
    }
    public void Play()
    {
        audioSource.pitch = 1f;
        audioSource.Play();
        scrollState = 1;
    }
    public void Pause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            scrollState = 0;
        }
        else
        {
            audioSource.UnPause();
            if (audioSource.pitch == 1f)
            {
                scrollState = 1;
            }
            else
            {
                scrollState = -1;
            }
        }
    }
    public void Reverse()
    {
        if (audioSource.pitch == 1f)
        {
            audioSource.pitch = -2f;
            scrollState = -2;
        }
        else
        {
            audioSource.pitch = 1f;
            scrollState = 1;
        }
    }
    void Start()
    {
        positions = new List<Vector3>();
        placed = new List<GameObject>();
        LoadLevel();

    }
    void LoadLevel()
    {
        EditHolder holder = SaveScript.Level();
        if (!notSaved)
        {
            
        }
        else
        {
            SaveLevel();
            notSaved = false;
        }
        for (int i = 0; i < holder.positionsX.Count; i++)
        {
            positions.Add(new Vector3(holder.positionsX[i], holder.positionsY[i], holder.positionsZ[i]));
        }
        for (int i = 0; positions.Count > i; i++)
        {
            if (positions[i].x == -4f)
            {
                placed.Add(Instantiate(arrows[0], positions[i], Quaternion.Euler(90f, 0f, 90f), scroller.transform));
            }
            else if (positions[i].x == -1f)
            {
                placed.Add(Instantiate(arrows[0], positions[i], Quaternion.Euler(90f, 0f, 0f), scroller.transform));
            }
            else if (positions[i].x == 2f)
            {
                placed.Add(Instantiate(arrows[0], positions[i], Quaternion.Euler(-90f, 0f, 0f), scroller.transform));
            }
            else if (positions[i].x == 5f)
            {
                placed.Add(Instantiate(arrows[0], positions[i], Quaternion.Euler(-90f, 0f, -90f), scroller.transform));
            }
            SaveLevel();
        }

        Debug.Log(positions); 
    }
    void SaveLevel()
    {
        SaveScript.SaveLevel(this);
    }
    public void ChangeLevel()
    {
        if (ac != null)
        {
            SceneManager.LoadScene("Procgenned");
        }
    }
}
