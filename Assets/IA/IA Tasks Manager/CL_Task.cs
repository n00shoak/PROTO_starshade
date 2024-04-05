using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Task : MonoBehaviour
{
    // General Data
    public DT_TaskTypes.tasksType type;
    public float inatePriority; // 0 = low priority   10 = high priority

    // Speceific data
    public float whichStep;
    public object[] Objectives;
    public delegate bool[] Method();

}
