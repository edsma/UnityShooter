using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementScript : MonoBehaviour
{
    [Tooltip("Velocidad de movimiento del personaje")]
    [Range(0,10)]
    public float speed;

    [Tooltip("Velocidad de rotación de la camar")]
    [Range(0, 10)]
    public float rotationSpeed;

    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]
    private LayerMask aimColliderLayerMask = new LayerMask();

    [SerializeField]
    private Transform debugTransformation;

    [SerializeField]
    private Transform targetToFollow;

    private Rigidbody rb;

    Vector3 mousePosition;

    public Vector3 getMousePosition()
    {
        return mousePosition;
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ActionButtons();
       

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray,out RaycastHit rayCastHit,999f,aimColliderLayerMask))
        {
            //debugTransformation.position = rayCastHit.point;
            mousePosition = rayCastHit.point;
        }

        MoveCharacter();
    }

    private void ActionButtons()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CinemachineComponentBase componentBase = aimVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance = 0.7f; // your value
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            CinemachineComponentBase componentBase = aimVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance = 2.5f; // your value
            }

        }
    }

    private void MoveCharacter()
    {
        float space = speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(speed * horizontal, 0, speed * vertical);
        transform.Translate(dir.normalized * space);
        rb.AddRelativeForce(dir.normalized*space);

        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        targetToFollow.eulerAngles += speed * new Vector3(mouseY, mouseX, 0);
        rb.AddRelativeTorque(0,mouseX*angle,0);
    }
}
