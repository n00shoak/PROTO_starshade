using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class DT_CameraStats : MonoBehaviour
{
    private MN_CameraManager MN_Cam;

    [SerializeField] private float Xdamping, Ydamping, Zdamping, Yawdamping;
    [SerializeField] private float Xoffset, Yoffset, Zoffset;

    private float followOffsetMinY = 10f;
    private float followOffsetMaxY = 50f;
    private float generalSpeed = 1f, LshiftMultiplier = 2f;
    private float keySpeedMultiplier = 0.5f;
    private float edgeScrollSpeedMultiplier = 1f;
    private float continuousRotationSpeedMultiplier = 1f;
    private float pulseRotationSpeedMultiplier = 5f;
    private float zoomSpeedMultiplier =1f;

    [SerializeField] List<List<float>> Presset = new List<List<float>>();


    private void Awake()
    {
        MN_Cam = GetComponent<MN_CameraManager>();
        MN_Cam.setStats(this);

        //add all current stats has default camera State
        Presset.Add(new List<float>
        {
            followOffsetMinY,
            followOffsetMaxY,
            generalSpeed,
            LshiftMultiplier,
            keySpeedMultiplier,
            edgeScrollSpeedMultiplier,
            continuousRotationSpeedMultiplier,
            pulseRotationSpeedMultiplier,
            zoomSpeedMultiplier
        });

    }

    public List<float> getPresset(int index = 0)
    {
        return Presset[index];
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
