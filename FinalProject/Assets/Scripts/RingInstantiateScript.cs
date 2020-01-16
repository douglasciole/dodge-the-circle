using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiateScript : MonoBehaviour
{
    public float ringSpeed;
    public bool instantiateFlag;
    public Camera camera;
    private bool cameraZoomStartFlag;
    private bool cameraZoomEndFlag;
    private float cameraZoomSpeed = 0.5f;
    private float t;

    public int level_0;
    public GameObject ringLevel_0_1;
    public GameObject ringLevel_0_2;
    public GameObject ringLevel_0_3;


    private GameObject currentInstance;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tempObject = PickFromList(0);
        
        if(instantiateFlag){
            currentInstance = GameObject.Instantiate(tempObject,Vector3.zero,Quaternion.identity);
            currentInstance.transform.Rotate(Vector3.forward, Random.Range(-180,180));
            instantiateFlag = false;

        }
    }

    GameObject PickFromList(int level){
        switch(level){
            case 0:
                int aux = Random.Range(0, level_0);
                switch(aux){
                    case 0: 
                        return ringLevel_0_1; 
                    case 1: 
                        return ringLevel_0_2; 
                    case 2: 
                        return ringLevel_0_3;
                    default:
                        return ringLevel_0_1; 
                }
            default:
                return ringLevel_0_1;
        }
    }

    public void spawnRing() {
        instantiateFlag = true;
    }


}