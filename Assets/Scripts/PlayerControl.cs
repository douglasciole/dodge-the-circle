using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // this value can be changed
    int speed = 3;

    Rect left_side = new Rect(0, 0, Screen.width/2, Screen.height);
    Rect right_side = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 pos = Input.GetTouch(0).position;

            // Left side touched..
            if (left_side.Contains(pos))
            {
                this.transform.Rotate(new Vector3(0, 0, speed));
            }

            // Right side touched.
            else if (right_side.Contains(pos))
            {
                this.transform.Rotate(new Vector3(0, 0, -speed));
            }
        }

        // for debug
        if (Input.GetMouseButton(0))
        {
            this.transform.Rotate(new Vector3(0, 0, speed));
        }

        if (Input.GetMouseButton(1))
        {
            this.transform.Rotate(new Vector3(0, 0, -speed));
        }

    }
}
