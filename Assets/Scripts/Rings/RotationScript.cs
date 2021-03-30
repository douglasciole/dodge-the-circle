using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool randomInitial;
    public bool targeted;
    public float targetAngle;
    public float rotationSpeed;

    void Start()
    {
        if (randomInitial)
        {
            this.transform.Rotate(Vector3.forward, Random.Range(-180, 180));
        }
        if (targeted)
        {
            this.transform.Rotate(Vector3.forward, targetAngle);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
