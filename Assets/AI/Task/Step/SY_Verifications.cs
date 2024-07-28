using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SY_Verifications : MonoBehaviour
{
    public UnityEvent<List<object>>[] allVerifications;

    public void Action_DebugName(List<object> Data)
    {
        Debug.Log("DEBUG VERIFICATIONS : " + Data[0].ToString());
    }
}
