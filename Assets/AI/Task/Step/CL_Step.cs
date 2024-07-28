using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Step : MonoBehaviour
{
    public UnityEvent<List<object>> condition, verification, action;
    public List<object> conditionData, verificationData, actionData;

    public void setData(List<List<object>> data)
    {
        conditionData = data[0];
        verificationData = data[1];
        actionData = data[2];
    }
}
