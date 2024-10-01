using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrole : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotationSpeed = 2f;

    [SerializeField] float distance = 5;

    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    [SerializeField] Vector2 framingOffset;

    [SerializeField] bool invertX;
     [SerializeField] bool invertY;

     
     float rotationX;
     float rotationY;

     float invertXval;
     float invertYval;

     private void Start()
     {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
     }

    private void Update()
    {
        invertXval = (invertX)? -1 : 1;
        invertYval = (invertY)? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYval * rotationSpeed;
        rotationX = Math.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        rotationY += Input.GetAxis("Mouse X") * invertXval * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX,rotationY,0);

        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0,0,distance);
        transform.rotation = targetRotation;
    }
    public Quaternion PlanarRotation => Quaternion.Euler(0,rotationY,0);
}
