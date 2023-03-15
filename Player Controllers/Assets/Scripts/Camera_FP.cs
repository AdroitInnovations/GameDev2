using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FP : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation;
    float yRotation;
    Transform player;
    public Vector2 yMinMax = new Vector2(-60, 60);

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation += Input.GetAxis("Mouse X") * mouseSensitivity *Time.deltaTime;
        yRotation += Input.GetAxis("Mouse Y") * mouseSensitivity *Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, yMinMax.x, yMinMax.y);
        transform.localEulerAngles = Vector3.left * yRotation;
        player.localEulerAngles = Vector3.up * xRotation;
    }
}
