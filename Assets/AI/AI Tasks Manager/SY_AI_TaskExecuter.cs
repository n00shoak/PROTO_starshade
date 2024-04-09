using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_AI_TaskExecuter : MonoBehaviour
{
    private DT_TaskStorage availableTasks;
    private CL_Task taskInProgress;
    public int CurrentStep;   

    private bool doing;

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
        if(taskInProgress != null && !doing)
        {
            if(CurrentStep > taskInProgress.steps.Length-1) { doing = true; return; }
            taskInProgress.steps[CurrentStep].Invoke(this,"executing step number " + CurrentStep);
        }
    
    }
}
