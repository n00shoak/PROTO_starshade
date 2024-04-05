using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskCreator : MonoBehaviour
{
    [SerializeField] private SO_Task[] allTasks;

    private void Awake()
    {
        allTasks = Resources.LoadAll<SO_Task>("");
        //tidy tasks by ID inside the array
    }
    public CL_Task createTask(int ID)
    {
        CL_Task task = new CL_Task();

        task.SetData(allTasks[ID].inatePriority, allTasks[ID].type, allTasks[ID].steps);

        return task;
    }

    private void Start()
    {
        CL_Task task;
        task = createTask(0);
        task.steps[0].Invoke();
    }

    public bool printed(string OUI = "aaa")
    {
        Debug.Log("oui");
        return true;    
    }
}
