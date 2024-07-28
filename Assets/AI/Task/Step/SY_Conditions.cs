using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SY_Conditions : MonoBehaviour
{
    public UnityEvent<List<object>>[] allConditions;
    public void Condition_isObjectActiated(List<object> Data)
    {
        Debug.LogFormat("DEBUG CONDITION" + Data[0].ToString());
    }
}