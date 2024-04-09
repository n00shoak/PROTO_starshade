using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT_TaskStorage : MonoBehaviour
{
    public List<CL_Task>[] availableTasks = new List<CL_Task>[2];

    public static DT_TaskStorage taskStorage;

    private void Awake()
    {
        for(int i = 0; i < availableTasks.Length; i++)
        {
            availableTasks[i] = new List<CL_Task> ();
        }

        if(taskStorage == null)
        {
            //taskStorage = this;
        }
        else
        {
            Debug.LogError("Error : Multiple DT_taskStorage Instance Detected");
        }
    }

    private void Start()
    {
    }

    /// <summary>
    /// add a task to the task Storage
    /// </summary>
    /// <param name="taskToAdd"></param>
    public void AddToList(CL_Task taskToAdd)
    {
        availableTasks[Mathf.RoundToInt(taskToAdd.inatePriority)].Add(taskToAdd); 
        TidyTasks(Mathf.RoundToInt(taskToAdd.inatePriority));
    }

    /// <summary>
    /// tidy specified class storage by tasks priority
    /// </summary>
    /// <param name="wichList"></param>
    public void TidyTasks(int wichList)
    {
        List<float> allPrio = new List<float>();

        //get all prio in a selected list of Task
        for(int i = 0; i<availableTasks[wichList].Count - 1; i++)
        {
            allPrio[i] = availableTasks[wichList][i].inatePriority;
        }

        //tidy tasks in the list by theyr's priority
        for (int i = 0; i < availableTasks[wichList].Count; i++)
        {
            if( i > 0 && allPrio[i] > allPrio[i - 1])
            {
                float temp = allPrio[i];
                allPrio[i] = allPrio[i - 1];
                allPrio[i - 1] = temp;

                CL_Task _temp = availableTasks[wichList][i];
                availableTasks[wichList][i] = availableTasks[wichList][i - 1];
                availableTasks[wichList][i - 1] = _temp;

                //restart 
                i = 0;
            }
        }

        DebugAvailableTask();
    }

    public void DebugAvailableTask()
    {
        for(int i = 0; i < availableTasks.Length;)
        {
            for (int j = 0; i < availableTasks[i].Count; i++)
            {
                Debug.Log(availableTasks[i][j]);
            }
        }
    }
}
