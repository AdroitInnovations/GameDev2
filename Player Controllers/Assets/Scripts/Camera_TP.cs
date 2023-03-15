using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_TP : MonoBehaviour
{

    public float mouseSensitivity = 10;
    float xRotation;
    float yRotation;
    public Transform target;
    public float distance = 3;
    public Vector2 yMinMax = new Vector2(-20, 80);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        yRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yRotation = Mathf.Clamp(yRotation, yMinMax.x, yMinMax.y);
        Vector3 targetRotation = new Vector3(yRotation, xRotation);
        transform.eulerAngles = targetRotation;
        transform.position = target.position - distance * transform.forward;

    }
}
