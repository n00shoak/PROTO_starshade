using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPO_testObject : MonoBehaviour
{
    [SerializeField] private SY_TaskCreator taskCreator;
    [SerializeField] private DT_TaskStorage taskStorage;


    private void Start()
    {
        createTask();
        playTask();
    }


    private void createTask()
    {
        taskCreator.createTask("test task", transform.position, 0, 0);
        Debug.Log(taskStorage.tasks[taskStorage.tasks.Count - 1].tasknName);

        List<List<object>> stepData = new List<List<object>>
        {
            new List<object>()
            {
                gameObject.activeSelf,
            },
            new List<object>(){
                "Verified"
            },
            new List<object>()
            {
                "played"
            }
        };
        taskStorage.tasks[taskStorage.tasks.Count - 1].AddStep(0, stepData);
    }

    private void playTask()
    {
        taskStorage.tasks[0].steps[0].action.Invoke(new List<object>() { "caca" });
        taskStorage.tasks[0].steps[0].condition.Invoke(new List<object>() { "caca" });
        taskStorage.tasks[0].steps[0].verification.Invoke(new List<object>() { "caca" });
    }
}
