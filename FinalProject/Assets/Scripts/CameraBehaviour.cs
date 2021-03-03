using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
    private bool cameraZoomIn;
    private bool cameraZoomOut;
    public int cameraZoomThreshold;
    private int cameraZoomCounter;
    public bool beatTick;

    private Camera camera;
    public float cameraMinFOV;
    public float cameraMaxFOV;
    public float cameraZoomSpeed;

    private float cameraTiltCounter;
    public float cameraTiltThreshold;
    public float cameraTiltMaxX;
    public float cameraTiltMinX;
    public float cameraTiltMaxY;
    public float cameraTiltMinY;
    public float cameraTiltSpeed;
    private bool cameraTiltInMotion;
    private Vector3 cameraTiltTarget;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beatTick && !cameraZoomIn && !cameraZoomOut){
            cameraZoomIn = true;
            beatTick = false;
        }
        
        CameraZoom();
        CameraTilt();
        
    }

    void FixedUpdate() 
    {
        cameraZoomCounter++;
        cameraTiltCounter++;
    }

    void CameraZoom()
    {
        if(cameraZoomIn){
            //if(thisCamera.fieldOfView > cameraMinFOV){
            if(camera.transform.position.z < cameraMaxFOV){
                    //thisCamera.fieldOfView -= cameraZoomSpeed;
                    camera.transform.position += new Vector3(0,0,cameraZoomSpeed);
                }
            if(cameraZoomCounter > cameraZoomThreshold){
                cameraZoomIn = false;
                cameraZoomOut = true;
                cameraZoomCounter = 0; 
            }
        }
        if(cameraZoomOut){
            //if(thisCamera.fieldOfView < cameraMaxFOV){
            if(camera.transform.position.z > cameraMinFOV){
                    //thisCamera.fieldOfView += cameraZoomSpeed;
                    camera.transform.position -= new Vector3(0,0,cameraZoomSpeed);
                }
            if(cameraZoomCounter > cameraZoomThreshold){
                cameraZoomOut = false;
                cameraZoomCounter = 0;
            }
        }
    }

    void CameraTilt(){
        if(cameraTiltCounter > cameraTiltThreshold && !cameraTiltInMotion){
            cameraTiltInMotion = true;
            cameraTiltTarget = new Vector3(Random.RandomRange(cameraTiltMinX, cameraTiltMaxX),Random.RandomRange(cameraTiltMinX, cameraTiltMaxX),0);
        }

        if(cameraTiltInMotion){

            float diff = Quaternion.Angle(camera.transform.rotation, Quaternion.Euler(cameraTiltTarget));
            Debug.Log("camera rotation: "+camera.transform.rotation.eulerAngles.ToString());
            Debug.Log("camera target"+ cameraTiltTarget.ToString());
            Debug.Log("camera diff: "+diff);
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(cameraTiltTarget),cameraTiltSpeed);
            
            if(Mathf.Abs(diff) < 2f){
                cameraTiltInMotion = false;
                cameraTiltCounter = 0;
            }
        }

    }

}
