using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

namespace CodeMonkey.CameraSystem {

    public class CameraSystem : MonoBehaviour {

        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private bool useEdgeScrolling = false;
        [SerializeField] private bool useDragPan = false;
        [SerializeField] private bool usePulseRotation = true;
        [SerializeField] private float fieldOfViewMax = 50;
        [SerializeField] private float fieldOfViewMin = 10;
        [SerializeField] private float followOffsetMinY = 10f;
        [SerializeField] private float followOffsetMaxY = 50f;
        [SerializeField] private float generalSpeed = 1f , LshiftMultiplier = 2f;
        [SerializeField] [Range(0f,5f)]private float keySpeedMultiplier = 0.5f, edgeScrollSpeedMultiplier, continuousRotationSpeedMultiplier, pulseRotationSpeedMultiplier, zoomSpeedMultiplier;


        private UnityEvent CameraBehavior;
        private bool dragPanMoveActive;
        private Vector2 lastMousePosition;
        private float targetFieldOfView = 50;
        private Vector3 followOffset;
        private Vector3 pulseRotationTarget;


        private void Awake() 
        {
            followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        }


        private void Start()
        {
            UpdateCameraBehavior();
        }


        private void Update() 
        {
            CameraBehavior.Invoke();
        }


        /// <summary>
        /// set all Behavior usable by cam
        /// </summary>
        public void UpdateCameraBehavior()
        {
            CameraBehavior = new UnityEvent();
            CameraBehavior.AddListener(HandleCameraMovement);
            CameraBehavior.AddListener(HandleCameraZoom_LowerY);


            if (useEdgeScrolling)
            {
                CameraBehavior.AddListener(HandleCameraMovementEdgeScrolling);
            }

            if (useDragPan)
            {
                CameraBehavior.AddListener(HandleCameraMovementDragPan);
            }

            //rotation behavior
            if (usePulseRotation)
            {
                CameraBehavior.AddListener(HandlePulseCameraRotation);
            }
            else
            {
                CameraBehavior.AddListener(HandleContinuousCameraRotation);
            }
        }


        private void HandleCameraMovement() {
            Vector3 inputDir = new Vector3(0, 0, 0);
            float mvmSpeed = generalSpeed * keySpeedMultiplier;
            if (Input.GetKey(KeyCode.LeftShift)) { mvmSpeed *= LshiftMultiplier; }

            if (Input.GetKey(KeyCode.W)) inputDir.z = +mvmSpeed;
            if (Input.GetKey(KeyCode.S)) inputDir.z = -mvmSpeed;
            if (Input.GetKey(KeyCode.A)) inputDir.x = -mvmSpeed;
            if (Input.GetKey(KeyCode.D)) inputDir.x = +mvmSpeed;

            Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

            float moveSpeed = 50f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }


        private void HandleCameraMovementEdgeScrolling() {
            Vector3 inputDir = new Vector3(0, 0, 0);

            int edgeScrollSize = 20;
            float edgeScrollSpeed = generalSpeed * edgeScrollSpeedMultiplier;

            if (Input.mousePosition.x < edgeScrollSize) {
                inputDir.x = -edgeScrollSpeed;
            }
            if (Input.mousePosition.y < edgeScrollSize) {
                inputDir.z = -edgeScrollSpeed;
            }
            if (Input.mousePosition.x > Screen.width - edgeScrollSize) {
                inputDir.x = +edgeScrollSpeed;
            }
            if (Input.mousePosition.y > Screen.height - edgeScrollSize) {
                inputDir.z = +edgeScrollSpeed;
            }

            Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

            float moveSpeed = 50f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }


        private void HandleCameraMovementDragPan() {
            Vector3 inputDir = new Vector3(0, 0, 0);

            if (Input.GetMouseButtonDown(1)) {
                dragPanMoveActive = true;
                lastMousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(1)) {
                dragPanMoveActive = false;
            }

            if (dragPanMoveActive) {
                Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

                float dragPanSpeed = 1f;
                inputDir.x = mouseMovementDelta.x * dragPanSpeed;
                inputDir.z = mouseMovementDelta.y * dragPanSpeed;

                lastMousePosition = Input.mousePosition;
            }

            Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

            float moveSpeed = 50f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }


        private void HandleContinuousCameraRotation() {
            float rotateDir = 0f;
            float rotateSpeed = (generalSpeed * continuousRotationSpeedMultiplier)*100;
            if (Input.GetKey(KeyCode.Q)) rotateDir = +1f;
            if (Input.GetKey(KeyCode.E)) rotateDir = -1f;

            transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
        }


        private void HandlePulseCameraRotation()
        {
            float turnForce = 45f;
            if (Input.GetKey(KeyCode.LeftShift)) { turnForce *= 2; }
            if (Input.GetKeyDown(KeyCode.Q)) pulseRotationTarget += new Vector3(0, turnForce, 0);
            if (Input.GetKeyDown(KeyCode.E)) pulseRotationTarget += new Vector3(0, -turnForce, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(pulseRotationTarget), (generalSpeed * pulseRotationSpeedMultiplier) * Time.deltaTime);
        }


        private void HandleCameraZoom_LowerY() {
            float zoomAmount = 3f;
            if (Input.mouseScrollDelta.y > 0) {
                followOffset.y -= zoomAmount;
            }
            if (Input.mouseScrollDelta.y < 0) {
                followOffset.y += zoomAmount;
            }

            followOffset.y = Mathf.Clamp(followOffset.y, followOffsetMinY, followOffsetMaxY);

            float zoomSpeed = 10f;
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
                Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
        }
    }
}