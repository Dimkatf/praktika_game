using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 500f;


    Quaternion targetRotation;

    cameracontrole cameraController;

    private void Awake() 
    {
        cameraController = Camera.main.GetComponent<cameracontrole>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmunt = Mathf.Abs(h) + Mathf.Abs(v);

        var moveInput = (new Vector3(h,0,v)).normalized;

        var moveDir = cameraController.PlanarRotation * moveInput;

        if (moveAmunt>0)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(moveDir);

        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    
    }
}
