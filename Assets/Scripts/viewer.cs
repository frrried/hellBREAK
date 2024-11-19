using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class viewer : MonoBehaviour
{
    private float Xposition;
    private float lerpPosition;
    public float mouseSensetivity = 10f;
    public float smoothness = 10f;

    private float lookPosition;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseInput();

        view();
    }

    void mouseInput()
    {
        Xposition = Input.GetAxisRaw("Mouse X") * mouseSensetivity;
        lerpPosition = Mathf.Lerp(lerpPosition, Xposition, 1f/smoothness);
    }

    void view()
    {
        lookPosition += lerpPosition;
        transform.localRotation = Quaternion.Euler(0, lookPosition, 0);
    }
}
