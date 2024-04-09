using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_AI_TaskExecuter : MonoBehaviour
{
    private DT_TaskStorage availableTasks;
    private CL_Task taskInProgress;

    private void Awake()
    {
        availableTasks  =GetComponentInParent<DT_TaskStorage>(); 
    }

    private void Start()
    {
        getTask();
    }

    private void getTask()
    {
        Debug.Log("test A " + availableTasks);
        taskInProgress = availableTasks.availableTasks[0][0];
    }

    private void Update()
    {
        if(taskInProgress != null)
        {
            taskInProgress.steps[0].Invoke("");
        }
    
    }
}
