﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    void LateUpdate()
    {
        transform.Translate(0.0f, 0.0f, 0.1f);
    }
}
