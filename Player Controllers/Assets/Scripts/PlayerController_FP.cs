using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float walkSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 inputDirection = input.normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(inputDirection * (walkSpeed * 2) * Time.deltaTime);
            return;
        }
        transform.Translate(inputDirection * walkSpeed * Time.deltaTime);
    }
}
