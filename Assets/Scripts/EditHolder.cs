using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EditHolder
{
    public List<float> positionsX;
    public List<float> positionsY;
    public List<float> positionsZ;
    public List<GameObject> arrows;
    public EditHolder()
    {
        if(positionsX == null)
        {
            positionsX = new List<float>();
            positionsY = new List<float>();
            positionsZ = new List<float>();
        }
        for (int i = 0; i < EditorScript.positions.Count; i++)
        {
            positionsX.Add(EditorScript.positions[i].x);
        }
        for (int i = 0; i < EditorScript.positions.Count; i++)
        {
            positionsY.Add(EditorScript.positions[i].y);
        }
        for (int i = 0; i < EditorScript.positions.Count; i++)
        {
            positionsZ.Add(EditorScript.positions[i].z);
        }
    }
}
