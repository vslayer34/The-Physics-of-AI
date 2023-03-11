using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        float velocity = Time.deltaTime * speed;
        transform.Translate(0.0f, 0.0f, velocity);
    }
}
