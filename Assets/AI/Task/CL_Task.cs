using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CL_Task : MonoBehaviour
{
    public string tasknName;
    public Vector2 position;
    public int priority;
    public int type;
    public List<CL_Step> steps = new List<CL_Step>();

    public void AddStep(int stepActions,List<List<object>> Data)
    {
        CL_Step step = new CL_Step();   
        GameObject events = GameObject.Find("TaskManagement");

        step.condition = events.GetComponent<SY_Conditions>().allConditions[stepActions];
        step.verification = events.GetComponent<SY_Verifications>().allVerifications[stepActions];
        step.action = events.GetComponent<SY_Actions>().allActions[stepActions];

        step.conditionData = Data[0];
        step.verificationData = Data[1];
        step.actionData = Data[2];

        steps.Add(step);
    }
}