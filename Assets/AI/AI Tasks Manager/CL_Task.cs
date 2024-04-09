using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Task  
{
    // General Data
    public DT_TaskTypes.tasksType type;
    public float inatePriority; // 0 = low priority   10 = high priority

    // Speceific data
    public float whichStep;
    public object[] objectives;
    public delegate bool[] Method();
    public UnityAction<object>[] steps;

    public void SetData(float _inatePriority, DT_TaskTypes.tasksType _type, UnityAction<object>[] _steps)
    {
        type = _type;
        inatePriority = _inatePriority;
        steps = _steps;
    }
}
