using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bewegung : MonoBehaviour
{

    public float geschwindigkeit_x = 10f;
    public float geschwindigkeit_z = 5f;
    Rigidbody rb;
    float movement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        velocity.x = movement * geschwindigkeit_x;
        velocity.z = geschwindigkeit_z;
        rb.velocity = velocity;
    }
}
