using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SY_Actions : MonoBehaviour
{
    public UnityEvent<List<object>>[] allActions;

    public void Action_DebugName(List<object> Data)
    {
        Debug.Log("DEBUG ACTION : " + Data[0].ToString());
    }
}
