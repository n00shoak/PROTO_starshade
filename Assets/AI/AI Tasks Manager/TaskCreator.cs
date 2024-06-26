using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskCreator : MonoBehaviour
{
    [SerializeField] private DT_TaskStorage storage;
    [SerializeField] private SO_Task[] allTasks;
    [SerializeField] private DT_Actions allActions;

    private void Awake()
    {
        allTasks = Resources.LoadAll<SO_Task>("");
        //tidy tasks by ID inside the array
    }

    // TEMPO
    private void Start()
    {
        createTask(0);
    }

    /// <summary>
    /// create task of specifed presset
    /// </summary>
    /// <param name="wichTask"></param>
    /// <returns></returns>
    public void createTask(int wichTask = 0)
    {
        CL_Task task = new CL_Task();

        // convert SO ID to step List
        UnityAction<SY_AI_TaskExecuter, object>[] steps = setSteps(allTasks[wichTask]);

        // set task of the data according to the selected Task
        task.SetData(allTasks[wichTask].inatePriority, allTasks[wichTask].type, steps);

        storage.AddToList(task);
    }


    /// <summary>
    /// convert all Int ID in the scriptable object Task 
    /// in to a list of step/method/action
    /// used to assigned them to a Task object
    /// </summary>
    /// <param name="taskData"></param>
    /// <returns></returns>
    public UnityAction<SY_AI_TaskExecuter, object>[] setSteps(SO_Task taskData)
    {
        List<UnityAction<SY_AI_TaskExecuter, object>> allNeededMethod = new List<UnityAction<SY_AI_TaskExecuter, object>> { };

        for(int i = 0; i < taskData.whichSteps.Length;i++)
        {
            allNeededMethod.Add(allActions.getStep(taskData.whichSteps[i]));
        }
        return allNeededMethod.ToArray();
    }

    
}
