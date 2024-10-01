using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float cameraSpeed;
    public static bool isDeadCamera;

    private void Awake()
    {
        isDeadCamera = false;
    }

    private void Update()
    {
        if (isDeadCamera) return;
        cameraSpeed = PlayerMovement.moveSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * cameraSpeed, Space.World);
    }
}
