using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_AI_TaskExecuter : MonoBehaviour
{
    private DT_TaskStorage availableTasks;

    private void Awake()
    {
        availableTasks =GetComponentInParent<DT_TaskStorage>(); 
    }

    private void Start()
    {
        
    }

    private void getTask()
    {
        
    }
}
