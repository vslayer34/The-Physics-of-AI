using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    float timeStartOffSet = 0;
    bool gotStartTime = false;
    void Update()
    {
        if (!gotStartTime)
        {
            timeStartOffSet = Time.realtimeSinceStartup;
            gotStartTime = true;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y,
            Time.realtimeSinceStartup - timeStartOffSet);
    }
}
