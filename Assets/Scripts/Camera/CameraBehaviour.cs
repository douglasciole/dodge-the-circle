using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    private Camera cameraMain;
    private float cameraMoveCounter;
    public float cameraMoveThreshold;
    public float cameraMaxX;
    public float cameraMinX;
    public float cameraMaxY;
    public float cameraMinY;
    public float cameraMaxZ;
    public float cameraMinZ;
    public float cameraMoveSpeed;
    public bool cameraMoveInMotion;
    public Vector3 cameraMoveTarget;
    public GameObject player;

    public float cameraMoveSetting;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = this.GetComponentInParent<Camera>();
        player = GameObject.Find("Player");
        cameraMoveSetting = PlayerPrefs.GetFloat("Camera_Move", 0.5f);
    }

    void FixedUpdate()
    {
        cameraMoveCounter++;
        CameraMove();
    }

    void CameraMove()
    {
        if (cameraMoveCounter > cameraMoveThreshold && !cameraMoveInMotion)
        {
            cameraMoveInMotion = true;
            cameraMoveTarget = NewTarget();
        }

        if (cameraMoveInMotion)
        {

            float diff = Vector3.Distance(cameraMain.transform.position, cameraMoveTarget);
            cameraMain.transform.position += (cameraMoveTarget - cameraMain.transform.position).normalized * (cameraMoveSpeed * cameraMoveSetting) * Time.deltaTime;
            cameraMain.transform.LookAt(player.transform.position);

            if (Mathf.Abs(diff) < 2f)
            {
                cameraMoveInMotion = false;
                cameraMoveCounter = 0;
            }
        }

    }

    Vector3 NewTarget()
    {
        Vector3 output = Vector3.zero;
        output += new Vector3(Random.Range(cameraMinX, cameraMaxX) * cameraMoveSetting, 0, 0);
        output += new Vector3(0, Random.Range(cameraMinX, cameraMaxX) * cameraMoveSetting, 0);
        output += new Vector3(0, 0, cameraMinZ + Random.Range(0, cameraMaxZ - cameraMinZ) * cameraMoveSetting);

        return output;
    }

}
