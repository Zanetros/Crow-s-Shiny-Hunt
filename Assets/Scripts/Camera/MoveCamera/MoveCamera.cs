using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float cameraSpeed;

    private void Update()
    {
        cameraSpeed = PlayerMovement.moveSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * cameraSpeed, Space.World);
    }
}
