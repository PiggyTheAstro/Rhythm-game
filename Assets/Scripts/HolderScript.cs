using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HolderScript
{
    public List<int> percentages;
    public List<string> grades;
    public HolderScript(ManagerScript manager)
    {
        percentages = manager.percentages;
        grades = manager.grades;
    }
}
