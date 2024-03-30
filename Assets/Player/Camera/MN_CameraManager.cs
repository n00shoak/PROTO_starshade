using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MN_CameraManager : MN_manager
{
    [SerializeField] public CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private DT_SetCameraStats stats;
    [SerializeField] private List<SY_CameraSystem> camMvm;



    public void setStats<T>(T newStats) where T : DT_SetCameraStats
    {
        stats = newStats;
    }

    public void CameraControls<T>(T CmSystem) where T : SY_CameraSystem
    {
        camMvm.Add(CmSystem);
    }



    private void Awake()
    {
        
    }

    private void Start()
    {
    }
    

}
