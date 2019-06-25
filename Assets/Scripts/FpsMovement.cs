using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

// basic WASD-style movement control
public class FpsMovement : MonoBehaviour
{
    [SerializeField] private Camera headCam;

    static public float speed = 6.0f;
    static public float gravity = -9.8f;
    // public float jumpSpeed = 8.0F;

    private Vector3 moveDirection = Vector3.zero;

    public float sensitivityHor = 5.0f;
    public float sensitivityVert = 5.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float rotationVert = 0;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();

    }

    void Update()
    {
        MoveCharacter();
        RotateCharacter();
        RotateCamera();


    }

    private void MoveCharacter()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }




    private void RotateCharacter()
    {
        switch (Menu.flagM)
        {
            case 1:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;
            case 0:
                break;
        }
        //if (GenerationObjects.flagM == 0)
        //{
        //}
        //if (GenerationObjects.flagM == 1)
        //{
        //    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        //    GenerationObjects.flagM = 0;
        //}
    }

    private void RotateCamera()
    {
        switch(Menu.flagM)
        {
            case 1:
                rotationVert -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationVert = Mathf.Clamp(rotationVert, minimumVert, maximumVert);

                headCam.transform.localEulerAngles = new Vector3(
                    rotationVert, headCam.transform.localEulerAngles.y, 0
                );                
                break;

            case 0:
                break;
        }

        //if (GenerationObjects.flagM == 0)
        //{
           
        //}
        //if (GenerationObjects.flagM == 1)
        //{
        //    rotationVert -= Input.GetAxis("Mouse Y") * sensitivityVert;
        //    rotationVert = Mathf.Clamp(rotationVert, minimumVert, maximumVert);

        //    headCam.transform.localEulerAngles = new Vector3(
        //        rotationVert, headCam.transform.localEulerAngles.y, 0
        //    );

        //    GenerationObjects.flagM = 0;

        //}
    }
}

    

