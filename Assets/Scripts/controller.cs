using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 20f;
    public CharacterController CC;

    private float gravity = -10f;

    private Vector3 inputVector;
    private Vector3 movementVector;
    public Animator camAnimator;
    private bool isRun;

    public float momentumDamping = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
        MovePlayer();

        camAnimator.SetBool("isRun", isRun);
    }

    void GetInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isRun = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isRun = false;
        }


        movementVector = (inputVector * speed) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        CC.Move(movementVector * Time.deltaTime);
    }
}
