using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetestdestruc : MonoBehaviour
{

    public object caca;

    // Start is called before the first frame update
    void Start()
    {
        caca = "ratio";
        Debug.Log(caca);
        caca = Vector3.up;
        Debug.Log(caca);
        caca = 10;
        Debug.Log(caca);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
