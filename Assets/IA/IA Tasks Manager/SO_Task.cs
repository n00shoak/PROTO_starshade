using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Ia_task", menuName = "Task", order = 0)]
public class SO_Task : ScriptableObject
{
    public int ID;
    public DT_TaskTypes.tasksType type;
    [Range(0, 10)] public float inatePriority; // 0 = low priority   10 = high priority
    public List<Func<bool>> steps = new List<Func<bool>>();

}

