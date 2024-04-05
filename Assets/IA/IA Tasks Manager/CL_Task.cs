using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Task : MonoBehaviour
{
    // General Data
    private DT_TaskTypes.tasksType type;
    private float inatePriority; // 0 = low priority   10 = high priority

    // Speceific data
    public float whichStep;
    public object[] Objectives;
    public delegate bool[] Method();
    public List<Func<bool>> steps = new List<Func<bool>>();

    public void SetData(float _inatePriority, DT_TaskTypes.tasksType _type, List<Func<bool>> _steps)
    {
        type = _type;
        inatePriority = _inatePriority;
        this.steps = _steps;
    }
}
