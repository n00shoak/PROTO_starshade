using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT_Actions : MonoBehaviour
{
    public static DT_Actions instance;

    [SerializeField] private DT_ACT_Debug debug;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); return; }
    }
}
