using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DT_Actions : MonoBehaviour
{
    public static DT_Actions instance;

    [SerializeField] private DT_ACT_Debug debug;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); return; }
    }

    public UnityAction<object> getStep(int ID)
    {
        if(ID <= debug.debugSteps.Length)
        {
            return debug.debugSteps[ID];
        }

        return null;
    }
}
