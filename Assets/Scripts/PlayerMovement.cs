using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float speed;
    public Camera cam;

    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        if (movement != Vector3.zero)
        {
            transform.eulerAngles = Vector3.up * inputAngle;
        }
    }

    void MoveCharacter(Vector3 move)
    {
        myRigidbody.MovePosition(transform.position + (move * speed * Time.fixedDeltaTime));
    }
}
