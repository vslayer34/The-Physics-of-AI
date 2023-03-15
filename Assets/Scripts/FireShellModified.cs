using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShellModified : MonoBehaviour {

    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;
    public Transform turretBase;

    float rotationSpeed = 4.0f;
    public float shellSpeed = 15.0f;

    void Update()
    {
        Vector3 direction = (enemy.transform.position - transform.position).normalized;
        Vector3 rotationVector = new Vector3(direction.x, 0.0f, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(rotationVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        RotateTurret();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        GameObject shell = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        shell.GetComponent<Rigidbody>().velocity = shellSpeed * turretBase.forward;
    }

    float? CalculateAngle(bool low)
    {
        float errorFactor = 1.0f;
        Vector3 targetDirection = enemy.transform.position - transform.position;
        float y = targetDirection.y = 0.0f;
        float x = targetDirection.magnitude - errorFactor;
        float gravity = 9.8f;
        float speedSqrt = shellSpeed * shellSpeed;
        float underTheRoot = (Mathf.Pow(speedSqrt, 2)) - (gravity * (gravity * Mathf.Pow(x, 2) + 2 * y * speedSqrt));

        if (underTheRoot >= 0)
        {
            float root = Mathf.Sqrt(underTheRoot);
            float highAngle = speedSqrt + root;
            float lowAngle = speedSqrt - root;

            return low switch
            {
                true => Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg,
                false => Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg
            };
        }
        else
            return null;
    }

    void RotateTurret()
    {
        float? angle = CalculateAngle(true);
        if (angle != null)
        {
            turretBase.localEulerAngles = new Vector3(360.0f - (float)angle, 0.0f, 0.0f);
        }
    }
}
