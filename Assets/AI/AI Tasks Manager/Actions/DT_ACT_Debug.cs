using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DT_ACT_Debug : CL_Actions
{
    public static DT_ACT_Debug instance;
    public UnityAction<object>[] debugSteps;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); return; }

        debugSteps = new UnityAction<object>[5];
        debugSteps[0] += SimpleDebug;
    }


    public void SimpleDebug(object text)
    {
        Debug.Log(text);

    }
}
