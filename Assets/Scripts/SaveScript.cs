using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveScript
{
    public static void Save(ManagerScript manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/warning.clicking_will_destroy_your_country";
        FileStream stream = new FileStream(path, FileMode.Create);
        HolderScript holder = new HolderScript(manager);
        formatter.Serialize(stream, holder);
        stream.Close();
    }
    public static HolderScript Load()
    {
        string path = Application.persistentDataPath + "/warning.clicking_will_destroy_your_country";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HolderScript holder = formatter.Deserialize(stream) as HolderScript;
            stream.Close();
            return holder;

        }
        else
        {
            ManagerScript.notsaved = true;
            return null;
        }
    }
    public static void SaveLevel(EditorScript editor)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/warning.clicking_will_destroy_your_city";
        FileStream stream = new FileStream(path, FileMode.Create);
        EditHolder holder = new EditHolder();
        formatter.Serialize(stream, holder);
        stream.Close();
    }
    public static EditHolder Level()
    {
        string path = Application.persistentDataPath + "/warning.clicking_will_destroy_your_city";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            EditHolder holder = formatter.Deserialize(stream) as EditHolder;
            stream.Close();
            return holder;

        }
        else
        {
            EditorScript.notSaved = true;
            return null;
        }
    }
}
