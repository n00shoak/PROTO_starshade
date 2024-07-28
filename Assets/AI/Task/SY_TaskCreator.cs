using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_TaskCreator : MonoBehaviour
{
    [SerializeField] private DT_TaskStorage taskStorage;

    public void createTask(string _name,Vector2 position , int priority,int type)
    {
        CL_Task task = new CL_Task();
        task.tasknName = _name;
        task.position = position;
        task.priority = priority;
        task.type = type;

        taskStorage.tasks.Add(task);
    }
}
