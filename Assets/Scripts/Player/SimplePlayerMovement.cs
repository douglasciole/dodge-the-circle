using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
    }
    
    void CheckRotation(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.Rotate(Vector3.forward, rotateSpeed);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.Rotate(Vector3.back, rotateSpeed);
        }

    }
}
