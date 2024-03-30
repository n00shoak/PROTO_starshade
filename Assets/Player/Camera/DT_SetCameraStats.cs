using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class DT_SetCameraStats : MonoBehaviour
{
    private MN_CameraManager MN_Cam;

    [SerializeField] private float Xdamping, Ydamping, Zdamping, Yawdamping;
    [SerializeField] private float Xoffset, Yoffset, Zoffset;
    [SerializeField] private List<List<float>> Presset = new List<List<float>>();


    private void Awake()
    {
        MN_Cam = GetComponent<MN_CameraManager>();
        MN_Cam.setStats(this);
    }

    private void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        CinemachineTransposer transposer = MN_Cam.cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_XDamping = Xdamping;
        transposer.m_YawDamping = Ydamping;
        transposer.m_ZDamping = Zdamping;
        transposer.m_YawDamping = Yawdamping;

        transposer.m_FollowOffset = new Vector3 (Xoffset, Yoffset, Zoffset);
    }

}
