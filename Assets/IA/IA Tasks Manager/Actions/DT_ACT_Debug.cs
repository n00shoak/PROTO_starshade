using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT_ACT_Debug : MonoBehaviour
{
    public static DT_ACT_Debug instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); return; }
    }


    public bool SimpleDebug(string toPrint = "no entry")
    {
        Debug.Log(toPrint);
        return true;
    }
}
