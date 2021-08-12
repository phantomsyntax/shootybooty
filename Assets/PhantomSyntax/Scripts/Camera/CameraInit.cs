using System;
using UnityEngine;

public class CameraInit : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private GameObject mainCameraObject;
                     private Camera mainCameraComponent;
    [SerializeField] private Vector3 mainCameraOffsetPosition = new Vector3(0.0f, 0.0f, -20.0f);
    [SerializeField] private Vector3 mainCameraOffsetRotation;
    [SerializeField] private Color32 sceneBackgroundColor = new Color32(0, 0, 0, 255);

    private void Start()
    {
        NullChecks();

        mainCameraComponent = mainCameraObject.GetComponent<Camera>();
        PositionCamera(mainCameraOffsetPosition, mainCameraOffsetRotation);
        SetProperties(sceneBackgroundColor);
    }

    private void NullChecks()
    {
        if (!mainCameraObject)
        {
            mainCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    private void PositionCamera(Vector3 position, Vector3 rotation)
    {
        mainCameraObject.transform.position = position;
        mainCameraObject.transform.eulerAngles = rotation;
    }

    private void SetProperties(Color32 color)
    {
        mainCameraComponent.clearFlags = CameraClearFlags.SolidColor;
        mainCameraComponent.backgroundColor = color;
    }
}
