using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool randomInitial;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if(randomInitial){
            this.transform.Rotate(Vector3.forward, Random.Range(-180,180));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
