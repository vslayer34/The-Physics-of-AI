using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody rb;

    public float speed;

    bool toggle = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(speed);
        if (Input.GetKeyDown(KeyCode.D))
        {
            toggle= !toggle;
        }

        if (toggle)
        {
            MoveDiagonal(speed);
            MoveForward(0);
        }
        else
        {
            MoveDiagonal(0);
            MoveForward(speed);
        }
    }

    void FixedUpdate()
    {
        //Vector3 direction = new Vector3(rb.velocity.x, speed * Time.deltaTime, rb.velocity.z);
        //rb.velocity = transform.InverseTransformDirection(direction);
        Debug.Log($"Speed: {rb.velocity.magnitude}");
    }

    void MoveForward(float speed)
    {
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    void MoveDiagonal(float speed)
    {
        transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0.0f);
    }
}
